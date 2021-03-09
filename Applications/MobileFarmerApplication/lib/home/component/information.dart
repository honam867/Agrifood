import 'package:AgrifoodApp/home/component/detail_profile.dart';
import 'package:AgrifoodApp/home/component/stack_container.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class UserInformation extends StatefulWidget {
  final BuildContext contextHome;
  final FarmerInfoModel farmerInfoModel;

  const UserInformation({Key key, this.contextHome, this.farmerInfoModel}) : super(key: key);
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
            StackContainer(farmerInfoModel: widget.farmerInfoModel,),
            CardItem(contextHome: widget.contextHome,farmerInfoModel: widget.farmerInfoModel,)
           
          ],
        ),
      ),
    );
  }
}
