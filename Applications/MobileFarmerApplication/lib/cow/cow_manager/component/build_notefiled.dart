import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

typedef SetTextFuction = Function({String value, String title});
Widget buildTextFormNote(
    {hint,
    validatorText,
    nameController,
    noteController,
    width,
    SetTextFuction setTextFuction}) {
  return Padding(
      padding: EdgeInsets.only(
        top: ScreenUtil().setSp(20.0),
      ),
      child: Container(
        height: ScreenUtil().setHeight(300.0),
        width:  ScreenUtil().setWidth(1000.0),
        child: TextFormField(
          controller: noteController,
          decoration: InputDecoration(
            isDense: true,
            contentPadding: EdgeInsets.fromLTRB(10, 10, 10, 50),
            enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xff9CCC65)),
              //borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            focusedBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xff9CCC65)),
              borderRadius: BorderRadius.all(Radius.circular(
                ScreenUtil().setSp(40.0),
              )),
            ),
          ),
          maxLength: 20,
          onSaved: (String value) {
            setTextFuction(value: value, title: hint);
          },
        ),
      ));
}
