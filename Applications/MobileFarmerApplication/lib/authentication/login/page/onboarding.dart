import 'dart:async';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../authentication.dart';
import '../../authentication_event.dart';


class OnBoardingPage extends StatefulWidget {
  @override
  _OnBoardingPageState createState() => _OnBoardingPageState();
}

class _OnBoardingPageState extends State<OnBoardingPage> {
  double _width = 144;
  double _height = 144;

  Timer timer;
  @override
  void initState() {
    super.initState();
    timer = new Timer(new Duration(seconds: 1), () {
      setState(() {
        _width = 96;
        _height = 96;
      });
      timer = new Timer(new Duration(seconds: 2), () {
        BlocProvider.of<AuthenticationBloc>(context).add(RedirectToLoginPage());
      });
    });
  }

  @override
  void dispose() {
    super.dispose();
    timer.cancel();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        body: Center(
          child: AnimatedContainer(
            child: Image(
              image: AssetImage('image/ic_launcher.png'),
              width: _width,
              height: _height,
              fit: BoxFit.contain,
            ),
            width: _width,
            height: _height,
            duration: Duration(seconds: 2),
            curve: Curves.fastOutSlowIn,
          ),
        ),
      ),
    );
  }
}
