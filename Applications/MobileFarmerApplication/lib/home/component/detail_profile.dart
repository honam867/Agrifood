import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CardItem extends StatelessWidget {
  final BuildContext contextHome;
  final FarmerInfoModel farmerInfoModel;
  const CardItem({Key key, this.contextHome, this.farmerInfoModel})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        item(title: "Tên tài khoản", detail: this.farmerInfoModel.name ?? "", urlImage: "assets/profile/name.png"),
        item(
            title: "Trạng thái",
            detail: this.farmerInfoModel.status ?? true
                ? "Đang hoạt động"
                : "Ngưng hoạt động", urlImage: "assets/profile/status.png"),
        item(title: "Số điện thoại", detail: this.farmerInfoModel.phoneNumber ?? "", urlImage: "assets/profile/phone.png"),
        item(title: "Số điện thoại bàn", detail: this.farmerInfoModel.landLine ?? "" , urlImage: "assets/profile/landline.png" ),
        item(title: "Email", detail: this.farmerInfoModel.email ?? "", urlImage: "assets/profile/email.png"),
        item(
            title: "Đại chỉ",
            detail: this.farmerInfoModel.address ?? "", urlImage: "assets/profile/calendar.png"),
        item(
            title: "Giới tính",
            detail: this.farmerInfoModel.gender == true ? "Nam" : "Nữ", urlImage: "assets/profile/personplus.png"),
      ],
    );
  }
}

Widget item({String title, String detail, String urlImage}) {
  return Padding(
    padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
    child: Card(
      child: Padding(
        padding:  EdgeInsets.symmetric(
          horizontal: ScreenUtil().setWidth(40),
          vertical: ScreenUtil().setHeight(60),
        ),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: <Widget>[
            Image(
              image: AssetImage(urlImage),
              height: ScreenUtil().setHeight(120),
            ),
            SizedBox(width: ScreenUtil().setWidth(55)),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisSize: MainAxisSize.min,
              children: <Widget>[
                Text(
                  title,
                  style: TextStyle(
                    fontSize: ScreenUtil().setSp(50),
                  ),
                ),
                SizedBox(height: ScreenUtil().setHeight(20)),
                Text(
                  detail,
                  style: TextStyle(
                    color: Colors.grey[700],
                    fontSize: ScreenUtil().setSp(40),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    ),
  );
}
