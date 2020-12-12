import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import '../../../ui/utils/palette.dart';
import 'fadeanimation.dart';

class LoginButton extends StatefulWidget {
  final VoidCallback onPress;
  final bool isDisable;
  const LoginButton({
    Key key,
    this.onPress,
    this.isDisable: false,
  }) : super(key: key);
  @override
  _LoginButtonState createState() => _LoginButtonState();
}

class _LoginButtonState extends State<LoginButton> {
  @override
  Widget build(BuildContext context) {
    return FadeAnimation(
        1.9,
        Center(
            child: Container(
                height: 50.0,
                width: 250.0,
                child: RaisedButton(
                    onPressed: !widget.isDisable ? widget.onPress : null,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(80.0)),
                    padding: EdgeInsets.all(0.0),
                    child: Ink(
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(30.0),
                          color: Color.fromRGBO(49, 39, 79, 1),
                        
                          gradient: !widget.isDisable
                              ? Palette.activeLinearGradient
                              : null,
                        ),
                        child: Container(
                            constraints: BoxConstraints(
                                maxWidth: 300.0, minHeight: 50.0),
                            alignment: Alignment.center,
                            child: Text(
                              "Login",
                              textAlign: TextAlign.center,
                              style: TextStyle(color: Colors.white),
                            )))))));
  }
}
