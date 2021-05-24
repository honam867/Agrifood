import 'dart:io';
import 'package:AgrifoodApp/core/storage.dart';
import 'package:AgrifoodApp/history/bloc/call_bloc.dart';
import 'package:AgrifoodApp/history/bloc/history_bloc.dart';
import 'package:AgrifoodApp/history/component/colors.dart';
import 'package:AgrifoodApp/history/component/custom_splash.dart';
import 'package:AgrifoodApp/history/component/datepicker_custom.dart';
import 'package:AgrifoodApp/history/component/datepicker_startday.dart';
import 'package:AgrifoodApp/history/component/floating_button.dart';
import 'package:AgrifoodApp/history/component/icon.dart';
import 'package:AgrifoodApp/history/component/item_feed_history.dart';
import 'package:AgrifoodApp/history/component/item_history.dart';
import 'package:AgrifoodApp/history/component/title_tab.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:date_picker_timeline/date_picker_timeline.dart' as prefix;
import 'package:flutter_cmoon_icons/flutter_cmoon_icons.dart';
//import 'package:flutter_screenutil/flutter_screenutil.dart';

final String defaultLocale = Platform.localeName;

class DailyPage extends StatefulWidget {
  @override
  _DailyPageState createState() => _DailyPageState();
}

class _DailyPageState extends State<DailyPage>
    with AutomaticKeepAliveClientMixin {
  var top = 0.0;
  bool isFood = false;
  ScrollController _scrollController = new ScrollController();
  CallBloc callBloc = new CallBloc();
  final _formKey = new GlobalKey<FormState>();
  int indexTab = 0;
  bool lastStatus = true;
  prefix.DatePickerController _controller = prefix.DatePickerController();
  double offset = 0.0;
  int farmerId;
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

  bool get isShrink {
    return _scrollController.hasClients &&
        _scrollController.offset > (205 - kToolbarHeight);
  }

  DateTime selectedValue = DateTime.now();

  void initState() {
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _controller.animateToDate(selectedValue);
      getFarmerId();
    });
    _scrollController.addListener(_scrollListener);
    super.initState();
  }

  void changeDateFuction(DateTime date) {
    setState(() {
      selectStartDate = date;
    });
  }

  void getFarmerId() async {
    farmerId = int.parse(await Storage.getString('farmerId'));
    print(farmerId);
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
  void refeshList({DateTime getDate, int session, bool isFood}) {
    BlocProvider.of<HistoryBloc>(context)
      ..add(HistoryLoadedSucces(
          day: getDate.day,
          month: getDate.month,
          year: getDate.year,
          session: session,
          isFood: isFood,
          farmerId: farmerId));
  }

  @override
  Widget build(BuildContext context) {
    super.build(context);

    return DefaultTabController(
        initialIndex: 0,
        length: 2,
        child: SafeArea(
          child: Scaffold(
              floatingActionButton: FloatingButtonMiking(dateTime: selectedValue ?? DateTime.now(),),
              backgroundColor: Colors.green[100],
              body: BlocConsumer<HistoryBloc, HistoryState>(
                listener: (context, state) {
                  if (state is HistoryButtonClick) {
                    BlocProvider.of<HistoryBloc>(context)
                      ..add(HistoryLoadedSucces(
                          day: state.day,
                          month: state.month,
                          year: state.year,
                          session: state.session,
                          isFood: state.isFood,
                          farmerId: state.farmerId));
                  }
                },
                builder: (context, state) {
                  return CustomScrollView(
                      controller: _scrollController,
                      slivers: <Widget>[
                        SliverAppBar(
                            leading: IconButton(
                              icon: IconDart.iconBack,
                              onPressed: () => Navigator.pop(context),
                            ),
                            title: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                title(),
                                IconButton(
                                    icon: CIcon(
                                      isFood == true ? IconMoon.icon_baidu : IconMoon.icon_about_dot_me,
                                      color: Colors.orangeAccent,
                                      //size: 20,
                                    ),
                                    onPressed: () {
                                      setState(() {
                                        isFood = !isFood;
                                        BlocProvider.of<HistoryBloc>(context)
                                          ..add(OnClickFetchList(
                                              day: selectedValue.day,
                                              month: selectedValue.month,
                                              year: selectedValue.year,
                                              session: indexTab,
                                              isFood: isFood,
                                              farmerId: farmerId));
                                      });
                                    }),
                                DatePickerStartDay(
                                    changeDateCallback: changeDateFuction)
                              ],
                            ),
                            pinned: true,
                            expandedHeight: 205.0,
                            backgroundColor: colorApp,
                            bottom: PreferredSize(
                              preferredSize: Size.fromHeight(50),
                              child: TabBar(
                                onTap: (int index) {
                                  setState(() {
                                    indexTab = index == 0 ? 0 : 1;
                                    BlocProvider.of<HistoryBloc>(context)
                                      ..add(OnClickFetchList(
                                          day: selectedValue.day,
                                          month: selectedValue.month,
                                          year: selectedValue.year,
                                          session: indexTab,
                                          isFood: isFood,
                                          farmerId: farmerId));
                                  });
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
                                                  daysCount: callBloc.daysInEnd(
                                                              selectStartDate,
                                                              current) ==
                                                          0
                                                      ? 30
                                                      : callBloc.daysInEnd(
                                                          selectStartDate,
                                                          current),
                                                  initialSelectedDate:
                                                      DateTime.now(),
                                                  onDateChange: (date) {
                                                    setState(() {
                                                      this.selectedValue = date;
                                                    });
                                                    BlocProvider.of<
                                                        HistoryBloc>(context)
                                                      ..add(OnClickFetchList(
                                                          day:
                                                              selectedValue.day,
                                                          month: selectedValue
                                                              .month,
                                                          year: selectedValue
                                                              .year,
                                                          session: indexTab,
                                                          isFood: isFood,
                                                          farmerId: farmerId));
                                                    _controller
                                                        .animateToDate(date);
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
                              if (state is HistoryLoadInprocess)
                                callBloc.callHistoryAddedNonStatic(
                                    context: context,
                                    current: current,
                                    isFood: isFood);
                              if (state is HistoryLoading) {
                                return CustomSplashPage();
                              }
                              if (state is HistoryLoaded) {
                                var list = isFood == false
                                    ? state.historyModel.milkingSlipDetaiItem
                                    : state.feedHistoryModel.feedHistoryItem;
                                print(state);
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
                                                    title: isFood == false
                                                        ? ItemHistory(
                                                            list: list[index],
                                                          )
                                                        : ItemFoodHistory(
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
