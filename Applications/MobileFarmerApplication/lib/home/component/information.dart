import 'package:AgrifoodApp/home/component/detail_profile.dart';
import 'package:AgrifoodApp/home/component/stack_container.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';

class UserInformation extends StatefulWidget {
  final BuildContext contextHome;
  final UserInfoModel userInfoModel;

  const UserInformation({Key key, this.contextHome, this.userInfoModel}) : super(key: key);
  @override
  _UserInformationState createState() => _UserInformationState();
}

class _UserInformationState extends State<UserInformation> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            StackContainer(userInfoModel: widget.userInfoModel,),
            CardItem(contextHome: widget.contextHome,userInfoModel: widget.userInfoModel,)
           
          ],
        ),
      ),
    );
  }
}
