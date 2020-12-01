import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:meta/meta.dart';

import '../../core/storage.dart';
import '../../respository/authentication_repository.dart';
import '../authentication_bloc.dart';
import '../authentication_event.dart';
import 'login_event.dart';
import 'login_state.dart';


class LoginBloc extends Bloc<LoginEvent, LoginState> {
  final AuthenticationRepository authenticationRepository;
  final AuthenticationBloc authenticationBloc;

  LoginBloc(
      {@required this.authenticationRepository,
      @required this.authenticationBloc})
      : assert(authenticationRepository != null),
        assert(authenticationBloc != null), super(null);

  @override
  get initialState => LoginInitial();

  @override
  Stream<LoginState> mapEventToState(LoginEvent event) async* {
    if (event is LoginButtonPress) {
      yield LoginLoading();
      try {
        var loginResult = await authenticationRepository.authenticate(
          loginModel: event.loginModel,
        );
        if (loginResult) {
          String storageToken = await Storage.getString('token');
          if (storageToken.length > 0) {

            await authenticationRepository.authenticate(
                loginModel: event.loginModel, );
          }
          authenticationBloc
              .add(LoggedIn(token: storageToken, loginModel: event.loginModel, fingerId: event.accessFinger));
          yield LoginInitial();
        } else {
          yield LoginFailure(error: 'Đăng nhập không thành công');
        }
      } catch (error) {
        yield LoginFailure(error: error.toString());
      }
    }
  }
}
