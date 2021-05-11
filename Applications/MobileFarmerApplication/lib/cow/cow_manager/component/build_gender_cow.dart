import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

typedef SelectRadioFunction = Function({int val, String title});
Widget buildGender({selectedRadio, SelectRadioFunction selectRadioFunction}) {
  return Column(
    crossAxisAlignment: CrossAxisAlignment.center,
    mainAxisAlignment: MainAxisAlignment.spaceBetween,
    children: <Widget>[
      ButtonBar(
        mainAxisSize: MainAxisSize.max,
        alignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            "Giới tính",
            style: TextStyles.labelTextStyle,
          ),
          Row(
            children: [
              Text(
                "Đực",
                style: TextStyles.valueTextStyle,
              ),
              Radio(
                value: 1,
                groupValue: selectedRadio,
                activeColor: Color(0xff9CCC65),
                onChanged: (val) {
                  selectRadioFunction(val: val, title: "Đực");
                  print("Radio $val");
                },
              ),
            ],
          ),
          Row(
            children: [
              Text(
                "Cái", 
                style: TextStyles.valueTextStyle
              ),
              Radio(
                value: 2,
                groupValue: selectedRadio,
                activeColor: Color(0xff9CCC65),
                onChanged: (val) {
                  selectRadioFunction(val: val, title: "Cái");
                  print("Radio $val");
                },
              ),
            ],
          ),
        ],
      ),
    ],
  );
}
