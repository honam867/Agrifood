import 'package:AgrifoodApp/authentication/change_password.dart/models/changepass_model.dart';
import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:AgrifoodApp/respository/register_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'authentication.dart';

class AuthenticationCubit extends Cubit<AuthenticationState> {
  final RegisterReponsitory _registerReponsitory;
  final AuthenticationRepository _authenticationRepository;
  AuthenticationCubit(this._registerReponsitory, this._authenticationRepository)
      : super(AuthenticationUnauthenticated());

  Future<void> checkPhoneNumber(String phoneNumber) async {
    try {
      // emit(WeatherLoading());
      final result = await this
          ._registerReponsitory
          .checkPhoneNumber(phoneNumber: phoneNumber);

      emit(CheckPhoneNumberLoaded(result));
    } catch (ex) {
      print(ex);
    }
  }

  Future<void> changePass(ChangePassModel changePassModel) async {
    try {
       emit(ChangePassLoading());
      final result = await this
          ._authenticationRepository
          .changePass(changePassModel: changePassModel);
      result == true
          ? emit(ChangePassLoaded("Đổi mật khẩu thành công"))
          : emit(ChangePassLoaded("Kiểm tra lại thông tin"));
    } catch (ex) {
      print(ex);
    }
  }
}
