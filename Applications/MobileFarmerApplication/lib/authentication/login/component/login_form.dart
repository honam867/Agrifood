import 'package:AgrifoodApp/authentication/bloc/authentication_bloc.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_event.dart';
import 'package:AgrifoodApp/authentication/login/login_bloc.dart';
import 'package:AgrifoodApp/authentication/login/login_event.dart';
import 'package:AgrifoodApp/authentication/login/login_state.dart';
import 'package:AgrifoodApp/authentication/login/model/login_model.dart';
import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:toast/toast.dart';

class LoginComponent extends StatefulWidget {
  @override
  _LoginComponentState createState() => _LoginComponentState();
}

class _LoginComponentState extends State<LoginComponent> {
  bool _obscureTextPassword = true;
  final _userNameController = TextEditingController();
  final _passwordController = TextEditingController();
  bool loading = false;
  bool isValid = false;

  void checkValidation() {
    setState(() {
      isValid = this._userNameController.text.isNotEmpty &&
          this._passwordController.text.isNotEmpty;
    });
  }

  void _showOrHidePassword() {
    setState(() {
      _obscureTextPassword = !_obscureTextPassword;
    });
  }

  // Future<bool> _willPopCallback() async {
  //   Navigator.of(context).pop(false);
  //   BlocProvider.of<AuthenticationBloc>(context).add(RedirectToLoginPage());
  //   //Navigator.of(context).pop(false);
  //   return false;
  // }

  @override
  Widget build(BuildContext context) {
    _onLoginButtonPressed() {
      loading = true;
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
        loading = false;
        Toast.show('${state.error}', context,
            duration: Toast.LENGTH_SHORT, gravity: Toast.BOTTOM);
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
                  BlocProvider.of<AuthenticationBloc>(context)
                      .add(RedirectToLoginPage());
                },
                icon: Icon(
                  Icons.arrow_back_ios,
                  size: 20,
                  color: Colors.black,
                ),
              ),
            ),
            body: WillPopScope(
                child: Container(
                  height: ScreenUtil().screenHeight,
                  width: ScreenUtil().screenWidth,
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
                                      style: TextStyle(
                                          fontSize: ScreenUtil().setSp(100,
                                              allowFontScalingSelf: false),
                                          fontWeight: FontWeight.bold),
                                    )),
                                SizedBox(
                                  height: ScreenUtil().setHeight(40),
                                ),
                                // FadeAnimation(
                                //     1.2,
                                //     Text(
                                //       "Đăng nhập tài khoản của bạn",
                                //       style: TextStyle(
                                //           fontSize: ScreenUtil().setSp(32,
                                //               allowFontScalingSelf: false),
                                //           color: Colors.grey[700]),
                                //     )),
                              ],
                            ),
                            Padding(
                             padding: 
                              EdgeInsets.fromLTRB(
                              ScreenUtil().setWidth(40), 
                              ScreenUtil().setHeight(40), 
                              ScreenUtil().setWidth(40), 
                              ScreenUtil().setHeight(20)),
                            child: Column(
                              children: [
                                FadeAnimation(
                                    1.2,
                                    makeInput(
                                      label: "Tài khoản",
                                      controller: _userNameController,
                                    )),
                                FadeAnimation(
                                    1.3,
                                    makeInput(
                                        label: "Mật khẩu",
                                        controller: _passwordController,
                                        obscureText: true)),
                                
                              ],
                            ),
                          ),
                            FadeAnimation(
                                1.4,
                                Padding(
                                  padding: EdgeInsets.symmetric(
                                      horizontal: ScreenUtil().setHeight(40),
                                      vertical: ScreenUtil().setWidth(40)),
                                  child: Container(
                                    padding: EdgeInsets.only(
                                        top: ScreenUtil().setHeight(2),
                                        left: ScreenUtil().setWidth(1)),
                                    decoration: BoxDecoration(
                                        borderRadius: BorderRadius.circular(500),
                                        border: Border(
                                          bottom:
                                              BorderSide(color: Colors.black),
                                          top: BorderSide(color: Colors.black),
                                          left: BorderSide(color: Colors.black),
                                          right:
                                              BorderSide(color: Colors.black),
                                        )),
                                    child: MaterialButton(
                                      minWidth: double.infinity,
                                      height: ScreenUtil().setWidth(150),
                                      onPressed: state is! LoginLoading
                                          ? _onLoginButtonPressed
                                          : null,
                                      color: Colors.greenAccent,
                                      elevation: 0,
                                      shape: RoundedRectangleBorder(
                                          borderRadius:
                                              BorderRadius.circular(50)),
                                      child: loading == false
                                          ? Text(
                                              "Đăng nhập",
                                              style: TextStyle(
                                                  fontWeight: FontWeight.w600,
                                                  fontSize:
                                                      ScreenUtil().setSp(60)),
                                            )
                                          : Row(
                                              // mainAxisAlignment:
                                              //     MainAxisAlignment.spaceEvenly,
                                              children: [
                                                Padding(
                                                  padding: EdgeInsets.only(left: ScreenUtil().setWidth(350)),
                                                  child: Text("Đăng nhập",
                                                      style: TextStyle(
                                                          fontWeight:
                                                              FontWeight.w600,
                                                          fontSize: ScreenUtil()
                                                              .setSp(50))),
                                                ),
                                                SizedBox(
                                                     width:     ScreenUtil()
                                                        .setWidth(150)),
                                                CircularProgressIndicator(),
                                              ],
                                            ),
                                    ),
                                  ),
                                )),
                          ],
                        ),
                      ),
                      FadeAnimation(
                          1.2,
                          Container(
                            height: ScreenUtil().screenHeight / 3,
                            decoration: BoxDecoration(
                                image: DecorationImage(
                                    image: AssetImage('assets/background.png'),
                                    fit: BoxFit.cover)),
                          ))
                    ],
                  ),
                ),
                onWillPop: () async => false));
      },
    ));
  }

  Widget makeInput({label, controller, obscureText = false}) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Text(
          label,
          style: TextStyle(
              fontSize: 15, fontWeight: FontWeight.w400, color: Colors.black87),
        ),
        SizedBox(
          height: 5,
        ),
        TextField(
          obscureText: label != "Tài khoản" ? _obscureTextPassword : false,
          controller: controller,
          onChanged: (value) {
            checkValidation();
          },
          decoration: InputDecoration(
            contentPadding: EdgeInsets.symmetric(vertical: 0, horizontal: 10),
            enabledBorder: OutlineInputBorder(
                borderSide: BorderSide(color: Colors.grey[400])),
            border: OutlineInputBorder(
                borderSide: BorderSide(color: Colors.grey[400])),
            suffixIcon: label != "Tài khoản"
                ? IconButton(
                    icon: obscureText
                        ? Icon(Icons.remove_red_eye)
                        : Icon(Icons.visibility_off),
                    onPressed: _showOrHidePassword)
                : null,
          ),
        ),
        SizedBox(
          height: ScreenUtil().setHeight(30),
        ),
      ],
    );
  }
}
