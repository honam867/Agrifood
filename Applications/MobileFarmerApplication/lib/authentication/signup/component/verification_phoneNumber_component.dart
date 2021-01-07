import 'package:AgrifoodApp/authentication/bloc/authentication.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_cubit.dart';
import 'package:AgrifoodApp/authentication/login/page/login.dart';
import 'package:AgrifoodApp/authentication/signup/component/verification_code_component.dart';
import 'package:AgrifoodApp/authentication/signup/component/verifycation_code.dart';
import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:AgrifoodApp/respository/register_repository.dart';
import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class VerificationPhoneCode extends StatefulWidget {
  @override
  _VerificationPhoneCodeState createState() => _VerificationPhoneCodeState();
}

class _VerificationPhoneCodeState extends State<VerificationPhoneCode> {
  final authenticationRepository = new AuthenticationRepository();
  TextEditingController phoneController = TextEditingController();

  final registerRepository = new RegisterReponsitory();
  @override
  void dispose() {
    phoneController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    void submitCityName(BuildContext context, String phoneNumber) {
      var bloc = context.bloc<AuthenticationCubit>();
      final weatherCubit = bloc;
      weatherCubit.checkPhoneNumber(phoneNumber);
    }

    return BlocConsumer<AuthenticationCubit, AuthenticationState>(
      listener: (context, state) {
        if (state is CheckPhoneNumberLoaded) {
          if (state.okValueObject.value == "1") {
            Navigator.of(context).push(MaterialPageRoute(
                builder: (context) => VerificationCodeComponent(
                      phoneNumber: phoneController.text,
                    )));
          } else {
            showToast(string: "Số điện thoại không tồn tại", context: context);
          }
        }
      },
      builder: (context, state) {
        return Scaffold(
          resizeToAvoidBottomInset: true,
          backgroundColor: Colors.white,
          appBar: AppBar(
            elevation: 0,
            brightness: Brightness.light,
            backgroundColor: Colors.white,
            leading: IconButton(
              onPressed: () {
                Navigator.pop(context);
              },
              icon: Icon(
                Icons.arrow_back_ios,
                size: 20,
                color: Colors.black,
              ),
            ),
          ),
          body: SingleChildScrollView(
            child: Container(
              padding: EdgeInsets.symmetric(horizontal: 40),
              height: MediaQuery.of(context).size.height - 50,
              width: double.infinity,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: <Widget>[
                  Column(
                    children: <Widget>[
                      FadeAnimation(
                          1,
                          Text(
                            "Xác thực số điện thoại",
                            style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
                          )),
                      SizedBox(
                        height: 20,
                      ),
                      FadeAnimation(
                          1.2,
                          Text(
                            "Số điện thoại phải được đăng kí với nhân viên",
                            style: TextStyle(fontSize: 15, color: Colors.grey[700]),
                          )),
                    ],
                  ),
                  Column(
                    children: <Widget>[
                      FadeAnimation(1.2, makeInput(label: "Số điện thoại", controller: phoneController)),
                    ],
                  ),
                  FadeAnimation(
                      1.5,
                      Container(
                        padding: EdgeInsets.only(top: 3, left: 3),
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(50),
                            border: Border(
                              bottom: BorderSide(color: Colors.black),
                              top: BorderSide(color: Colors.black),
                              left: BorderSide(color: Colors.black),
                              right: BorderSide(color: Colors.black),
                            )),
                        child: MaterialButton(
                          minWidth: double.infinity,
                          height: 60,
                          onPressed: () async {
                            if (phoneController.text == null) {
                              showToast(string: "Vui lòng nhập số điện thoại", context: context);
                            } else {
                              final checkPhone = context.bloc<AuthenticationCubit>();
                              checkPhone.checkPhoneNumber("0${phoneController.text}");
                            }
                          },
                          color: Colors.greenAccent,
                          elevation: 0,
                          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(50)),
                          child: Text(
                            "Gửi",
                            style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                          ),
                        ),
                      )),
                  FadeAnimation(
                      1.6,
                      Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: <Widget>[
                          Text("Bạn thật sự đã có tài khoản? "),
                          TextButton(
                            onPressed: () => Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => LoginPage(
                                          authenticationRepository: authenticationRepository,
                                        ))),
                            child: Text(
                              "Đăng nhập",
                              style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                            ),
                          )
                        ],
                      )),
                ],
              ),
            ),
          ),
        );
      },
    );
  }
}

Widget makeInput({label, controller, obscureText = false}) {
  return Column(
    crossAxisAlignment: CrossAxisAlignment.start,
    children: <Widget>[
      Text(
        label,
        style: TextStyle(fontSize: 15, fontWeight: FontWeight.w400, color: Colors.black87),
      ),
      SizedBox(
        height: 5,
      ),
      TextField(
        obscureText: obscureText,
        controller: controller,
        decoration: InputDecoration(
          contentPadding: EdgeInsets.symmetric(vertical: 0, horizontal: 10),
          enabledBorder: OutlineInputBorder(borderSide: BorderSide(color: Colors.grey[400])),
          border: OutlineInputBorder(borderSide: BorderSide(color: Colors.grey[400])),
        ),
      ),
      SizedBox(
        height: 30,
      ),
    ],
  );
}
