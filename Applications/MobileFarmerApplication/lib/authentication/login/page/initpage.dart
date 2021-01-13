import 'dart:async';

import 'package:AgrifoodApp/authentication/bloc/authentication.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_cubit.dart';
import 'package:AgrifoodApp/authentication/login/component/login_form.dart';
import 'package:AgrifoodApp/authentication/login/login_bloc.dart';
import 'package:AgrifoodApp/authentication/login/login_event.dart';
import 'package:AgrifoodApp/authentication/signup/component/verification_phoneNumber_component.dart';
import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:AgrifoodApp/respository/register_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

class InitPage extends StatefulWidget {
  final AuthenticationRepository authenticationRepository;

  const InitPage({Key key, this.authenticationRepository}) : super(key: key);

  @override
  _InitPageState createState() => _InitPageState();
}

class _InitPageState extends State<InitPage> {
  Timer timer;
  @override
  void initState() {
    super.initState();
    timer = new Timer(new Duration(seconds: 1), () {
      timer = new Timer(new Duration(seconds: 2), () {
        BlocProvider.of<AuthenticationBloc>(context).add(RedirectToLoginPage());
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    AuthenticationRepository authenticationRepository =
        new AuthenticationRepository();
    return Scaffold(
      body: SafeArea(
        child: Container(
          width: double.infinity,
          height: MediaQuery.of(context).size.height,
          padding: EdgeInsets.symmetric(horizontal: 30, vertical: 50),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              Column(
                children: <Widget>[
                  FadeAnimation(
                      1,
                      Text(
                        "Chào mừng",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 30),
                      )),
                  SizedBox(
                    height: 20,
                  ),
                  FadeAnimation(
                      1.2,
                      Text(
                        "Agrifood Bạn của nhà nông, chúng tôi sẽ đem lại chất lượng giống tốt nhất cho bạn",
                        textAlign: TextAlign.center,
                        style: TextStyle(color: Colors.grey[700], fontSize: 15),
                      )),
                ],
              ),
              FadeAnimation(
                  1.4,
                  Container(
                    height: MediaQuery.of(context).size.height / 3,
                    decoration: BoxDecoration(
                        shape: BoxShape.circle,
                        // color: Colors.blue,
                        boxShadow: [
                          BoxShadow(
                            color: Colors.green[200], // darker color
                          ),
                          BoxShadow(
                            color: Color(0xffe0e5ec), // background color
                            spreadRadius: -12.0,
                            blurRadius: 12.0,
                          ),
                        ],
                        image: DecorationImage(
                            image: AssetImage('assets/illustration.png'))),
                  )),
              Column(
                children: <Widget>[
                  FadeAnimation(
                      1.5,
                      MaterialButton(
                        minWidth: double.infinity,
                        height: 60,
                        onPressed: () {
                          BlocProvider.of<AuthenticationBloc>(context)
                              .add(LoginFormButton());

                          // Navigator.push(
                          //     context,
                          //     MaterialPageRoute(
                          //       builder: (context) => BlocProvider(
                          //           create: (context) {
                          //             return LoginBloc(
                          //               authenticationBloc:
                          //                   BlocProvider.of<AuthenticationBloc>(
                          //                       context),
                          //               authenticationRepository:
                          //                   authenticationRepository,
                          //             );
                          //           },
                          //           child: LoginComponent()),
                          //     ));
                        },
                        shape: RoundedRectangleBorder(
                            side: BorderSide(color: Colors.black),
                            borderRadius: BorderRadius.circular(50)),
                        child: Text(
                          "Đăng nhập",
                          style: TextStyle(
                              fontWeight: FontWeight.w600, fontSize: 18),
                        ),
                      )),
                  // SizedBox(
                  //   height: 20,
                  // ),
                  // FadeAnimation(
                  //     1.6,
                  //     Container(
                  //       padding: EdgeInsets.only(top: 3, left: 3),
                  //       decoration: BoxDecoration(
                  //           borderRadius: BorderRadius.circular(50),
                  //           border: Border(
                  //             bottom: BorderSide(color: Colors.black),
                  //             top: BorderSide(color: Colors.black),
                  //             left: BorderSide(color: Colors.black),
                  //             right: BorderSide(color: Colors.black),
                  //           )),
                  //       child: MaterialButton(
                  //         minWidth: double.infinity,
                  //         height: 60,
                  //         onPressed: () {
                  //           Navigator.push(
                  //               context,
                  //               MaterialPageRoute(
                  //                 builder: (context) => BlocProvider(
                  //                   create: (context) => AuthenticationCubit(RegisterReponsitory()),
                  //                   child: VerificationPhoneCode(),
                  //                 ),
                  //               ));
                  //           //Navigator.push(context, MaterialPageRoute(builder: (context) => VerificationPhoneCode()));
                  //         },
                  //         color: Colors.greenAccent,
                  //         elevation: 0,
                  //         shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(50)),
                  //         child: Text(
                  //           "Đăng kí",
                  //           style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                  //         ),
                  //       ),
                  //     ))
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
