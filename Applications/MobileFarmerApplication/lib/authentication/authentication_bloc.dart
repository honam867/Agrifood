import 'dart:convert';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:meta/meta.dart';
import '../core/token.dart';
import '../respository/authentication_repository.dart';
import 'authentication_event.dart';
import 'authentication_state.dart';

class AuthenticationBloc
    extends Bloc<AuthenticationEvent, AuthenticationState> {
  final AuthenticationRepository authenticationRepository;

  AuthenticationBloc(this.authenticationRepository)
      : assert(authenticationRepository != null), super(null);
  @override
  AuthenticationState get initialState => AuthenticationUnauthenticated();

  
  @override
  Stream<AuthenticationState> mapEventToState(
      AuthenticationEvent event) async* {
    if (event is AppStarted) {
      final bool isValidToken = await Token.isValidToken();
      if (isValidToken) {
        //Get CustomerId
        final Map<String, dynamic> customerId =
            json.decode(await Token.getLoggedCustomerId());

        //Avatar and FullName
        final Map<String, dynamic> customerEmployee =
            json.decode(await Token.getLoggedCustomerEmployeeId());

        yield AuthenticationAuthenticated(
            fullname: customerEmployee['Name'],
            avatarUrl: customerEmployee['AvatarURL'],
            customerId: customerId['Id'],
            assetFinger: true,
            loginModel: event.loginModel);
      } else {
        yield AuthenticationUnauthenticated();
      }
    }
    if (event is LoggedIn) {
      yield AuthenticationLoading();
      await authenticationRepository.persistToken(event.token);
      //Get CustomerId
      final Map<String, dynamic> customerId =
          json.decode(await Token.getLoggedCustomerId());

      //Avatar and FullName
      final Map<String, dynamic> customerEmployee =
          json.decode(await Token.getLoggedCustomerEmployeeId());

      yield AuthenticationAuthenticated(
          fullname: customerEmployee['Name'],
          avatarUrl: customerEmployee['AvatarURL'],
          customerId: customerId['Id'],
          loginModel: event.loginModel,
          assetFinger: event.fingerId);
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
