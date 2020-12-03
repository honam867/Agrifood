import 'package:AgrifoodApp/authentication/login/page/signup.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../main.dart';
import '../../../respository/authentication_repository.dart';
import '../../authentication_bloc.dart';
import '../login_bloc.dart';
import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';

class LoginPage extends StatelessWidget {
  final AuthenticationRepository authenticationRepository;
  final GlobalKey fingerId;

  LoginPage({Key key, @required this.authenticationRepository, this.fingerId})
      : assert(authenticationRepository != null),
        super(key: key);

  Widget horizontalLine() {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 16.0),
      child: Container(
        width: ScreenUtil.getInstance().setWidth(120),
        height: 1.0,
        color: Colors.black26.withOpacity(.2),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[200],
      body: BlocProvider(
          create: (context) {
            return LoginBloc(
              authenticationBloc: BlocProvider.of<AuthenticationBloc>(context),
              authenticationRepository: authenticationRepository,
            );
          },
          child: LoginComponent()),
    );
  }
}

class LoginComponent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
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
                        FadeAnimation(1.2, makeInput(label: "Số điện thoại")),
                        FadeAnimation(1.3, makeInput(label: "Mật khẩu", obscureText: true)),
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
                            onPressed: () {},
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
                            onPressed: () => Navigator.push(context, MaterialPageRoute(builder: (context) => SignupPage())),
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
  }

  Widget makeInput({label, obscureText = false}) {
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
}
