part of 'signUp_cubit.dart';

abstract class SignUpState {
  const SignUpState();
}

class SignUpInitial extends SignUpState {
  const SignUpInitial();
}

class SignUpLoading extends SignUpState {
  const SignUpLoading();
}

class SignUpLoaded extends SignUpState {
  final String result;

  SignUpLoaded(this.result);
  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;
    return o is SignUpLoaded && o.result == result;
  }

  @override
  int get hashCode => result.hashCode;
}

class SignUpError extends SignUpState {
  final String result;

  SignUpError(this.result);
  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;
    return o is SignUpError && o.result == result;
  }

  @override
  int get hashCode => result.hashCode;
}
