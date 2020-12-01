import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'model/login_model.dart';

abstract class LoginEvent extends Equatable {
  const LoginEvent();
}

class LoginButtonPress extends LoginEvent {
  final LoginModel loginModel;
  final bool accessFinger;

  const LoginButtonPress({
    @required this.loginModel, this.accessFinger
  });

  @override
  List<Object> get props => [loginModel];

  @override
  String toString() => 'Login button press {userName: $loginModel.userName}';
}
