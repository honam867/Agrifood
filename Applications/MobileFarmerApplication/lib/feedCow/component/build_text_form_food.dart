import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

typedef SetTextFuction = Function({String value, String title});
Widget buildTextFormFood({hint, validatorText, nameController, codeController, width, SetTextFuction setTextFuction}) {
    return Padding(
        padding: EdgeInsets.only(
          top: ScreenUtil().setSp(50.0),
        ),
        child: Container(
          height: ScreenUtil().setHeight(200.0),
          width: hint == "Kg" ? width / ScreenUtil().setWidth(15) : width,
          child: TextFormField(
            controller: hint == "Kg" ? codeController : nameController,
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
            maxLength:   3 ,
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