import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/information.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';

class Dashboard extends StatefulWidget {
  final BuildContext contextHome;
  final UserInfoModel userInfoModel;

  const Dashboard({Key key, this.contextHome, this.userInfoModel}) : super(key: key);
  @override
  _DashboardState createState() => _DashboardState();
}

class _DashboardState extends State<Dashboard> {
  ScrollController controller = new ScrollController();
  Items item1 = new Items(
      title: "Quản lí chuồng",
      subtitle: "Danh sách các chuồng hiện có",
      event: "",
      img: "assets/layout/file.png");

  Items item2 = new Items(
    title: "Quản lí bò",
    subtitle: "Danh sách bò hiện có",
    event: "",
    img: "assets/layout/cow.png",
  );

  Items item3 = new Items(
    title: "Thức ăn và Sữa",
    subtitle: "Tổng hợp lượng thức ăn và sữa",
    event: "",
    img: "assets/layout/food.png",
  );

  Items item4 = new Items(
    title: "Thống kê",
    subtitle: "Chi tiết lượng sữa và thức ăn",
    event: "",
    img: "assets/layout/todo.png",
  );

  Items item5 = new Items(
    title: "Cá nhân",
    subtitle: "Thông tin cá nhân",
    event: "",
    img: "assets/layout/user.png",
  );

  Items item6 = new Items(
    title: "Cài đặt",
    subtitle: "",
    event: "",
    img: "assets/layout/setting.png",
  );
  void submitCityName(BuildContext context, Items item) {
    final homeCubit = widget.contextHome.read<HomeCubit>();
    homeCubit.clickMenu(item);
  }

  @override
  void dispose() {
    controller.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    List<Items> myList = [item1, item2, item3, item4, item5, item6];

    var color = 0xff689738;
    return Flexible(
          child: GridView.count(
              controller: controller,
              childAspectRatio: 1.0,
              padding: EdgeInsets.only(left: 16, right: 16),
              crossAxisCount: 2,
              crossAxisSpacing: 18,
              mainAxisSpacing: 18,
              children: myList.map((data) {
                return InkWell(
                    child: Container(
                      decoration: BoxDecoration(
                          color: Color(color),
                          borderRadius: BorderRadius.circular(10)),
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
                    ),
                    onTap: () {
                      if (data.title == "Cá nhân") {
                        setState(() {
                          Navigator.push(
                            widget.contextHome,
                            MaterialPageRoute(
                                builder: (context) => UserInformation(contextHome: widget.contextHome,userInfoModel: widget.userInfoModel,)),
                          );
                        });
                      }
                      else {
                        showToast(string: "Chưa khả dụng", context: widget.contextHome);
                      }
                    });
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
