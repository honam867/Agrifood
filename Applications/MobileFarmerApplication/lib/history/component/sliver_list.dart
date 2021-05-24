// import 'package:AgrifoodApp/history/bloc/history_bloc.dart';
// import 'package:AgrifoodApp/history/component/item_history.dart';
// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';

// class SliverListMilkingSlip extends StatefulWidget {
//   final BlocProvider blocProvider;

//   const SliverListMilkingSlip({Key key, this.blocProvider}) : super(key: key);
//   @override
//   _SliverListMilkingSlipState createState() => _SliverListMilkingSlipState();
// }

// class _SliverListMilkingSlipState extends State<SliverListMilkingSlip> {
//   static DateTime current = DateTime.now();
//   @override
//   Widget build(BuildContext context) {
//     return BlocBuilder<HistoryBloc, HistoryState>(
//       builder: (context, state) {
//         if (state is HistoryLoadInprocess) {
//           BlocProvider.of<HistoryBloc>(context)
//             ..add(HistoryLoadedSucces(
               
//                 day: current.day,
//                 month: current.month,
//                 year: current.year,
//                 session: 0, isFood));
//         }
//         if (state is HistoryLoading) {
//           return Container(
//             padding: EdgeInsets.only(top: 20),
//             width: 50,
//             child: Center(
//               child: CircularProgressIndicator(),
//             ),
//           );
//         }
//         if (state is HistoryLoaded) {
//           var list = state.historyModel.milkingSlipDetaiItem;
//           return list.length > 0
//               ? SliverList(
//                   delegate: SliverChildBuilderDelegate(
//                     (BuildContext context, int index1) {
//                       return Container(
//                           //height: 50,
//                           child: SingleChildScrollView(
//                         child: Column(
//                           children: [
//                             Container(
//                               padding: EdgeInsets.only(top: 20),
//                               child: ListView.builder(
//                                 shrinkWrap: true,
//                                 physics: NeverScrollableScrollPhysics(),
//                                 itemCount: list.length,
//                                 itemBuilder: (context, index) {
//                                   return ListTile(
//                                     title: ItemHistory(
//                                       list: list[index],
//                                     ),
//                                   );
//                                 },
//                               ),
//                             )
//                           ],
//                         ),
//                       ));
//                     },
//                     childCount: 1,
//                   ),
//                 )
//               : SizedBox(
//                   height: 200, // Some height
//                   child: Center(
//                     child: Text("Không có báo cáo nào"),
//                   ),
//                 );
//         }
//         return SliverList(
//     delegate: SliverChildListDelegate(
//       [
//         Container(color: Colors.red, height: 150.0),
//         Container(color: Colors.purple, height: 150.0),
//         Container(color: Colors.green, height: 150.0),
//       ],
//     ),
// );
//       },
//     );
//   }
// }
