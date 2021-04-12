import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';
import 'package:quiver/iterables.dart';

class FeedCow extends StatefulWidget {
  final FoodSuggestionItem foodSuggestionItem;
  final BuildContext contextfoodPage;
  final String routefoodName;
  const FeedCow(
      {Key key,
      this.foodSuggestionItem,
      this.contextfoodPage,
      this.routefoodName})
      : super(key: key);
  @override
  _FeedCowState createState() => _FeedCowState();
}

class _FeedCowState extends State<FeedCow> {
  @override
  Widget build(BuildContext context) {
    return BlocBuilder<FoodSuggestionBloc, FoodState>(
        builder: (context, state) {
      if (state is FoodLoadInprocess) {
        BlocProvider.of<FoodSuggestionBloc>(context).add(FoodLoadedSuccess());
      }
      if (state is FoodLoaded) {
        var foodSugestion = state.foodSuggestionModel;
        return SafeArea(
          child: Scaffold(
              appBar: AppBar(
                backgroundColor: colorApp,
                title: Text("Cho bò ăn"),
                leading: IconButton(
                    icon: Icon(Icons.navigate_before),
                    onPressed: () {
                      Navigator.pop(context);
                    }),
              ),
              body: SingleChildScrollView(
                  child: Container(
                      width: MediaQuery.of(context).size.width,
                      height: MediaQuery.of(context).size.height,
                      child:Column(
                          children: <Widget>[
                            Expanded(
                                child: ListView.builder(
                                  itemExtent: 100,
                                  itemCount:
                                      foodSugestion.foodSuggestionItem.length,
                                  itemBuilder: (context, index) {
                                    return Container(
                                        child: ListTile(
                                          title: Column(
                                            crossAxisAlignment:
                                                CrossAxisAlignment.start,
                                            children: <Widget>[
                                              builItem(
                                                    title: foodSugestion
                                                            .foodSuggestionItem[
                                                                index]
                                                            .content ??
                                                        "",
                                                    string: "212a"),
                                              
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
                                      );
                                  }),)
                          ],
                        ),))),
        );
      }
      return CircularProgressIndicator();
    });
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
