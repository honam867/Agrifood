import 'package:AgrifoodApp/core/model_okvalue.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

abstract class AuthenticationState extends Equatable {
  const AuthenticationState();
  @override
  List<Object> get props => [];
}

class AuthenticationUninitialized extends AuthenticationState {}

class AuthenticationLoginPage extends AuthenticationState {}

class ChangePassLoading extends AuthenticationState {}

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

class ChangePassLoaded extends AuthenticationState {
  final String result;

  ChangePassLoaded(this.result);
  

  @override
  bool operator == (Object o) {
    if (identical(this, o)) return true;

    return o is ChangePassLoaded && o.result == result;
  }

  @override
  int get hashCode => super.hashCode;

}

class ChangePassFail extends AuthenticationState {
  final String result;

  ChangePassFail(this.result);
  

  @override
  bool operator == (Object o) {
    if (identical(this, o)) return true;

    return o is ChangePassFail && o.result == result;
  }

  @override
  int get hashCode => super.hashCode;

}

class AuthenticationAuthenticated extends AuthenticationState {
  final UserInfoModel userInfo;

  const AuthenticationAuthenticated(
      {@required this.userInfo});

  @override
  List<Object> get props => [];
}

class AuthenticationUnauthenticated extends AuthenticationState {}
class LoginFormButtonState extends AuthenticationState {}

class AuthenticationLoading extends AuthenticationState {}
