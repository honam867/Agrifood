import 'dart:convert';
import 'package:AgrifoodApp/core/token.dart';
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
        final Map<String, dynamic> customerId =
            json.decode(await Token.getFarmerId());
        UserInfoModel userInfoModel = UserInfoModel.fromJson(customerId);

        //Avatar and FullName
        // final Map<String, dynamic> customerEmployee =
        //     json.decode(await Token.getLoggedCustomerEmployeeId());

        yield AuthenticationAuthenticated(userInfo: userInfoModel);
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
      final Map<String, dynamic> customerId =
          json.decode(await Token.getFarmerId());
      UserInfoModel userInfoModel = UserInfoModel.fromJson(customerId);
      print(customerId);
      //Avatar and FullName
      // final Map<String, dynamic> customerEmployee =
      //     json.decode(await Token.getLoggedCustomerEmployeeId());

      yield AuthenticationAuthenticated(userInfo: userInfoModel);
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
