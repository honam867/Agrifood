import 'dart:convert';
import 'package:AgrifoodApp/core/token.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'authentication_event.dart';
import 'authentication_state.dart';

class AuthenticationBloc
    extends Bloc<AuthenticationEvent, AuthenticationState> {
  final AuthenticationRepository authenticationRepository;

  AuthenticationBloc(this.authenticationRepository)
      : assert(authenticationRepository != null),
        super(null);

  AuthenticationState get initialState => AuthenticationUnauthenticated();

  @override
  Stream<AuthenticationState> mapEventToState(
      AuthenticationEvent event) async* {
    if (event is AppStarted) {
      final bool isValidToken = await Token.isValidToken();
      if (isValidToken) {
        //Get CustomerId
        // final Map<String, dynamic> userInfo =
        //     json.decode(await Token.getUserInfo());
        // UserInfoModel userInfoModel = UserInfoModel.fromJson(userInfo);
        //Get FarmerInfo
        final Map<String, dynamic> farmerInfo =
            json.decode(await Token.getFarmerInfo());
        if (farmerInfo != null) {
          FarmerInfoModel farmerInfoModel =
              FarmerInfoModel.fromJson(farmerInfo);
          yield AuthenticationAuthenticated(
              userInfo: null, farmerInfoModel: farmerInfoModel);
        } else {
          yield AuthenticationAuthenticated(
              userInfo: null, farmerInfoModel: null);
        }
      } else {
        yield AuthenticationUnauthenticated();
      }
    }
    if (event is LoginFormButton) {
      yield LoginFormButtonState();
    }
    if (event is LoggedIn) {
      yield AuthenticationLoading();
      await authenticationRepository.persistToken(event.token);
      //Get CustomerId
      // final Map<String, dynamic> userInfo =
      //     json.decode(await Token.getUserInfo());
      // UserInfoModel userInfoModel = UserInfoModel.fromJson(userInfo);
      //print(userInfo);
      final Map<String, dynamic> farmerInfo =
          json.decode(await Token.getFarmerInfo());
      print(farmerInfo);
      if (farmerInfo != null) {
        FarmerInfoModel farmerInfoModel = FarmerInfoModel.fromJson(farmerInfo);
        yield AuthenticationAuthenticated(
            userInfo: null, farmerInfoModel: farmerInfoModel);
      } else {
        yield AuthenticationAuthenticated(
            userInfo: null, farmerInfoModel: null);
      }
    }
    if (event is LoggedOut) {
      yield AuthenticationLoading();
      await authenticationRepository.deleteToken();
      yield AuthenticationUnauthenticated();
    }
    if (event is RedirectToLoginPage) {
      yield AuthenticationLoginPage();
    }
    // if (event is CheckCodePage) {
    //   yield AuthenticationLoginPage();
    // }
  }
}
