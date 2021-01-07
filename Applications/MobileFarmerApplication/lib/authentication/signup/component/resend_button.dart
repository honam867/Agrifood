import 'dart:async';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import '../../login/component/fadeanimation.dart';
import 'package:AgrifoodApp/ui/utils/palette.dart';




class ResendButton extends StatefulWidget {
  final VoidCallback onPress;
  final bool isDisable;
  const ResendButton({
    Key key,
    this.onPress,
    this.isDisable: false,
  }) : super(key: key);
  @override
  _ResendButtonState createState() => _ResendButtonState();
}

class _ResendButtonState extends State<ResendButton> {

   String resendText = "Gửi lại";

  Timer _timer;
int _start = 10;
@override
void dispose() {
  _timer.cancel();
  super.dispose();
}
void startTimer() {
  const oneSec = const Duration(seconds: 1);
  _timer = new Timer.periodic(
    oneSec,
    (Timer timer) => setState(
      () {
        if (_start < 1) {
          timer.cancel();
        } else {
          _start = _start - 1;
        }
      },
    ),
  );
}

  @override
  Widget build(BuildContext context) {
    return FadeAnimation(
        1.9,
        Container(
          height: 50,
          padding: EdgeInsets.fromLTRB(0, 0, 0, 0),
          margin: EdgeInsets.symmetric(horizontal: 120),
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.circular(50),
            gradient: !widget.isDisable ? Palette.activeLinearGradient : null,
          ),
          child: Center(
            child: InkWell(
              onTap: !widget.isDisable ? widget.onPress : null,
              child: Text(
               resendText,
                style: TextStyle(color: Colors.white),
              ),
            ),
          ),
        ));
  }
}

class ConfirmButton extends StatefulWidget {
  final VoidCallback onPress;
  final bool isDisable;
  const ConfirmButton({
    Key key,
    this.onPress,
    this.isDisable: false,
  }) : super(key: key);
  @override
  _ConfirmButtonState createState() => _ConfirmButtonState();
}

class _ConfirmButtonState extends State<ConfirmButton> {

   String resendText = "Xác nhận";

  Timer _timer;
int _start = 10;
@override
void dispose() {
  _timer.cancel();
  super.dispose();
}
void startTimer() {
  const oneSec = const Duration(seconds: 1);
  _timer = new Timer.periodic(
    oneSec,
    (Timer timer) => setState(
      () {
        if (_start < 1) {
          timer.cancel();
        } else {
          _start = _start - 1;
        }
      },
    ),
  );
}

  @override
  Widget build(BuildContext context) {
    return FadeAnimation(
        1.9,
        Container(
          height: 50,
          padding: EdgeInsets.fromLTRB(0, 0, 0, 0),
          margin: EdgeInsets.symmetric(horizontal: 120),
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.circular(50),
            gradient: !widget.isDisable ? Palette.activeLinearGradient : null,
          ),
          child: Center(
            child: InkWell(
              onTap: !widget.isDisable ? widget.onPress : null,
              child: Text(
               resendText,
                style: TextStyle(color: Colors.white),
              ),
            ),
          ),
        ));
  }
}
