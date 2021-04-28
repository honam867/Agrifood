import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_detail_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class CowCard extends StatelessWidget {
  final CowItem cowItem;
  final Function press;
  const CowCard({
    Key key,
    this.cowItem,
    this.press,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(20)),
      child: Container(
        padding: EdgeInsets.symmetric(
            vertical: ScreenUtil().setHeight(40),
            horizontal: ScreenUtil().setWidth(60)),
        margin: EdgeInsets.only(bottom: 16),
        width: size.width - 48,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(38.5),
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
                  top: ScreenUtil().setSp(5), right: ScreenUtil().setWidth(25)),
              child: ClipRRect(
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(8.0),
                  topRight: Radius.circular(8.0),
                ),
                child: Image.asset('assets/layout/cowmale.png',
                    width: ScreenUtil().setWidth(100),
                    height: ScreenUtil().setHeight(100),
                    fit: BoxFit.fill),
              ),
            ),
            Container(
                height: ScreenUtil().setHeight(150),
                child: VerticalDivider(color: Colors.black)),
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
                                text: "Tên Bò: ",
                                style: GoogleFonts.notoSerif(
                                  fontSize: ScreenUtil().setSp(50),
                                  color: Colors.black87,
                                  fontWeight: FontWeight.bold,
                                )),
                            TextSpan(
                              text: this.cowItem.name,
                              style: GoogleFonts.notoSans(
                                  fontSize: ScreenUtil().setSp(60),
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
                            text: "Mã: ",
                            style: GoogleFonts.notoSerif(
                              fontSize: ScreenUtil().setSp(50),
                              color: Colors.black87,
                              fontWeight: FontWeight.bold,
                            )),
                        TextSpan(
                          text: cowItem.code,
                          style: TextStyle(
                            fontSize: ScreenUtil().setSp(50),
                            color: Colors.black,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
            Spacer(),
            IconButton(
              icon: Icon(
                Icons.arrow_forward_ios,
                size: ScreenUtil().setSp(60.0),
              ),
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => BlocProvider(
                        create: (context) => CowBloc(
                            cowRepository: CowRepository(),
                            foodSuggestionRepository:
                                FoodSuggestionRepository()),
                        child: FormDetailCow(
                          cowItem: this.cowItem,
                        ),
                      ),
                    ));
              },
            )
          ],
        ),
      ),
    );
  }
}
