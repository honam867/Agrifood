import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/appdrawer.dart';
import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:AgrifoodApp/home/component/information.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_fonts/google_fonts.dart';

class HomePage extends StatefulWidget {
  final userInfo;

  const HomePage({Key key, this.userInfo}) : super(key: key);
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  var scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
          key: scaffoldKey,
          backgroundColor: Color(0xff9CCC65),
          drawer: AppDrawer(
            fullname: widget.userInfo['UserName'],
            avatar: "abc",
          ),
          body: Stack(
            children: <Widget>[
              Column(
                children: <Widget>[
                  SizedBox(
                    height: 110,
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
                              "Xin chào! ${widget.userInfo['UserName']}",
                              style: GoogleFonts.openSans(
                                  textStyle: TextStyle(
                                      color: Colors.white,
                                      fontSize: 18,
                                      fontWeight: FontWeight.bold)),
                            ),
                            SizedBox(
                              height: 4,
                            ),
                            Text(
                              "Trang chủ",
                              style: GoogleFonts.openSans(
                                  textStyle: TextStyle(
                                      color: Color(0xffa29aac),
                                      fontSize: 14,
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
