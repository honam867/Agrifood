import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';

class DatePickerThemeCustomer {
  static DatePickerTheme datePickerThemeCus = new DatePickerTheme(
      headerColor: Colors.transparent,
      backgroundColor: Colors.white,
      itemStyle: TextStyle(
          color: Colors.black, fontWeight: FontWeight.bold, fontSize: 18),
      doneStyle: TextStyle(color: Colors.blue, fontSize: 16));
}
