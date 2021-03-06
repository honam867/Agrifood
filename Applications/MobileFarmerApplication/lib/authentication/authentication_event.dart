import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'login/model/login_model.dart';

abstract class AuthenticationEvent extends Equatable {
  const AuthenticationEvent();

  @override
  List<Object> get props => [];
}

class AppStarted extends AuthenticationEvent {
  
  final LoginModel loginModel;
  final bool fingerId;

   const AppStarted({@required this.loginModel, this.fingerId});

    @override
  List<Object> get props => [loginModel];

  @override
  String toString() => 'AppStarted';
}

class LoggedIn extends AuthenticationEvent {
  final String token;
  final LoginModel loginModel;
  final bool fingerId;
  const LoggedIn({@required this.token, this.loginModel, this.fingerId});

  @override
  List<Object> get props => [token];

  @override
  String toString() => 'LoggedIn';
}

class LoggedOut extends AuthenticationEvent {
  @override
  String toString() => 'LoggedOut';
}

class RedirectToLoginPage extends AuthenticationEvent {}
