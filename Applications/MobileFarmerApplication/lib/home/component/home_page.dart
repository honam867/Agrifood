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
    return SafeArea(
          child: Scaffold(
            key: scaffoldKey,
            backgroundColor: Color(0xFFFAFAFA),
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
                                        color: Colors.black,
                                        fontSize: 18,
                                        fontWeight: FontWeight.bold)),
                              ),
                              SizedBox(
                                height: 4,
                              ),
                              // Text(
                              //   "Trang chủ",
                              //   style: GoogleFonts.openSans(
                              //       textStyle: TextStyle(
                              //           color: Color(0xffa29aac),
                              //           fontSize: 14,
                              //           fontWeight: FontWeight.w600)),
                              // ),
                            ],
                          ),
                          Row(
                            children: [
                              IconButton(
                                alignment: Alignment.topCenter,
                                icon: Icon(
                                  Icons.add,
                                  size: 24,
                                  color: Colors.black,
                                ),
                                onPressed: () {},
                              ),
                              IconButton(
                                color: Colors.black,
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
                      color: Colors.black,
                    ),  
                    onPressed: () => scaffoldKey.currentState.openDrawer(),
                  ),
                ),
                Positioned(
                  left: 140,
                  top: 25,
                  child: Title(
                    color: Colors.black, 
                    child: Text("AGRIFOOD",
                      style: TextStyle(
                        fontWeight: FontWeight.w800,
                        fontSize: 30.0,
                        fontStyle: FontStyle.italic,
                      ),
                    ),
                  ),
                ),
              ],
            )
      ),
    );
  }
}
