import 'package:AgrifoodApp/authentication/signup/models/signup_farmer_model.dart';
import 'package:AgrifoodApp/respository/register_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'signUp_state.dart';

class SignUpCubit extends Cubit<SignUpState> {
  final RegisterReponsitory registerReponsitory;
  SignUpCubit(this.registerReponsitory) : super(SignUpInitial());

  Future<void> signUpFarmer({userName, password, email, phoneNumber}) async {
    try {
      emit(SignUpLoading());
      var signUpFarmerModel2 = SignUpFarmerModel();
      signUpFarmerModel2.email = email;
      signUpFarmerModel2.userName = userName;
      signUpFarmerModel2.passWord = password;
      signUpFarmerModel2.phoneNumber = phoneNumber;
      var signUpFarmerRequest = await registerReponsitory.signUpFarmer(signUpFarmerModel2);
      if (signUpFarmerRequest == true) {
        emit(SignUpLoaded("Bạn đã đăng kí thành công"));
      } else {
        emit(SignUpError("Đăng kí thất bại"));
      }
    } catch (e) {
      print(e);
    }
  }
}
