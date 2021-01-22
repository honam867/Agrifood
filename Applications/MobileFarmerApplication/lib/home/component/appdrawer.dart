import 'package:AgrifoodApp/authentication/bloc/authentication_bloc.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_cubit.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_event.dart';
import 'package:AgrifoodApp/authentication/change_password.dart/page/changepass_page.dart';
import 'package:AgrifoodApp/home/component/custom_drawer_header.dart';
import 'package:AgrifoodApp/home/component/information.dart';
import 'package:AgrifoodApp/home/model/menu_item.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:AgrifoodApp/respository/register_repository.dart';
import 'package:AgrifoodApp/ui/utils/palette.dart';
import 'package:circular_profile_avatar/circular_profile_avatar.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class AppDrawer extends StatelessWidget {
  final UserInfoModel userInfoModel;
  final BuildContext contextHome;

  const AppDrawer({Key key, this.userInfoModel, this.contextHome})
      : super(key: key);

  CustomDrawerHeader buildCustomDrawerHeader() {
    return CustomDrawerHeader(
      margin: EdgeInsets.all(ScreenUtil().setHeight(0)),
      decoration: BoxDecoration(
        border: Border(
          bottom: BorderSide(color: Palette.dark60, width: ScreenUtil().setWidth(0.5)),
        ),
      ),
      child: Row(
        children: <Widget>[
          Padding(
            padding: EdgeInsets.only(right: ScreenUtil().setWidth(40)),
            child: CircularProfileAvatar(
              this.userInfoModel.avatarURL ??
                  "https://www.clipartmax.com/png/middle/479-4798442_about-me-avatar-farmer.png",
              borderWidth: ScreenUtil().setWidth(4.0),
              radius: ScreenUtil().setSp(200),
            ),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(this.userInfoModel.userName ?? "",
                  textScaleFactor: 1.3,
                  style: TextStyle(fontSize: ScreenUtil().setSp(40))),
              Text(
                  this.userInfoModel.status == true
                      ? "Đang hoạt động"
                      : "Ngưng hoạt động",
                  textScaleFactor: 1.3,
                  style: TextStyle(
                      fontSize: ScreenUtil().setSp(30),
                      color: this.userInfoModel.status == true
                          ? Colors.green
                          : Colors.red))
            ],
          )
        ],
      ),
    );
  }

  List<Widget> buildDrawer(BuildContext context, List<MenuItem> drawerItems) {
    List<Widget> items = new List<Widget>();
    items.add(buildCustomDrawerHeader());
    for (int i = 0; i < drawerItems.length; i++) {
      items.add(
        InkWell(
          child: Padding(
            padding: EdgeInsets.all(ScreenUtil().setSp(30)),
            child: Row(
              children: <Widget>[
                Padding(
                  padding: EdgeInsets.only(right: ScreenUtil().setHeight(30)),
                  child: drawerItems[i].icon,
                ),
                Text(
                  drawerItems[i].title,
                  style: TextStyle(fontSize: ScreenUtil().setSp(60)),
                ),
              ],
            ),
          ),
          onTap: drawerItems[i].onPress,
        ),
      );
    }
    return items;
  }

  @override
  Widget build(BuildContext context) {
    final drawerItems = <MenuItem>[
      new MenuItem(
        icon: Icon(Icons.supervised_user_circle),
        title: 'Thông tin cá nhân',
        onPress: () {
          Navigator.push(
            this.contextHome,
            MaterialPageRoute(
                builder: (context) => UserInformation(
                      contextHome: this.contextHome,
                      userInfoModel: this.userInfoModel,
                    )),
          );
        },
      ),
      new MenuItem(
        icon: Icon(Icons.change_history),
        title: 'Đổi mật khẩu',
        onPress: () {
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => AuthenticationCubit(
                    RegisterReponsitory(), AuthenticationRepository()),
                child: ChangePassPage(),
              ),
            ),
          );
        },
      ),
      new MenuItem(
        icon: Icon(Icons.phone),
        title: 'Liên hệ',
        onPress: () {},
      ),
      new MenuItem(
        icon: Icon(Icons.message),
        title: 'Chat',
        onPress: () {},
      ),
      new MenuItem(
        icon: Icon(Icons.arrow_back),
        title: 'Đăng xuất',
        onPress: () async {
          Navigator.pop(context);
          BlocProvider.of<AuthenticationBloc>(context).add(LoggedOut());
        },
      ),
    ];

    return Drawer(
        child: Stack(
      children: [
        ClipPath(
          child: Container(
            padding: EdgeInsets.only(top: ScreenUtil().setHeight(50)),
            width: MediaQuery.of(context).size.width,
            height: ScreenUtil().setHeight(550),
            color: Colors.green[100],
          ),
          clipper: CustomClipPath(),
        ),
        ListView(
          padding: EdgeInsets.zero,
          children: buildDrawer(context, drawerItems),
        ),
      ],
    ));
  }
}

class CustomClipPath extends CustomClipper<Path> {
  var radius = 10.0;
  @override
  Path getClip(Size size) {
    Path path = Path();
    path.lineTo(0, size.height);
    path.quadraticBezierTo(
        size.width / 4, size.height - 40, size.width / 2, size.height - 20);
    path.quadraticBezierTo(
        3 / 4 * size.width, size.height, size.width, size.height - 30);
    path.lineTo(size.width, 0);

    return path;
  }

  @override
  bool shouldReclip(CustomClipper<Path> oldClipper) => false;
}
