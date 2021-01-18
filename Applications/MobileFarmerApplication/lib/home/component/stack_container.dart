import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:flutter/material.dart';
import 'top_bar.dart';
import 'package:circular_profile_avatar/circular_profile_avatar.dart';

class StackContainer extends StatelessWidget {
  final UserInfoModel userInfoModel;
  const StackContainer({
    Key key, this.userInfoModel
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 300.0,
      child: Stack(
        children: <Widget>[
          Container(),
          ClipPath(
            clipper: MyCustomClipper(),
            child: Container(
              height: 300.0,
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
                  borderWidth: 4.0,
                  radius: 60.0,
                ),
                SizedBox(height: 4.0),
                Text(
                  this.userInfoModel.userName,
                  style: TextStyle(
                    fontSize: 21.0,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                Text(
                  this.userInfoModel.status == true ? "Đang hoạt động" : "Ngưng hoạt động",
                  style: TextStyle(
                    fontSize: 12.0,
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