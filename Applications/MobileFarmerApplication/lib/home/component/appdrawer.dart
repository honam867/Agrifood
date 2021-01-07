import 'package:AgrifoodApp/authentication/bloc/authentication_bloc.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_event.dart';
import 'package:AgrifoodApp/home/component/custom_drawer_header.dart';
import 'package:AgrifoodApp/home/model/menu-item.dart';
import 'package:AgrifoodApp/ui/utils/palette.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AppDrawer extends StatelessWidget {
  final String fullname;
  final String avatar;

  const AppDrawer({Key key, this.fullname, this.avatar}) : super(key: key);

  CustomDrawerHeader buildCustomDrawerHeader() {
    return CustomDrawerHeader(
      margin: EdgeInsets.all(0),
      decoration: BoxDecoration(
        border: Border(
          bottom: BorderSide(color: Palette.dark60, width: 0.5),
        ),
      ),
      child: Row(
        children: <Widget>[
          Padding(
            padding: EdgeInsets.only(right: 10),
            child: CircleAvatar(
              backgroundColor: Palette.dodgerBlue,
              backgroundImage:
                  avatar != null && avatar != '' ? NetworkImage(avatar) : null,
              child: avatar == null || avatar == '' ? Text('C') : null,
            ),
          ),
          Text(fullname == null ? '' : fullname.toUpperCase(),
              textScaleFactor: 1.3)
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
            padding: EdgeInsets.all(10),
            child: Row(
              children: <Widget>[
                Padding(
                  padding: EdgeInsets.only(right: 10.0),
                  child: drawerItems[i].icon,
                ),
                Text(
                  drawerItems[i].title,
                  style: TextStyle(fontSize: 15.0),
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
        onPress: () {},
      ),
      new MenuItem(
        icon: Icon(Icons.supervised_user_circle),
        title: 'Đổi mật khẩu',
        onPress: () {},
      ),
      new MenuItem(
        icon: Icon(Icons.supervised_user_circle),
        title: 'Liên hệ',
        onPress: () {},
      ),
      new MenuItem(
        icon: Icon(Icons.supervised_user_circle),
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
      child: ListView(
        padding: EdgeInsets.zero,
        children: buildDrawer(context, drawerItems),
      ),
    );
  }
}
