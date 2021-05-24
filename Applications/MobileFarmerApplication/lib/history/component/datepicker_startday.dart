import 'package:AgrifoodApp/history/component/datepicker_custom.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';

import 'icon.dart';


typedef ChangeDateCallback = void Function(DateTime dateTime);
class DatePickerStartDay extends StatefulWidget {
  final ChangeDateCallback changeDateCallback;

  const DatePickerStartDay({Key key, this.changeDateCallback}) : super(key: key);
  @override
  _DatePickerStartDayState createState() => _DatePickerStartDayState();
}

class _DatePickerStartDayState extends State<DatePickerStartDay> {
  static DateTime current = DateTime.now();
  @override
  Widget build(BuildContext context) {
    return IconButton(
        icon: IconDart.calendarToday,
        onPressed: () => DatePicker.showDatePicker(context,
                showTitleActions: true,
                minTime:
                    DateTime(current.year - 1, current.month - 2, current.day),
                maxTime: DateTime(current.year, current.month - 1, 30),
                theme: DatePickerThemeCustomer.datePickerThemeCus,
                onConfirm: (date) {
              setState(() =>  widget.changeDateCallback(date));
            }, currentTime: DateTime.now(), locale: LocaleType.vi));
  }
}
