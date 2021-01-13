import 'package:AgrifoodApp/authentication/login/model/login_model.dart';
import 'package:AgrifoodApp/core/model_okvalue.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

abstract class AuthenticationState extends Equatable {
  const AuthenticationState();
  @override
  List<Object> get props => [];
}

class AuthenticationUninitialized extends AuthenticationState {}

class AuthenticationLoginPage extends AuthenticationState {}

class CheckPhoneNumberLoaded extends AuthenticationState {
  final OkValueObject okValueObject;
  const CheckPhoneNumberLoaded(this.okValueObject);

  @override
  bool operator == (Object o) {
    if (identical(this, o)) return true;

    return o is CheckPhoneNumberLoaded && o.okValueObject == okValueObject;
  }

  @override
  int get hashCode => super.hashCode;

}

class AuthenticationAuthenticated extends AuthenticationState {
  final userInfo;

  const AuthenticationAuthenticated(
      {@required this.userInfo});

  @override
  List<Object> get props => [];
}

class AuthenticationUnauthenticated extends AuthenticationState {}
class LoginFormButtonState extends AuthenticationState {}

class AuthenticationLoading extends AuthenticationState {}
