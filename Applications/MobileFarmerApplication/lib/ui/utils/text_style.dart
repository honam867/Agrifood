import 'package:AgrifoodApp/ui/utils/size_config.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:AgrifoodApp/ui/utils/palette.dart';

class TextStyles {
  static final TextStyle titleText = TextStyle(
    color: Colors.black,
    fontWeight: FontWeight.w700,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 3.5 * SizeConfig.textMultiplier,
  );
  static const linkStyle = const TextStyle(
    color: Palette.dodgerBlue,
    fontWeight: FontWeight.w600,
    fontFamily: "MyriadPro",
    fontStyle: FontStyle.normal,
    fontSize: 16.0,
  );
  static const detailStyle = const TextStyle(
    color: Palette.coolGrey,
    fontWeight: FontWeight.w600,
    fontFamily: "MyriadPro",
    fontStyle: FontStyle.normal,
    fontSize: 16.0,
  );

  static const textIconStyle = const TextStyle(
    color: Colors.white,
    fontWeight: FontWeight.w400,
    fontFamily: "MyriadPro",
    fontStyle: FontStyle.normal,
    fontSize: 14.0,
  );

  static const defaultStyle = const TextStyle(
    color: Colors.white,
    fontWeight: FontWeight.w400,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 12.0,
  );

  static const boldStyle = const TextStyle(
    color: Colors.white,
    fontWeight: FontWeight.w700,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 14.0,
  );

  static const labelTextStyle = TextStyle(
    color: Palette.dark,
    fontWeight: FontWeight.bold,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 15.0,
  );

  static const valueTextStyle = TextStyle(
    color: Palette.dark,
    fontWeight: FontWeight.w400,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 20.0,
  );

  static const headerTextStyle = TextStyle(
    color: Palette.dark,
    fontWeight: FontWeight.w400,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 20.0,
  );

  static const valueTextStylePayslip = TextStyle(
    color: Palette.dark,
    fontWeight: FontWeight.w400,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 14.0,
  );

  static const labelTextStylePayslip = TextStyle(
    color: Palette.dark,
    fontWeight: FontWeight.bold,
    fontFamily: "HelveticaNeue",
    fontStyle: FontStyle.normal,
    fontSize: 17.0,
  );
}
