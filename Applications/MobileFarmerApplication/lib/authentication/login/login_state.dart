import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

abstract class LoginState extends Equatable {
  const LoginState();

  @override
  List<Object> get props => [];
}

class LoginInitial extends LoginState {}

class LoginFormState extends LoginState {}

class LoginLoading extends LoginState {}

class LoginFailure extends LoginState {
  final String error;

  const LoginFailure({@required this.error});

  @override
  List<Object> get props => [error];

  @override
  String toString() => 'Đăng nhập thất bại {error: $error}';
}

