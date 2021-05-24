import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_cmoon_icons/flutter_cmoon_icons.dart';
import 'package:flutter_screenutil/screen_util.dart';

import 'colors.dart';

Widget title() {
  return Text(
    "Thống kê",
    style: TextStyle(
        fontSize: ScreenUtil().setSp(80),
        fontWeight: FontWeight.bold,
        color: black),
  );
}

Row tabTille({title}) {
  return Row(
    mainAxisAlignment: MainAxisAlignment.center,
    children: [
      title == "Sáng"
          ? CIcon(
              IconMoon.icon_sun,
              color: Colors.orangeAccent,
              //size: 20,
            )
          : CIcon(
              IconMoon.icon_cloud_moon,
              color: Colors.blueGrey,
              //size: 20,
            ),
      Padding(
        padding: EdgeInsets.only(
          left: ScreenUtil().setWidth(20),
        ),
        child: Text(title),
      )
    ],
  );
}