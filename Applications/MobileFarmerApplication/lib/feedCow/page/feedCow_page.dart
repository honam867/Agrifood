import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/screen_util.dart';

class FeedCow extends StatefulWidget {
  final FoodSuggestionItem foodSuggestionItem;
  const FeedCow({Key key, this.foodSuggestionItem}) : super(key: key);
  @override
  _FeedCowState createState() => _FeedCowState();
}

class _FeedCowState extends State<FeedCow> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: colorApp,
          title: Text("Cho bò ăn"),
          leading: IconButton(
            icon: Icon(Icons.navigate_before), 
            onPressed: (){
              Navigator.pop(context);
            }
          ),
        ),
        body: Container(
              width: double.infinity,
              height: double.infinity,
              child: Column(
                children: <Widget>[
                  Expanded(
                    child: Container(
                      child: ListTile(
                        title: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            builItem(
                              title: widget.foodSuggestionItem.content),
                            Divider(
                              height: 20,
                              thickness: 1,
                              color: Colors.grey,
                            ),
                            // builItem(
                            //     title: "Id bò cha: ",
                            //     string: widget.foodSuggestionItem.fatherId.toString()),
                            // Divider(
                            //   height: 20,
                            //   thickness: 1,
                            //   color: Colors.grey,
                            // ),
                            // builItem(
                            //     title: "Id bò mẹ: ",
                            //     string: widget.foodSuggestionItem.motherId.toString()),
                            // Divider(
                            //   height: 20,
                            //   thickness: 1,
                            //   color: Colors.grey,
                            // ),
                            // builItem(
                            //     title: "Chuồng: ",
                            //     string: widget.cowItem.byreName ?? ""),
                            // Divider(
                            //   height: 20,
                            //   thickness: 1,
                            //   color: Colors.grey,
                            // ),
                            // builItem(
                            //     title: "Mã bò: ", string: widget.cowItem.code),
                            // Divider(
                            //   height: 20,
                            //   thickness: 1,
                            //   color: Colors.grey,
                            //),
                          ],
                        ),
                      ),
                      // decoration: BoxDecoration(
                      //   color: Colors.green[100],
                      //   borderRadius: BorderRadius.only(
                      //     topLeft: Radius.circular(20),
                      //     topRight: Radius.circular(20),
                      //     bottomLeft: Radius.circular(75),
                      //     bottomRight: Radius.circular(75),
                      // )),
                    ),
                  )
                ],
              ),
            ),
      ),
    );
  }
}

Widget builItem({title, string}) {
  return Row(
    crossAxisAlignment: CrossAxisAlignment.center,
    mainAxisAlignment: MainAxisAlignment.spaceBetween,
    children: [
      Padding(
        padding: EdgeInsets.only(top: ScreenUtil().setHeight(60)),
        child: Text(title, style: TextStyles.labelTextStyle),
      ),
      Padding(
        padding: EdgeInsets.only(top: ScreenUtil().setHeight(60)),
        child: Text(string, style: TextStyles.detailTextCow),
      ),
    ],
  );
}
