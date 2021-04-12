import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';
import 'package:flutter/material.dart';
import 'package:flutter_cmoon_icons/flutter_cmoon_icons.dart';

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
                  width: (size.width - 40) * 0.7,
                  child: Row(
                    children: [
                      Expanded(child: Center(
                          child: Image.asset(
                            "assets/images/eating.png",
                            width: 30,
                            height: 30,
                          ),
                        ),),
                      SizedBox(width: 15),
                      Container(
                        width: (size.width - 90) * 0.5,
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(
                              widget.list.cowId.toString() ?? "",
                              style: TextStyle(
                                  fontSize: 15,
                                  color: black,
                                  fontWeight: FontWeight.w500),
                              overflow: TextOverflow.ellipsis,
                            ),
                            SizedBox(height: 5),
                            Text(
                              widget.list.note ?? "",
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
                        widget.list.quantity.toString() ?? "",
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
    
    
    
  }
}

Widget title() {
  return Text(
    "Thống kê",
    style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold, color: black),
  );
}
 Row tabTille({title}){
   return Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      children: [
                                       title == "Sáng" ? CIcon(
                                          IconMoon.icon_sun,
                                          color: Colors.orangeAccent,
                                          //size: 20,
                                        ) : CIcon(
                                          IconMoon.icon_cloud_moon  ,
                                          color: Colors.blueGrey,
                                          //size: 20,
                                        ),
                                        Padding(
                                          padding: EdgeInsets.only(left: 5),
                                          child: Text(title),
                                        )
                                      ],
                                    );
 }

