import 'package:flutter/cupertino.dart';

class ScreenSize {
  static double appBarHeight = 46.0;

  static double getWidth(BuildContext context) {
    return MediaQuery.of(context).size.width;
  }

  static double getFullHeight(BuildContext context) {
    return MediaQuery.of(context).size.height;
  }

  static double getPaddingTop(BuildContext context) {
    return MediaQuery.of(context).padding.top;
  }

  static double getPaddingBottom(BuildContext context) {
    return MediaQuery.of(context).padding.bottom;
  }

  static double getHeightWithoutStatusBar(BuildContext context) {
    return getFullHeight(context) - getPaddingTop(context);
  }

  static double getHeightWithOutStatusAndAppBar(BuildContext context) {
    return getFullHeight(context) - getPaddingTop(context) - appBarHeight;
  }
}
