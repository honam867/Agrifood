import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'model/login_model.dart';

abstract class LoginEvent extends Equatable {
  const LoginEvent();
}

class LoginButtonPress extends LoginEvent {
  final LoginModel loginModel;


  const LoginButtonPress({
    @required this.loginModel
  });

  @override
  List<Object> get props => [loginModel];

  @override
  String toString() => 'Login button press {userName: $loginModel.userName}';
}
