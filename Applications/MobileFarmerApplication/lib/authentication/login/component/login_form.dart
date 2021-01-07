import 'package:AgrifoodApp/authentication/login/login_bloc.dart';
import 'package:AgrifoodApp/authentication/login/login_event.dart';
import 'package:AgrifoodApp/authentication/login/login_state.dart';
import 'package:AgrifoodApp/authentication/login/model/login_model.dart';
import 'package:AgrifoodApp/authentication/signup/page/signup.dart';
import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:toast/toast.dart';

class LoginComponent extends StatefulWidget {
  @override
  _LoginComponentState createState() => _LoginComponentState();
}

class _LoginComponentState extends State<LoginComponent> {
   bool _obscureTextPassword = true;
  final _userNameController = TextEditingController();
  final _passwordController = TextEditingController();
  bool isValid = false;

  void checkValidation() {
    setState(() {
      isValid = this._userNameController.text.isNotEmpty && this._passwordController.text.isNotEmpty;
    });
  }

  void _showOrHidePassword() {
    setState(() {
      _obscureTextPassword = !_obscureTextPassword;
    });
  }

  @override
  Widget build(BuildContext context) {
    _onLoginButtonPressed() {
      BlocProvider.of<LoginBloc>(context).add(
        LoginButtonPress(
            loginModel: new LoginModel(
          _userNameController.text,
          _passwordController.text,
        )),
      );
    }

    return BlocListener<LoginBloc, LoginState>(listener: (context, state) {
      if (state is LoginFailure) {
        Toast.show('${state.error}', context, duration: Toast.LENGTH_SHORT, gravity:  Toast.BOTTOM);
      }
      
    }, child: BlocBuilder<LoginBloc, LoginState>(
      builder: (context, state) {
        return Scaffold(
          resizeToAvoidBottomInset: false,
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
          body: Container(
            height: MediaQuery.of(context).size.height,
            width: double.infinity,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: <Widget>[
                Expanded(
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: <Widget>[
                      Column(
                        children: <Widget>[
                          FadeAnimation(
                              1,
                              Text(
                                "Đăng nhập",
                                style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
                              )),
                          SizedBox(
                            height: 20,
                          ),
                          FadeAnimation(
                              1.2,
                              Text(
                                "Đăng nhập tài khoản của bạn",
                                style: TextStyle(fontSize: 15, color: Colors.grey[700]),
                              )),
                        ],
                      ),
                      Padding(
                        padding: EdgeInsets.symmetric(horizontal: 40),
                        child: Column(
                          children: <Widget>[
                            FadeAnimation(
                                1.2,
                                makeInput(
                                  label: "Số điện thoại",
                                  controller: _userNameController,
                                )),
                            FadeAnimation(1.3, makeInput(label: "Mật khẩu", controller: _passwordController, obscureText: true)),
                          ],
                        ),
                      ),
                      FadeAnimation(
                          1.4,
                          Padding(
                            padding: EdgeInsets.symmetric(horizontal: 40),
                            child: Container(
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
                                onPressed: state is! LoginLoading
                                ? _onLoginButtonPressed
                                : null,
                                color: Colors.greenAccent,
                                elevation: 0,
                                shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(50)),
                                child: Text(
                                  "Đăng nhập",
                                  style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                                ),
                              ),
                            ),
                          )),
                      FadeAnimation(
                          1.5,
                          Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: <Widget>[
                              Text("Bạn không có tài khoản? "),
                              TextButton(
                                onPressed: () => Navigator.push(context, MaterialPageRoute(builder: (context) => SignUpPage())),
                                child: Text(
                                  "Đăng kí",
                                  style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                                ),
                              ),
                              // Text("Đăng kí", style: TextStyle(
                              //   fontWeight: FontWeight.w600, fontSize: 18
                              // ),),
                            ],
                          ))
                    ],
                  ),
                ),
                FadeAnimation(
                    1.2,
                    Container(
                      height: MediaQuery.of(context).size.height / 3,
                      decoration: BoxDecoration(image: DecorationImage(image: AssetImage('assets/background.png'), fit: BoxFit.cover)),
                    ))
              ],
            ),
          ),
        );
      },
    ));
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
          obscureText: label != "Số điện thoại" ? _obscureTextPassword : false,
          controller: controller,
          onChanged: (value) {
            checkValidation();
          },
          decoration: InputDecoration(
            contentPadding: EdgeInsets.symmetric(vertical: 0, horizontal: 10),
            enabledBorder: OutlineInputBorder(borderSide: BorderSide(color: Colors.grey[400])),
            border: OutlineInputBorder(borderSide: BorderSide(color: Colors.grey[400])),
            suffixIcon: label != "Số điện thoại" ? IconButton(
              icon: obscureText ? Icon(Icons.remove_red_eye) : Icon(Icons.visibility_off),
              onPressed: _showOrHidePassword
            ) : null,
          ),
        ),
        SizedBox(
          height: 30,
        ),
      ],
    );
  }
}
