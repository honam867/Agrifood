import 'package:AgrifoodApp/home/model/notification_item.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/screen_util.dart';
import 'package:google_fonts/google_fonts.dart';

class NotiCard extends StatelessWidget {
  final NotificationItem notiItem;
  const NotiCard({Key key, this.notiItem}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(20)),
      child: Container(
        padding: EdgeInsets.symmetric(
            vertical: ScreenUtil().setHeight(20),
            horizontal: ScreenUtil().setWidth(60)),
        margin: EdgeInsets.only(bottom: 16),
        width: size.width - 48,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(15.0),
          boxShadow: [
            BoxShadow(
              offset: Offset(0, 10),
              blurRadius: 1,
              color: Colors.grey[400].withOpacity(.84),
            ),
          ],
        ),
        child: Row(
          children: <Widget>[
            Padding(
              padding: EdgeInsets.only(
                  top: ScreenUtil().setHeight(5), right: ScreenUtil().setWidth(25)),
              child: ClipRRect(
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(8.0),
                  topRight: Radius.circular(8.0),
                ),
                child: Image.asset('assets/crud/research.png',
                    width: ScreenUtil().setWidth(100),
                    height: ScreenUtil().setHeight(100),
                    fit: BoxFit.fill),
              ),
            ),
            Container(
                height: ScreenUtil().setHeight(200),
                child: VerticalDivider(thickness: 1,),),
            InkWell(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      RichText(
                        text: TextSpan(
                          children: [
                            TextSpan(
                                text: "Tiêu đề: ",
                                style: GoogleFonts.notoSerif(
                                  fontSize: ScreenUtil().setSp(50),
                                  color: Colors.black87,
                                  fontWeight: FontWeight.bold,
                                )),
                            TextSpan(
                              text: this.notiItem.name,
                              style: GoogleFonts.notoSans(
                                fontSize: ScreenUtil().setSp(55),
                                color: Colors.black87,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                  Container(
                      width: MediaQuery.of(context).size.width /
                          ScreenUtil().setWidth(8),
                      child: Divider(color: Colors.transparent)),
                  RichText(
                    text: TextSpan(
                      children: [
                        TextSpan(
                            text: "Nội dung: ",
                            style: GoogleFonts.notoSerif(
                              fontSize: ScreenUtil().setSp(50),
                              color: Colors.black87,
                              fontWeight: FontWeight.bold,
                            )),
                        TextSpan(
                          text: this.notiItem.content,
                          style: GoogleFonts.notoSans(
                            fontSize: ScreenUtil().setSp(55),
                            color: Colors.black87,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                  Container(
                      width: MediaQuery.of(context).size.width /
                          ScreenUtil().setWidth(8),),
                ],
              ),
            ),
            Spacer(),
          ],
        ),
      ),
    );
  }
}
