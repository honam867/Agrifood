import 'package:AgrifoodApp/feedCow/model/feed_history_item.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_cmoon_icons/flutter_cmoon_icons.dart';
import 'package:flutter_screenutil/screen_util.dart';

import 'colors.dart';
import 'icon.dart';

class ItemFoodHistory extends StatefulWidget {
  final FeedHistoryItem list;

  const ItemFoodHistory({Key key, this.list}) : super(key: key);
  @override
  _ItemFoodHistoryState createState() => _ItemFoodHistoryState();
}

class _ItemFoodHistoryState extends State<ItemFoodHistory> {
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
                        RichText(
                          text: TextSpan(
                            text: 'Mã: ',
                            style: TextStyle(fontSize: 15, color: Colors.black),
                            children: <TextSpan>[
                              TextSpan(
                                  text: widget.list.code,
                                  style: TextStyle(
                                      fontSize: ScreenUtil().setSp(50),
                                      color: black.withOpacity(0.5),
                                      fontWeight: FontWeight.w400)),
                            ],
                          ),
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
                  IconButton(icon: IconDart.iconBack, onPressed: (){})
                ],
              ),
            )
          ],
        ),
        Padding(
          padding: EdgeInsets.only(
              left: ScreenUtil().setWidth(40), top: ScreenUtil().setHeight(30)),
          child: Divider(
            thickness: ScreenUtil().setSp(2),
          ),
        )
      ],
    );
  }
}


