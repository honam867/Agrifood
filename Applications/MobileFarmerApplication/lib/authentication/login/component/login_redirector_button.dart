import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../../ui/utils/palette.dart';

class LoginRedirectorButton extends StatelessWidget {
  final VoidCallback onPress;

  const LoginRedirectorButton({
    Key key,
    this.onPress,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
          borderRadius: BorderRadius.all(
            Radius.circular(27),
          ),
          color: Colors.red,
          border: Border.all(
            color: Palette.white,
            width: 1,
          )),
      child: OutlineButton(
        color: Colors.white,
        shape: new RoundedRectangleBorder(
          borderRadius: new BorderRadius.circular(27),
        ),
        onPressed: onPress,
        padding: EdgeInsets.only(
          left: 97,
          top: 16,
          right: 97,
          bottom: 16,
        ),
        child: Text(
          'ĐĂNG NHẬP',
          style: const TextStyle(
            color: Colors.white,
            fontWeight: FontWeight.w700,
            fontFamily: "MyriadPro",
            fontStyle: FontStyle.normal,
            fontSize: 20.0,
          ),
          textAlign: TextAlign.center,
        ),
      ),
    );
  }
}
