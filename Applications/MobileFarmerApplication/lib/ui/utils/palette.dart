import 'package:flutter/cupertino.dart';

class Palette {
  static const paleGrey = const Color.fromRGBO(222, 225, 237, 1);
  static const skyBlue = const Color(0xff52b9ff);
  static const white = const Color(0xffeeeeee);
  static const dark = const Color(0xff24253d);
  static const dodgerBlue = const Color(0xff2ea3f2);
  static const dark60 = const Color(0x9924253d);
  static const emerald = const Color(0xff009c41);
  static const red = const Color(0xffdd0000);
  static const coolGrey = const Color(0xff9294a0);
  static const birthColor = const Color(0xff9CCC65);

  static const defaultColor = const Color.fromRGBO(255, 255, 255, 1);
  static const yellow = const Color.fromRGBO(255, 255, 0, 1);
  static const silver = const Color.fromRGBO(192, 192, 192, 1);
  static const lightSalmon = const Color.fromRGBO(255, 160, 122, 1);
  static const aqua = const Color.fromRGBO(0, 255, 255, 1);
  static const green = const Color.fromRGBO(0, 128, 0, 1);

  static const mainColor = const Color.fromRGBO(0, 87, 144, 1);
  static const mainBackgroundColor = const Color.fromRGBO(0, 153, 255, 1);
  static const mainBackgroundColorLight = const Color.fromRGBO(179, 224, 255, 1);

  static const activeLinearGradient = const LinearGradient(
    begin: Alignment.topCenter,
    end: Alignment.bottomCenter,
    colors: [
      const Color.fromRGBO(0, 87, 144, 1),
      const Color.fromRGBO(26, 163, 255, 1),
    ],
  );
}
