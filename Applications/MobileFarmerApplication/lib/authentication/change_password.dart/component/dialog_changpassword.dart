import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import '../../../ui/utils/color.dart';

Widget dialogChangPassword({BuildContext context, var state}) {
  return AlertDialog(
    shape: RoundedRectangleBorder(
        borderRadius:
            BorderRadius.all(Radius.circular(ScreenUtil().setSp(50)))),
    contentPadding: EdgeInsets.only(top: ScreenUtil().setHeight(70)),
    content: Container(
      width: ScreenUtil().setWidth(500),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.stretch,
        mainAxisSize: MainAxisSize.min,
        children: <Widget>[
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            mainAxisSize: MainAxisSize.max,
            children: <Widget>[
              Text(
                "Thông Báo",
                style: TextStyle(
                  fontSize: ScreenUtil().setSp(70),
                  fontWeight: FontWeight.w500,
                ),
              ),
            ],
          ),
          SizedBox(
            height: ScreenUtil().setHeight(50),
          ),
          Divider(
            color: Colors.grey,
            height: ScreenUtil().setHeight(50),
          ),
          Container(
              width: ScreenUtil().setWidth(50),
              height: ScreenUtil().setHeight(200),
              padding: EdgeInsets.only(
                  //top: ScreenUtil().setHeight(50),
                  left: ScreenUtil().setWidth(50),
                  right: ScreenUtil().setWidth(50)),
              child: Center(
                child: Text(state.result,
                    style: TextStyle(fontSize: ScreenUtil().setSp(55))),
              )),
          InkWell(
            //mouseCursor: MouseCursor(),
            onTap: () {
              if (state.result == "Đổi mật khẩu thành công") {
                Navigator.pushReplacementNamed(context, "/");
              } else {
                Navigator.pop(context);
              }
            },
            child: Container(
                height: 40,
                padding: EdgeInsets.only(
                    top: ScreenUtil().setHeight(50),
                    bottom: ScreenUtil().setHeight(50)),
                decoration: BoxDecoration(
                  color: colorApp,
                  borderRadius: BorderRadius.only(
                      bottomLeft: Radius.circular(ScreenUtil().setSp(50)),
                      bottomRight: Radius.circular(ScreenUtil().setSp(50))),
                ),
                child: Center(
                  child: Text('Trở về',
                      style: TextStyle(
                          color: Colors.white,
                          fontSize: ScreenUtil().setSp(50),
                          fontWeight: FontWeight.w700,
                          )),
                )),
          ),
        ],
      ),
    ),
  );
}

Widget textForm(
    {controller,
    void showPassword(String title),
    text,
    obscureText,
    labelText}) {
  return TextFormField(
    enableInteractiveSelection: false,
    controller: controller,
    validator: (value) {
      if (value.isEmpty) {
        return "Không được bỏ trống";
      }
      return null;
    },
    obscureText: obscureText,
    decoration: InputDecoration(
      border: OutlineInputBorder(
          borderSide: BorderSide(
              color: Color(0xffCED0D2), width: ScreenUtil().setWidth(1000)),
          borderRadius:
              BorderRadius.all(Radius.circular(ScreenUtil().setSp(60)))),
      labelText: labelText,
      suffixIcon: IconButton(
          icon: obscureText
              ? Icon(Icons.remove_red_eye)
              : Icon(Icons.visibility_off),
          onPressed: () => showPassword(text)),
    ),
  );
}
