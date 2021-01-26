import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

typedef SelectRadioFunction = Function({int val,String title});
Widget buildGender({selectedRadio, SelectRadioFunction selectRadioFunction}) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.start,
      children: <Widget>[
        ButtonBar(
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
                  activeColor: Color(0xFF26A69A),
                  onChanged: (val) {
                    selectRadioFunction(val: val, title: "Đực");
                    print("Radio $val");
                  },
                ),
              ],
            ),
            Row(
              children: [
                Text("Cái", style: TextStyles.valueTextStyle),
                Radio(
                  value: 2,
                  groupValue: selectedRadio,
                  activeColor: Color(0xFF26A69A),
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