import 'package:AgrifoodApp/core/storage.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'history_bloc.dart';

class CallBloc {
  //  callHistoryAdded(
  //     {BuildContext context, int session, DateTime current, isFood, farmerId}) async {
    
    
  // }

  callHistoryAddedNonStatic({BuildContext context, DateTime current, isFood}) {
    BlocProvider.of<HistoryBloc>(context)
      ..add(HistoryLoadedSucces(
          day: current.day,
          month: current.month,
          year: current.year,
          session: 0,
          isFood: isFood));
  }

  int daysInEnd(DateTime date, DateTime current) {
    var firstDayThisMonth = new DateTime(date.year, date.month, date.day);
    var firstDayNextMonth =
        new DateTime(current.year, current.month, current.day + 1);
    return firstDayNextMonth.difference(firstDayThisMonth).inDays;
  }
}
