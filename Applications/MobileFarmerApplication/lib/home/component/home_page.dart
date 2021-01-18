import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/appdrawer.dart';
import 'package:AgrifoodApp/home/component/custom_clippath.dart';
import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class HomePage extends StatefulWidget {
  final UserInfoModel userInfo;

  const HomePage({Key key, this.userInfo}) : super(key: key);
  @override
  _HomePageState createState() => _HomePageState();

  static _HomePageState of(BuildContext context) =>
      context.findAncestorStateOfType<_HomePageState>();
}

class _HomePageState extends State<HomePage> {
  var scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  Widget build(BuildContext context) {
    // UserInfoModel userInfoModel = widget.userInfo;
    return Scaffold(
        key: scaffoldKey,
        backgroundColor: Colors.grey[200],
        drawer: AppDrawer(
          userInfoModel: widget.userInfo,
          contextHome: context,
        ),
        body: Stack(
          children: <Widget>[
            ClipPath(
              child: Container(
                //padding: EdgeInsets.only(top: 100),
                width: MediaQuery.of(context).size.width,
                height: ScreenUtil().setHeight(1000),
                color: Color(0xff9CCC65),
              ),
              clipper: CustomClipPathByHomePage(),
            ),
            Column(
              children: <Widget>[
                SizedBox(
                  height: ScreenUtil().setHeight(300),
                ),
                Padding(
                  padding: EdgeInsets.only(left: 16, right: 16),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: <Widget>[
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          Text(
                            "Xin chào ${widget.userInfo.userName}!",
                            style: GoogleFonts.openSans(
                                textStyle: TextStyle(
                                    color: Colors.white,
                                    fontSize: ScreenUtil().setSp(50),
                                    fontWeight: FontWeight.bold)),
                          ),
                          SizedBox(
                            height: 4,
                          ),
                          Text(
                            "Trang chủ",
                            style: GoogleFonts.openSans(
                                textStyle: TextStyle(
                                    color: Colors.black,
                                    fontSize: ScreenUtil().setSp(35),
                                    fontWeight: FontWeight.w600)),
                          ),
                        ],
                      ),
                      Row(
                        children: [
                          IconButton(
                            alignment: Alignment.topCenter,
                            icon: Icon(
                              Icons.add,
                              size: 24,
                              color: Colors.white,
                            ),
                            onPressed: () {},
                          ),
                          IconButton(
                            alignment: Alignment.topCenter,
                            icon: Image.asset(
                              "assets/layout/notification.png",
                              width: 24,
                            ),
                            onPressed: () {},
                          ),
                        ],
                      )
                    ],
                  ),
                ),
                SizedBox(
                  height: 40,
                ),
                BlocProvider(
                  create: (context) => HomeCubit(),
                  child: Dashboard(
                    contextHome: context,
                    userInfoModel: widget.userInfo,
                  ),
                ),
              ],
            ),
            Positioned(
              left: 10,
              top: 20,
              child: IconButton(
                icon: Icon(
                  Icons.menu,
                  color: Colors.white,
                ),
                onPressed: () => scaffoldKey.currentState.openDrawer(),
              ),
            ),
          ],
        ));
  }
}
