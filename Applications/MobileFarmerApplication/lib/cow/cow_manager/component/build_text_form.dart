  import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

typedef SetTextFuction = Function({String value, String title});
Widget buildTextForm({hint, validatorText, nameController, codeController, width, SetTextFuction setTextFuction}) {
    return Padding(
        padding: EdgeInsets.only(
          top: ScreenUtil().setSp(20.0),
        ),
        child: Container(
          height: ScreenUtil().setHeight(300.0),
          width: hint == "Mã bò" ? width / ScreenUtil().setWidth(15) : width,
          child: TextFormField(
            controller: hint == "Mã bò" ? codeController : nameController,
            decoration: InputDecoration(
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xff9CCC65)),
                  //borderRadius: BorderRadius.all(Radius.circular(30)),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xff9CCC65)),
                  borderRadius: BorderRadius.all(Radius.circular(ScreenUtil().setSp(40.0),)),
                ),
                hintText: hint),
            maxLength: hint == "Mã bò" ? 3 : 10,
            validator: (String value) {
              if (value.isEmpty) {
                return validatorText;
              }
              return null;
            },
            onSaved: (String value) {
             setTextFuction(value: value, title: hint);
            },
          ),
        ));
  }