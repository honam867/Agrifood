import 'package:AgrifoodApp/authentication/login/page/login.dart';
import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
import 'package:AgrifoodApp/authentication/login/page/signup.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

class InitPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    AuthenticationRepository authenticationRepository = new AuthenticationRepository();
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
                        style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30),
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
                        image: DecorationImage(image: AssetImage('assets/illustration.png'))),
                  )),
              Column(
                children: <Widget>[
                  FadeAnimation(
                      1.5,
                      MaterialButton(
                        minWidth: double.infinity,
                        height: 60,
                        onPressed: () {
                          Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => LoginPage(
                                        authenticationRepository: authenticationRepository,
                                      )));
                        },
                        shape: RoundedRectangleBorder(side: BorderSide(color: Colors.black), borderRadius: BorderRadius.circular(50)),
                        child: Text(
                          "Đăng nhập",
                          style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                        ),
                      )),
                  SizedBox(
                    height: 20,
                  ),
                  FadeAnimation(
                      1.6,
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
                          onPressed: () {
                            Navigator.push(context, MaterialPageRoute(builder: (context) => SignupPage()));
                          },
                          color: Colors.greenAccent,
                          elevation: 0,
                          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(50)),
                          child: Text(
                            "Đăng kí",
                            style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
                          ),
                        ),
                      ))
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
