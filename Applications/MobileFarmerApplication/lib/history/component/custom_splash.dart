import 'package:flutter/cupertino.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

class CustomSplashPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.only(top: 20),
      width: 50,
      child: Center(
        child: CircularProgressIndicator(),
      ),
    );
  }
}

class CustomNondataSizeBox extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 200, // Some height
      child: Center(
        child: Text("Không có báo cáo nào"),
      ),
    );
  }
}
