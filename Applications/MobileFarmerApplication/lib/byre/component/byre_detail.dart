import 'package:AgrifoodApp/byre/model/byre_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_cubit.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/cow_page.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/list_cow.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
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
        padding: EdgeInsets.symmetric(vertical: ScreenUtil().setHeight(40), horizontal: ScreenUtil().setWidth(60)),
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
            Column(
              children: [
                RichText(
                  text: TextSpan(
                    children: [
                      TextSpan(
                        text:
                            "Mã ${this.byreItem.code} - ${this.byreItem.name} \n",
                        style: TextStyle(
                          fontSize: 16,
                          color: Colors.black,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                ),
                RichText(
                  text: TextSpan(
                    children: [
                      TextSpan(
                        text:
                            "Có ${this.byreItem.quantityCow} ${this.byreItem.breedId}",
                        style: TextStyle(
                          fontSize: ScreenUtil().setSp(30),
                          color: Colors.black,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
            Spacer(),
            IconButton(
              icon: Icon(
                Icons.arrow_forward_ios,
                size: 18,
              ),
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => BlocProvider(
                        create: (context) => CowCubit(CowRepository()),
                        child: CowPage(),
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
