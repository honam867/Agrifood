// import 'package:AgrifoodApp/ui/utils/format.dart';
// import 'package:AgrifoodApp/ui/utils/text_style.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter/widgets.dart';
// import 'package:flutter_screenutil/screen_util.dart';

// import 'form_detail_cow.dart';

// typedef ListDetailFunction = Function({int val, String title});
// Widget listDetail({listDetail, ListDetailFunction listDetailFunction}) {
//   var widget;
//   return Container(
//     child: Column(
//       crossAxisAlignment: CrossAxisAlignment.start,
//       children: <Widget>[
//         builItem(title: "Tên bò: ", string: widget.cowItem.name),
//         Divider(
//           height: ScreenUtil().setHeight(70),
//           thickness: ScreenUtil().setHeight(15),
//           color: Colors.lightGreen[200],
//         ),
//         SizedBox(
//           height: ScreenUtil().setHeight(15),
//         ),
//         builItem(
//             title: "Id bò cha: ", string: widget.cowItem.fatherId.toString()),
//         Divider(
//           height: ScreenUtil().setHeight(70),
//           thickness: ScreenUtil().setHeight(15),
//           color: Colors.lightGreen[200],
//         ),
//         SizedBox(
//           height: ScreenUtil().setHeight(15),
//         ),
//         builItem(
//             title: "Id bò mẹ: ", string: widget.cowItem.motherId.toString()),
//         Divider(
//           height: ScreenUtil().setHeight(70),
//           thickness: ScreenUtil().setHeight(15),
//           color: Colors.lightGreen[200],
//         ),
//         SizedBox(
//           height: ScreenUtil().setHeight(15),
//         ),
//         builItem(title: "Chuồng: ", string: widget.cowItem.byreId.toString()),
//         Divider(
//           height: ScreenUtil().setHeight(70),
//           thickness: ScreenUtil().setHeight(15),
//           color: Colors.lightGreen[200],
//         ),
//         SizedBox(
//           height: ScreenUtil().setHeight(15),
//         ),
//         builItem(title: "Mã bò: ", string: widget.cowItem.code),
//         Divider(
//           height: ScreenUtil().setHeight(70),
//           thickness: ScreenUtil().setHeight(15),
//           color: Colors.lightGreen[200],
//         ),
//         SizedBox(
//           height: ScreenUtil().setHeight(15),
//         ),
//         builItem(
//             title: "Ngày cai sữa: ",
//             string: Formator.convertDatatimeToString(
//                 widget.cowItem.weaningDate ?? DateTime.now())),
//         Divider(
//           height: ScreenUtil().setHeight(70),
//           thickness: ScreenUtil().setHeight(15),
//           color: Colors.lightGreen[200],
//         ),
//       ],
//     ),
//   );
// }

// Widget builItem({title, string}) {
//   return Row(
//     crossAxisAlignment: CrossAxisAlignment.center,
//     mainAxisAlignment: MainAxisAlignment.spaceBetween,
//     children: [
//       Padding(
//         padding: EdgeInsets.only(top: ScreenUtil().setHeight(60)),
//         child: Text(title, style: TextStyles.labelTextStyle),
//       ),
//       Padding(
//         padding: EdgeInsets.only(top: ScreenUtil().setHeight(60)),
//         child: Text(string, style: TextStyles.detailTextCow),
//       ),
//     ],
//   );
// }
