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
        MediaQuery.of(context).size.height * 0.30 - 50;
    return SingleChildScrollView(
      physics: BouncingScrollPhysics(),
      scrollDirection: Axis.horizontal,
      child: Container(
        margin: EdgeInsets.symmetric(vertical: ScreenUtil().setHeight(60.0), horizontal: ScreenUtil().setWidth(60.0) ),
        child: FittedBox(
          fit: BoxFit.fill,
          alignment: Alignment.topCenter,
          child: Row(
            children: <Widget>[
              Container(
                width: 150,
                margin: EdgeInsets.only(right: 20),
                height: categoryHeight,
                decoration: BoxDecoration(
                    color: Colors.orange.shade400,
                    borderRadius: BorderRadius.all(Radius.circular(ScreenUtil().setSp(50.0)))),
                child: Padding(
                  padding: EdgeInsets.all(ScreenUtil().setSp(60.0)),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: <Widget>[
                      Text(
                        "Chuồng",
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
                        style: TextStyle(fontSize: ScreenUtil().setSp(200.0),
                        color: Colors.white,
                        fontWeight: FontWeight.bold),
                        ),
                    ],
                  ),
                ),
              ),
              Container(
                width: 150,
                margin: EdgeInsets.only(right: 20),
                height: categoryHeight,
                decoration: BoxDecoration(
                    color: Colors.blue.shade400,
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
                        SizedBox(
                          height: ScreenUtil().setHeight(50.0)
                        ),
                        Text(
                          "${this.cowLength}",
                          textAlign: TextAlign.center,
                          style: TextStyle(fontSize: ScreenUtil().setSp(200.0), 
                          color: Colors.white,
                          fontWeight: FontWeight.bold
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
              Container(
                width: ScreenUtil().setWidth(450.0),
                margin: EdgeInsets.only(right: ScreenUtil().setWidth(20.0)),
                height: categoryHeight,
                decoration: BoxDecoration(
                    color: Colors.lightBlueAccent.shade400,
                    borderRadius: BorderRadius.all(Radius.circular(ScreenUtil().setSp(40.0)))),
                child: Padding(
                  padding: EdgeInsets.all(ScreenUtil().setSp(60.0)),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: <Widget>[
                      Text(
                        "Super", //saving
                        style: TextStyle(
                            fontSize: ScreenUtil().setSp(90.0),
                            color: Colors.white,
                            fontWeight: FontWeight.bold),
                      ),
                      SizedBox(
                        height: ScreenUtil().setHeight(50.0),
                      ),
                      Text(
                        "20", //items
                        style: TextStyle(fontSize: ScreenUtil().setSp(200.0), 
                        color: Colors.white,
                        fontWeight: FontWeight.bold),
                      ),
                    ],
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