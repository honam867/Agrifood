import 'dart:io';
import 'package:AgrifoodApp/history/component/colors.dart';
import 'package:AgrifoodApp/history/model/daily_json.dart';
import 'package:flutter/material.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:date_picker_timeline/date_picker_timeline.dart' as prefix;

final String defaultLocale = Platform.localeName;

class DailyPage extends StatefulWidget {
  @override
  _DailyPageState createState() => _DailyPageState();
}

class _DailyPageState extends State<DailyPage> {
  prefix.DatePickerController _controller = prefix.DatePickerController();
  void initState() {
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _controller.animateToDate(DateTime.now());
    });
    super.initState();
  }

  int activeDay = 3;
  static DateTime current = DateTime.now();
  DateTime selectStartDate = DateTime(
    current.year,
    current.month - 1,
  );

  DateTime _selectedValue = DateTime.now();
  static int daysInEnd(DateTime date) {
    var firstDayThisMonth = new DateTime(date.year, date.month, date.day);
    var firstDayNextMonth =
        new DateTime(current.year, current.month, current.day + 1);
    print(firstDayNextMonth.difference(firstDayThisMonth).inDays);
    return firstDayNextMonth.difference(firstDayThisMonth).inDays;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.green[100],
      body: getBody(),
    );
  }

  Widget getBody() {
    var size = MediaQuery.of(context).size;
    return SingleChildScrollView(
      child: Column(
        children: [
          Container(
            decoration: BoxDecoration(color: white, boxShadow: [
              BoxShadow(
                color: grey.withOpacity(0.01),
                spreadRadius: 10,
                blurRadius: 3,
                // changes position of shadow
              ),
            ]),
            child: Padding(
              padding: const EdgeInsets.only(
                  top: 60, right: 20, left: 20, bottom: 25),
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        "Thống kê",
                        style: TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                            color: black),
                      ),
                      IconButton(
                        icon: Icon(Icons.calendar_today),
                        onPressed: () {
                          DatePicker.showDatePicker(context,
                              showTitleActions: true,
                              minTime: DateTime(current.year - 1,
                                  current.month - 2, current.day),
                              maxTime: DateTime(
                                  current.year, current.month - 1, current.day),
                              theme: DatePickerTheme(
                                  headerColor: Colors.orange,
                                  backgroundColor: Colors.blue,
                                  itemStyle: TextStyle(
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 18),
                                  doneStyle: TextStyle(
                                      color: Colors.white,
                                      fontSize: 16)), onChanged: (date) {
                            print('change $date in time zone ' +
                                date.timeZoneOffset.inHours.toString());
                          }, onConfirm: (date) {
                            setState(() {
                              selectStartDate = date;
                            });
                          },
                              currentTime: DateTime.now(),
                              locale: LocaleType.vi);
                        },
                      )
                    ],
                  ),
                  SizedBox(
                    height: 25,
                  ),
                  prefix.DatePicker(
                    selectStartDate,
                    locale: "vi",
                    selectionColor: Colors.blue,
                    controller: _controller,
                    daysCount: daysInEnd(selectStartDate) == 0
                        ? 30
                        : daysInEnd(selectStartDate),
                    initialSelectedDate: DateTime.now(),
                    onDateChange: (date) {
                      // New date selected
                      setState(() {
                        _selectedValue = date;
                        _controller.animateToDate(date);
                      });
                    },
                  ),
                ],
              ),
            ),
          ),
          SizedBox(
            height: 30,
          ),
          Padding(
            padding: const EdgeInsets.only(left: 20, right: 20),
            child: Column(
                children: List.generate(daily.length, (index) {
              return Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Container(
                        width: (size.width - 40) * 0.7,
                        child: Row(
                          children: [
                            Container(
                              width: 50,
                              height: 50,
                              decoration: BoxDecoration(
                                shape: BoxShape.circle,
                                color: grey.withOpacity(0.1),
                              ),
                              child: Center(
                                child: Image.asset(
                                  daily[index]['icon'],
                                  width: 30,
                                  height: 30,
                                ),
                              ),
                            ),
                            SizedBox(width: 15),
                            Container(
                              width: (size.width - 90) * 0.5,
                              child: Column(
                                mainAxisAlignment: MainAxisAlignment.center,
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Text(
                                    daily[index]['name'],
                                    style: TextStyle(
                                        fontSize: 15,
                                        color: black,
                                        fontWeight: FontWeight.w500),
                                    overflow: TextOverflow.ellipsis,
                                  ),
                                  SizedBox(height: 5),
                                  Text(
                                    daily[index]['date'],
                                    style: TextStyle(
                                        fontSize: 12,
                                        color: black.withOpacity(0.5),
                                        fontWeight: FontWeight.w400),
                                    overflow: TextOverflow.ellipsis,
                                  ),
                                ],
                              ),
                            )
                          ],
                        ),
                      ),
                      Container(
                        width: (size.width - 40) * 0.3,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: [
                            Text(
                              daily[index]['price'],
                              style: TextStyle(
                                  fontWeight: FontWeight.w600,
                                  fontSize: 15,
                                  color: Colors.green),
                            ),
                          ],
                        ),
                      )
                    ],
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 65, top: 8),
                    child: Divider(
                      thickness: 0.8,
                    ),
                  )
                ],
              );
            })),
          ),
          SizedBox(
            height: 15,
          ),
          Padding(
            padding: const EdgeInsets.only(left: 20, right: 20),
            child: Row(
              children: [
                Spacer(),
                Padding(
                  padding: const EdgeInsets.only(right: 80),
                  child: Text(
                    "Total",
                    style: TextStyle(
                        fontSize: 16,
                        color: black.withOpacity(0.4),
                        fontWeight: FontWeight.w600),
                    overflow: TextOverflow.ellipsis,
                  ),
                ),
                Spacer(),
                Padding(
                  padding: const EdgeInsets.only(top: 5),
                  child: Text(
                    "\$1780.00",
                    style: TextStyle(
                        fontSize: 20,
                        color: black,
                        fontWeight: FontWeight.bold),
                    overflow: TextOverflow.ellipsis,
                  ),
                ),
              ],
            ),
          )
        ],
      ),
    );
  }
}
