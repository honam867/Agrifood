import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class Dashboard extends StatefulWidget {
  @override
  _DashboardState createState() => _DashboardState();
}

class _DashboardState extends State<Dashboard> {
  Items item1 = new Items(
      title: "Danh sách bò",
      subtitle: "March, Wednesday",
      event: "3 Events",
      img: "assets/layout/calendar.png");

  Items item2 = new Items(
    title: "Thức ăn bò",
    subtitle: "Bocali, Apple",
    event: "4 Items",
    img: "assets/layout/food.png",
  );

  Items item3 = new Items(
    title: "Vị trí bò",
    subtitle: "Lucy Mao going to Office",
    event: "",
    img: "assets/layout/map.png",
  );

  Items item4 = new Items(
    title: "Thông tại chuồng",
    subtitle: "Rose favirited your Post",
    event: "",
    img: "assets/layout/festival.png",
  );

  Items item5 = new Items(
    title: "Thống kê",
    subtitle: "Homework, Design",
    event: "4 Items",
    img: "assets/layout/todo.png",
  );

  Items item6 = new Items(
    title: "Cài đặt",
    subtitle: "",
    event: "2 Items",
    img: "assets/layout/setting.png",
  );

  @override
  Widget build(BuildContext context) {
    List<Items> myList = [item1, item2, item3, item4, item5, item6];
    var color = 0xff689738;
    return Flexible(
      child: GridView.count(
          childAspectRatio: 1.0,
          padding: EdgeInsets.only(left: 16, right: 16),
          crossAxisCount: 2,
          crossAxisSpacing: 18,
          mainAxisSpacing: 18,
          children: myList.map((data) {
            return Container(
              decoration: BoxDecoration(
                  color: Color(color), borderRadius: BorderRadius.circular(10)),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Image.asset(
                    data.img,
                    width: 42,
                  ),
                  SizedBox(
                    height: 14,
                  ),
                  Text(
                    data.title,
                    style: GoogleFonts.openSans(
                        textStyle: TextStyle(
                            color: Colors.white,
                            fontSize: 16,
                            fontWeight: FontWeight.w600)),
                  ),
                  SizedBox(
                    height: 8,
                  ),
                  Text(
                    data.subtitle,
                    style: GoogleFonts.openSans(
                        textStyle: TextStyle(
                            color: Colors.white38,
                            fontSize: 10,
                            fontWeight: FontWeight.w600)),
                  ),
                  SizedBox(
                    height: 14,
                  ),
                  Text(
                    data.event,
                    style: GoogleFonts.openSans(
                        textStyle: TextStyle(
                            color: Colors.white70,
                            fontSize: 11,
                            fontWeight: FontWeight.w600)),
                  ),
                ],
              ),
            );
          }).toList()),
    );
  }
}

class Items {
  String title;
  String subtitle;
  String event;
  String img;
  Items({this.title, this.subtitle, this.event, this.img});
}
