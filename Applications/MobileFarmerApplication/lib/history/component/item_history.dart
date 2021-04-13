import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';
import 'package:flutter/material.dart';
import 'package:flutter_cmoon_icons/flutter_cmoon_icons.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'colors.dart';

class ItemHistory extends StatefulWidget {
  final MilkingSlipDetailItem list;

  const ItemHistory({Key key, this.list}) : super(key: key);
  @override
  _ItemHistoryState createState() => _ItemHistoryState();
}

class _ItemHistoryState extends State<ItemHistory> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Column(
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              width: (size.width - ScreenUtil().setWidth(300)) * 0.7,
              child: Row(
                children: [
                  Expanded(
                    child: Center(
                      child: Image.asset(
                        "assets/images/eating.png",
                        width: ScreenUtil().setWidth(150),
                        height: ScreenUtil().setHeight(150),
                      ),
                    ),
                  ),
                  SizedBox(width: ScreenUtil().setWidth(40)),
                  Container(
                    width: (size.width - ScreenUtil().setWidth(290)) * 0.5,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          widget.list.cowId.toString() ?? "",
                          style: TextStyle(
                              fontSize: ScreenUtil().setSp(60),
                              color: black,
                              fontWeight: FontWeight.w500),
                          overflow: TextOverflow.ellipsis,
                        ),
                        SizedBox(height: ScreenUtil().setHeight(2)),
                        Text(
                          widget.list.note ?? "",
                          style: TextStyle(
                              fontSize: ScreenUtil().setSp(50),
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
              width: (size.width - ScreenUtil().setWidth(3000) * 0.3),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  Text(
                    widget.list.quantity.toString() ?? "",
                    style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: ScreenUtil().setSp(60),
                        color: Colors.green),
                  ),
                ],
              ),
            )
          ],
        ),
        Padding(
          padding: EdgeInsets.only(left: ScreenUtil().setWidth(40), top: ScreenUtil().setHeight(30)),
          child: Divider(
            thickness: ScreenUtil().setSp(2),
          ),
        )
      ],
    );
  }
}

Widget title() {
  return Text(
    "Thống kê",
    style: TextStyle(fontSize: ScreenUtil().setSp(80), fontWeight: FontWeight.bold, color: black),
  );
}

Row tabTille({title}) {
  return Row(
    mainAxisAlignment: MainAxisAlignment.center,
    children: [
      title == "Sáng"
          ? CIcon(
              IconMoon.icon_sun,
              color: Colors.orangeAccent,
              //size: 20,
            )
          : CIcon(
              IconMoon.icon_cloud_moon,
              color: Colors.blueGrey,
              //size: 20,
            ),
      Padding(
        padding: EdgeInsets.only(left: ScreenUtil().setWidth(20),),
        child: Text(title),
      )
    ],
  );
}
