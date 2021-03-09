import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'top_bar.dart';
import 'package:circular_profile_avatar/circular_profile_avatar.dart';

class StackContainer extends StatelessWidget {
  final FarmerInfoModel farmerInfoModel;
  const StackContainer({
    Key key, this.farmerInfoModel
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: ScreenUtil().setHeight(750),
      child: Stack(
        children: <Widget>[
          Container(),
          ClipPath(
            clipper: MyCustomClipper(),
            child: Container(
              height: ScreenUtil().setHeight(750),
              decoration: BoxDecoration(
                image: DecorationImage(
                  image: NetworkImage("https://image.freepik.com/free-vector/colorful-green-abstract-background_23-2148453700.jpg"),
                  fit: BoxFit.cover,
                ),
              ),
            ),
          ),
          Align(
            alignment: Alignment(0, 1),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: <Widget>[
                CircularProfileAvatar(
                  "https://www.clipartmax.com/png/middle/479-4798442_about-me-avatar-farmer.png",
                  borderWidth: ScreenUtil().setWidth(10),
                  radius: ScreenUtil().setSp(200),
                ),
                SizedBox(height: ScreenUtil().setHeight(20)),
                Text(
                  this.farmerInfoModel.name,
                  style: TextStyle(
                    fontSize: ScreenUtil().setSp(60),
                    fontWeight: FontWeight.bold,
                  ),
                ),
                Text(
                  this.farmerInfoModel.status == true ? "Đang hoạt động" : "Ngưng hoạt động",
                  style: TextStyle(
                    fontSize: ScreenUtil().setSp(35),
                    color: Colors.grey[700],
                  ),
                ),
              ],
            ),
          ),
          TopBar(),
        ],
      ),
    );
  }
}

class MyCustomClipper extends CustomClipper<Path> {
  @override
  Path getClip(Size size) {
    Path path = Path();
    path.lineTo(size.width, 0);
    path.lineTo(size.width, size.height - 150);
    path.lineTo(0, size.height);
    return path;
  }

  @override
  bool shouldReclip(CustomClipper<Path> oldClipper) {
    return true;
  }
}