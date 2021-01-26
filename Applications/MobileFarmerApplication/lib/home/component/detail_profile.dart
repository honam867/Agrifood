import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/home/model/userInfo_model.dart';
import 'package:AgrifoodApp/ui/utils/format.dart';
import 'package:flutter/material.dart';

class CardItem extends StatelessWidget {
  final BuildContext contextHome;
  final FarmerInfoModel farmerInfoModel;
  const CardItem({Key key, this.contextHome, this.farmerInfoModel})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        item(title: "Tên tài khoản", detail: this.farmerInfoModel.name, urlImage: "assets/profile/name.png"),
        item(
            title: "Trạng thái",
            detail: this.farmerInfoModel.status == true
                ? "Đang hoạt động"
                : "Ngưng hoạt động", urlImage: "assets/profile/status.png"),
        item(title: "Số điện thoại", detail: this.farmerInfoModel.phoneNumber, urlImage: "assets/profile/phone.png"),
        item(title: "Email", detail: this.farmerInfoModel.email, urlImage: "assets/profile/email.png"),
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
    padding: EdgeInsets.symmetric(horizontal: 16.0),
    child: Card(
      child: Padding(
        padding: const EdgeInsets.symmetric(
          horizontal: 16.0,
          vertical: 21.0,
        ),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: <Widget>[
            Image(
              image: AssetImage(urlImage),
              height: 40,
            ),
            SizedBox(width: 24.0),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisSize: MainAxisSize.min,
              children: <Widget>[
                Text(
                  title,
                  style: TextStyle(
                    fontSize: 18.0,
                  ),
                ),
                SizedBox(height: 4.0),
                Text(
                  detail,
                  style: TextStyle(
                    color: Colors.grey[700],
                    fontSize: 12.0,
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
