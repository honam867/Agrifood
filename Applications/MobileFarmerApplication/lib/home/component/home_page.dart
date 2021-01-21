import 'package:AgrifoodApp/byre/bloc/byre_cubit.dart';
import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/appdrawer.dart';
import 'package:AgrifoodApp/home/component/custom_clippath.dart';
import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:AgrifoodApp/home/component/dialog_create_cow.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:giffy_dialog/giffy_dialog.dart';
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
  ByreRepository byreRepository = new ByreRepository();

  @override
  void initState() {
    super.initState();
  }

  void checkAmountByreFirst(BuildContext context) {
    final byreCubit = context.watch<HomeCubit>();
    byreCubit.checkAmountByre();
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<HomeCubit, HomeState>(
      listener: (context, state) {
        if (state is CheckByreLoaded) {
          if (state.amonth == 0) {
            showDialog(context: context, builder: (_) => DialogCreateCow());
          }
        }
      },
      builder: (context, state) {
        if (state is HomeInitial) {
          checkAmountByreFirst(context);
        }
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
                    width: ScreenUtil().screenWidth,
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
                      padding: EdgeInsets.only(left: ScreenUtil().setWidth(40), right: ScreenUtil().setWidth(40)),
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
                                        fontSize: ScreenUtil().setSp(60),
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
                                        fontSize: ScreenUtil().setSp(50),
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
                                  size: ScreenUtil().setSp(100),
                                  color: Colors.white,
                                ),
                                onPressed: () {},
                              ),
                              IconButton(
                                alignment: Alignment.topCenter,
                                icon: Image.asset(
                                  "assets/layout/notification.png",
                                  width: ScreenUtil().setWidth(80),
                                ),
                                onPressed: () {},
                              ),
                            ],
                          )
                        ],
                      ),
                    ),
                    SizedBox(
                      height: ScreenUtil().setHeight(60),
                    ),
                    BlocProvider(
                      create: (context) => HomeCubit(byreRepository),
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
      },
    );
  }
}
