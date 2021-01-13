import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class UserInformation extends StatefulWidget {
  @override
  _UserInformationState createState() => _UserInformationState();
}

class _UserInformationState extends State<UserInformation> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Thông tin người dùng"),
        leading: IconButton(
          icon: Icon(Icons.backpack_outlined),
          onPressed: () => Navigator.pop(context)
        ),
      ),
      body: Center(child: Text("Đây là trang thông tin người dùng"),),
    );
  }
}
