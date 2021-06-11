import 'package:AgrifoodApp/byre/bloc/byre_cubit.dart';
import 'package:AgrifoodApp/byre/page/byre_page.dart';
import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/cow_page.dart';
//import 'package:AgrifoodApp/cow/cow_manager/page/list_cow.dart';
import 'package:AgrifoodApp/history/bloc/history_bloc.dart';
import 'package:AgrifoodApp/history/page/daily_page.dart';
import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/information.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class Dashboard extends StatefulWidget {
  final BuildContext contextHome;
  final FarmerInfoModel farmerInfoModel;

  const Dashboard({Key key, this.contextHome, this.farmerInfoModel})
      : super(key: key);
  @override
  _DashboardState createState() => _DashboardState();
}

class _DashboardState extends State<Dashboard> {
  ScrollController controller = new ScrollController();
  Items item1 = new Items(
      title: "Quản lí trại",
      //subtitle: "Danh sách các trại hiện có",
      event: "",
      img: "assets/layout/stable.png");

  Items item2 = new Items(
    title: "Quản lí bò",
    //subtitle: "Danh sách bò hiện có",
    event: "",
    img: "assets/layout/cowmale.png",
  );

  Items item5 = new Items(
    title: "Nhật ký",
    //subtitle: "Chi tiết lượng sữa và thức ăn",
    event: "",
    img: "assets/layout/pie-chart.png",
  );

  Items item6 = new Items(
    title: "Cài đặt",
    // subtitle: "",
    event: "",
    img: "assets/layout/settings.png",
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
    List<Items> myList = [item1, item2, item5, item6];

    var color = 0xff689738;
    return Flexible(
      child: GridView.count(
          controller: controller,
          childAspectRatio: 1.0,
          padding: EdgeInsets.only(
              left: ScreenUtil().setWidth(40),
              right: ScreenUtil().setWidth(40)),
          crossAxisCount: 2,
          crossAxisSpacing: 18,
          mainAxisSpacing: 18,
          children: myList.map((data) {
            return InkWell(
                child: Container(
                  decoration: BoxDecoration(
                      color: Color(color),
                      borderRadius:
                          BorderRadius.circular(ScreenUtil().setSp(80))),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      Image.asset(
                        data.img,
                        width: ScreenUtil().setWidth(120),
                      ),
                      SizedBox(
                        height: ScreenUtil().setHeight(40),
                      ),
                      Text(
                        data.title,
                        style: GoogleFonts.openSans(
                            textStyle: TextStyle(
                                color: Colors.white,
                                fontSize: ScreenUtil().setSp(50),
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
                            builder: (context) => UserInformation(
                                  contextHome: widget.contextHome,
                                  farmerInfoModel: widget.farmerInfoModel,
                                )),
                      );
                    });
                  } else if (data.title == "Quản lí bò") {
                    setState(() {
                      Navigator.push(
                          context,
                          MaterialPageRoute(
                            builder: (context) => BlocProvider(
                              create: (context) => CowBloc(
                                  cowRepository: CowRepository(),
                                  foodSuggestionRepository:
                                      FoodSuggestionRepository()),
                              child: CowPage(
                                farmerInfoModel: widget.farmerInfoModel,
                                route: "DashBoard",
                              ),
                            ),
                          ));
                    });
                  } else if (data.title == "Quản lí trại") {
                    setState(() {
                      Navigator.push(
                          context,
                          MaterialPageRoute(
                            builder: (context) => BlocProvider(
                              create: (context) => ByreCubit(ByreRepository()),
                              child: ListByres(
                                farmerInfoModel: widget.farmerInfoModel,
                                farmerId: widget.farmerInfoModel.id,
                              ),
                            ),
                          ));
                    });
                  } else if (data.title == "Nhật ký") {
                    setState(() {
                      Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => BlocProvider(
                                  create: (context) => HistoryBloc(),
                                  child: DailyPage())));
                    });
                  } else {
                    showToast(
                        string: "Chưa khả dụng", context: widget.contextHome);
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
