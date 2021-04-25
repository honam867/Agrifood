import 'dart:io';
import 'package:AgrifoodApp/history/bloc/history_bloc.dart';
import 'package:AgrifoodApp/history/component/colors.dart';
import 'package:AgrifoodApp/history/component/custom_splash.dart';
import 'package:AgrifoodApp/history/component/floating_button.dart';
import 'package:AgrifoodApp/history/component/item_history.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:date_picker_timeline/date_picker_timeline.dart' as prefix;
//import 'package:flutter_screenutil/flutter_screenutil.dart';

final String defaultLocale = Platform.localeName;

class DailyPage extends StatefulWidget {
  @override
  _DailyPageState createState() => _DailyPageState();
}

class _DailyPageState extends State<DailyPage>
    with AutomaticKeepAliveClientMixin {
  var top = 0.0;
  ScrollController _scrollController = new ScrollController();
  final _formKey = new GlobalKey<FormState>();
  int indexTab = 0;
  bool lastStatus = true;
  prefix.DatePickerController _controller = prefix.DatePickerController();
  double offset = 0.0;
  _scrollListener() {
    if (isShrink != lastStatus) {
      setState(() {
        lastStatus = isShrink;
        //_scrollController.jumpTo(50.0);
      });
    }
    if (_scrollController.position.pixels == 0.0) {
      setState(() {
        _controller.animateToDate(selectedValue);
        _controller.animateToSelection(
            duration: Duration(microseconds: 500), curve: Curves.bounceIn);
      });
    }
  }

  void refeshList({DateTime getDate, int session}) {
    BlocProvider.of<HistoryBloc>(context)
      ..add(HistoryLoadedSucces(
          day: getDate.day,
          month: getDate.month,
          year: getDate.year,
          session: session));
  }

  bool get isShrink {
    return _scrollController.hasClients &&
        _scrollController.offset > (205 - kToolbarHeight);
  }

  DateTime selectedValue = DateTime.now();

  void initState() {
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _controller.animateToDate(selectedValue);
    });
    _scrollController.addListener(_scrollListener);
    super.initState();
  }

  @override
  void dispose() {
    _scrollController.removeListener(_scrollListener);
    super.dispose();
  }

  int activeDay = 3;
  static DateTime current = DateTime.now();
  DateTime selectStartDate = DateTime(
    current.year,
    current.month - 1,
  );

  static int daysInEnd(DateTime date) {
    var firstDayThisMonth = new DateTime(date.year, date.month, date.day);
    var firstDayNextMonth =
        new DateTime(current.year, current.month, current.day + 1);
    print(firstDayNextMonth.difference(firstDayThisMonth).inDays);
    return firstDayNextMonth.difference(firstDayThisMonth).inDays;
  }

  @override
  Widget build(BuildContext context) {
    super.build(context);
    return DefaultTabController(
        initialIndex: 0,
        length: 2,
        child: SafeArea(
          child: Scaffold(
              floatingActionButton: FloatingButtonMiking(),
              backgroundColor: Colors.green[100],
              body: BlocBuilder<HistoryBloc, HistoryState>(
                builder: (context, state) {
                  return CustomScrollView(
                      controller: _scrollController,
                      slivers: <Widget>[
                        SliverAppBar(
                            leading: IconButton(
                              icon: Icon(
                                Icons.arrow_back_ios,
                                color: Colors.black,
                              ),
                              onPressed: () => Navigator.pop(context),
                            ),
                            title: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                title(),
                                IconButton(
                                  icon: Icon(
                                    Icons.calendar_today,
                                    color: Colors.black,
                                  ),
                                  onPressed: () {
                                    DatePicker.showDatePicker(context,
                                        showTitleActions: true,
                                        minTime: DateTime(current.year - 1,
                                            current.month - 2, current.day),
                                        maxTime: DateTime(current.year,
                                            current.month - 1, 30),
                                        theme: DatePickerTheme(
                                            headerColor: Colors.transparent,
                                            backgroundColor: Colors.white,
                                            itemStyle: TextStyle(
                                                color: Colors.black,
                                                fontWeight: FontWeight.bold,
                                                fontSize: 18),
                                            doneStyle: TextStyle(
                                                color: Colors.blue,
                                                fontSize: 16)),
                                        onChanged: (date) {},
                                        onConfirm: (date) {
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
                            pinned: true,
                            expandedHeight: 205.0,
                            backgroundColor: colorApp,
                            bottom: PreferredSize(
                              preferredSize: Size.fromHeight(50),
                              child: TabBar(
                                onTap: (int index) {
                                  indexTab = index == 0 ? 0 : 1;
                                  refeshList(
                                      getDate: selectedValue,
                                      session: indexTab);
                                },
                                labelColor: Colors.black87,
                                tabs: [
                                  Tab(child: tabTille(title: "Sáng")),
                                  Tab(child: tabTille(title: "Tối")),
                                ],
                              ),
                            ),
                            flexibleSpace: LayoutBuilder(
                              builder: (context, constraints) {
                                top = constraints.biggest.height;
                                return FlexibleSpaceBar(
                                  background: top > 56 && top > 110
                                      ? Container(
                                          decoration: BoxDecoration(
                                              color: white,
                                              boxShadow: [
                                                BoxShadow(
                                                  color: grey.withOpacity(0.01),
                                                  spreadRadius: 10,
                                                  blurRadius: 3,
                                                  // changes position of shadow
                                                ),
                                              ]),
                                          child: Padding(
                                            padding: const EdgeInsets.only(
                                                top: 40,
                                                right: 20,
                                                left: 20,
                                                bottom: 25),
                                            child: Column(
                                              children: [
                                                SizedBox(
                                                  height: 25,
                                                ),
                                                prefix.DatePicker(
                                                  selectStartDate,
                                                  locale: "vi",
                                                  key: _formKey,
                                                  selectionColor: Colors.blue,
                                                  controller: _controller,
                                                  daysCount: daysInEnd(
                                                              selectStartDate) ==
                                                          0
                                                      ? 30
                                                      : daysInEnd(
                                                          selectStartDate),
                                                  initialSelectedDate:
                                                      DateTime.now(),
                                                  onDateChange: (date) {
                                                    setState(() {
                                                      this.selectedValue = date;
                                                      _controller
                                                          .animateToDate(date);
                                                      refeshList(
                                                          getDate:
                                                              selectedValue,
                                                          session: indexTab);
                                                    });
                                                  },
                                                ),
                                              ],
                                            ),
                                          ),
                                        )
                                      : Container(
                                          height: 50,
                                          color: colorApp,
                                        ),
                                );
                              },
                            )),
                        SliverList(
                          delegate: SliverChildBuilderDelegate(
                            (BuildContext context, int index1) {
                              if (state is HistoryLoadInprocess) {
                                BlocProvider.of<HistoryBloc>(context)
                                  ..add(HistoryLoadedSucces(
                                      day: current.day,
                                      month: current.month,
                                      year: current.year,
                                      session: 0));
                              }
                              if (state is HistoryLoading) {
                                return CustomSplashPage();
                              }
                              if (state is HistoryLoaded) {
                                var list =
                                    state.historyModel.milkingSlipDetaiItem;
                                return list.length > 0
                                    ? SingleChildScrollView(
                                        child: Column(
                                          children: [
                                            Container(
                                              padding: EdgeInsets.only(top: 20),
                                              child: ListView.builder(
                                                shrinkWrap: true,
                                                physics:
                                                    NeverScrollableScrollPhysics(),
                                                itemCount: list.length,
                                                itemBuilder: (context, index) {
                                                  return ListTile(
                                                    title: ItemHistory(
                                                      list: list[index],
                                                    ),
                                                  );
                                                },
                                              ),
                                            )
                                          ],
                                        ),
                                      )
                                    : CustomNondataSizeBox();
                              }
                              return CustomSplashPage();
                            },
                            childCount: 1,
                          ),
                        )
                      ]);
                },
              )),
        ));
  }

  @override
  bool get wantKeepAlive => true;
}
