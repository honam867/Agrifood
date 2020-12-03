import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'login/model/login_model.dart';

abstract class AuthenticationState extends Equatable {
  const AuthenticationState();
  @override
  List<Object> get props => [];
}

class AuthenticationUninitialized extends AuthenticationState {}

class AuthenticationLoginPage extends AuthenticationState {}

class AuthenticationAuthenticated extends AuthenticationState {
  final String fullname;
  final String avatarUrl;
  final int customerId;
  final LoginModel loginModel;
  final bool assetFinger;

  const AuthenticationAuthenticated(
      {@required this.fullname,
      @required this.avatarUrl,
      @required this.customerId,
      @required this.loginModel, @required this.assetFinger});

  @override
  List<Object> get props => [];
}

class AuthenticationUnauthenticated extends AuthenticationState {}

class AuthenticationLoading extends AuthenticationState {}
