import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xff392850),
      body: Column(
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
                      "Xin chào!",
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
          Dashboard()
        ],
      ),
    );
  }
}
