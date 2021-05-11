import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/screen_util.dart';

class ButtonSend extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
        color: Colors.lightGreen[50],
        width: MediaQuery.of(context).size.width,
        height: MediaQuery.of(context).size.height,
        child: Padding(
            padding: EdgeInsets.only(
                top: ScreenUtil().setHeight(20.0),
                bottom: ScreenUtil().setHeight(20.0),
                left: ScreenUtil().setHeight(20.0),
                right: ScreenUtil().setHeight(20.0)),
            child: Column(
              children: [
                Container(
                  padding: EdgeInsets.only(top: 20.0),
                  child: OutlinedButton(
                    onPressed: () {},
                    style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.resolveWith<Color>(
                        (Set<MaterialState> states) {
                          if (states.contains(MaterialState.pressed))
                            return Colors.green[300];
                          return colorApp; // Use the component's default.
                        },
                      ),
                      shape: MaterialStateProperty.all(RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0))),
                    ),
                    child: Text(
                      "Gửi",
                      style: TextStyle(
                          fontSize: ScreenUtil().setSp(80),
                          color: Colors.white),
                    ),
                  ),
                ),
              ],
            )));
  }
}
