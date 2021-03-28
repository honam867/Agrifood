import 'package:AgrifoodApp/byre/model/byre_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/cow_page.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ChapterCard extends StatelessWidget {
  final ByreItem byreItem;
  final Function press;
  const ChapterCard({
    Key key,
    this.byreItem,
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
              blurRadius: 33,
              color: Color(0xFFD3D3D3).withOpacity(.84),
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
                child: Image.asset('assets/layout/stable.png',
                    width: ScreenUtil().setWidth(100),
                    height: ScreenUtil().setHeight(100),
                    fit: BoxFit.fill),
              ),
            ),
            Container(height: 40, child: VerticalDivider(color: Colors.black)),
            InkWell(
              child: Column(
                children: [
                  RichText(
                    text: TextSpan(
                      children: [
                        TextSpan(
                          text: "Mã ${this.byreItem.code}",
                          style: TextStyle(
                            fontSize: ScreenUtil().setSp(60),
                            color: Colors.black,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ],
                    ),
                  ),
                  Container(
                      width: MediaQuery.of(context).size.width / ScreenUtil().setWidth(8),
                      child: Divider(color: Colors.transparent)),
                  RichText(
                    text: TextSpan(
                      children: [
                        TextSpan(
                          text: "${this.byreItem.name}",
                          style: TextStyle(
                            fontSize: ScreenUtil().setSp(50),
                            color: Colors.black,
                            fontWeight: FontWeight.bold,
                          ),
                        )
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
                size: ScreenUtil().setSp(60),
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
                        child: CowPage(
                          byreId: this.byreItem.id,
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
