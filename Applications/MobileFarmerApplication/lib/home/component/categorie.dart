import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CategoriesScroller extends StatelessWidget {
  final int byreLength;
  final int cowLength;
  const CategoriesScroller({this.byreLength, this.cowLength});

  @override
  Widget build(BuildContext context) {
    final double categoryHeight =
        MediaQuery.of(context).size.height * ScreenUtil().setHeight(0.9);
    return SingleChildScrollView(
      physics: BouncingScrollPhysics(),
      scrollDirection: Axis.horizontal,
      child: Container(
        margin: EdgeInsets.symmetric(
            vertical: ScreenUtil().setHeight(70.0),
            horizontal: ScreenUtil().setWidth(70.0)),
        child: FittedBox(
          fit: BoxFit.fill,
          alignment: Alignment.topCenter,
          child: Row(
            children: <Widget>[
              Container(
                width: ScreenUtil().setWidth(600),
                margin: EdgeInsets.only(right: 35),
                height: categoryHeight,
                decoration: BoxDecoration(
                    color: Colors.brown[400],
                    borderRadius: BorderRadius.all(
                        Radius.circular(ScreenUtil().setSp(50.0)))),
                child: Padding(
                  padding: EdgeInsets.all(ScreenUtil().setSp(40.0)),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: <Widget>[
                      Text(
                        "Tổng Trại",
                        style: TextStyle(
                            fontSize: ScreenUtil().setSp(90.0),
                            color: Colors.white,
                            fontWeight: FontWeight.bold),
                      ),
                      SizedBox(
                        height: ScreenUtil().setHeight(50.0),
                        // width: ScreenUtil().setWidth(50.0)
                      ),
                      Text(
                        "${this.byreLength}",
                        textAlign: TextAlign.center,
                        style: TextStyle(
                            fontSize: ScreenUtil().setSp(200.0),
                            color: Colors.white,
                            fontWeight: FontWeight.bold),
                      ),
                    ],
                  ),
                ),
              ),
              Container(
                width: ScreenUtil().setWidth(590),
                margin: EdgeInsets.only(right: ScreenUtil().setWidth(20.0)),
                height: categoryHeight,
                decoration: BoxDecoration(
                    color: Colors.brown[400],
                    borderRadius: BorderRadius.all(Radius.circular(12.0))),
                child: Container(
                  child: Padding(
                    padding: EdgeInsets.all(ScreenUtil().setSp(60.0)),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: <Widget>[
                        Text(
                          "Tổng Bò",
                          style: TextStyle(
                              fontSize: ScreenUtil().setSp(90.0),
                              color: Colors.white,
                              fontWeight: FontWeight.bold),
                        ),
                        SizedBox(height: ScreenUtil().setHeight(50.0)),
                        Text(
                          "${this.cowLength}",
                          textAlign: TextAlign.center,
                          style: TextStyle(
                              fontSize: ScreenUtil().setSp(200.0),
                              color: Colors.white,
                              fontWeight: FontWeight.bold),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
