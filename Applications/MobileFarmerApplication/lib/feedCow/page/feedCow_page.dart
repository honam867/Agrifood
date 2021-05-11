import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/feedcow/component/build_text_form_food.dart';
import 'package:AgrifoodApp/feedCow/component/select_drop_list_food.dart';
import 'package:AgrifoodApp/feedcow/model/drop_model_food.dart';
import 'package:AgrifoodApp/history/component/item_history.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
//import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';
//import 'package:quiver/iterables.dart';

class FeedCow extends StatefulWidget {
  final BuildContext contextfoodPage;
  final String routefoodName;
  const FeedCow({Key key, this.contextfoodPage, this.routefoodName, FoodSuggestionItem foodSuggestionItem})
      : super(key: key);
  @override
  _FeedCowState createState() => _FeedCowState();
}

class _FeedCowState extends State<FeedCow> {
  bool sended = false;
  bool _validate = false;
  int foodId;
  String status = "Đang tải", foodName = "";
  // FoodSuggestionItem optionItemSelected =
  //     FoodSuggestionItem(id: null, content: "Chọn loại thức ăn");
  TextEditingController quantityController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<FoodSuggestionBloc, FoodState>(
        builder: (context, state) {
      if (state is FoodLoadInprocess) {
        BlocProvider.of<FoodSuggestionBloc>(context).add(FoodLoadedSuccess());
      }
      if (state is FoodLoaded) {
        List<FoodSuggestionItem> test =
            state.foodSuggestionModel.foodSuggestionItem;
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
                child: Column(
              children: [
                Container(
                    color: Colors.lightGreen[50],
                    width: MediaQuery.of(context).size.width,
                    height: MediaQuery.of(context).size.height,
                    child: Padding(
                      padding: EdgeInsets.only(
                          top: ScreenUtil().setHeight(20.0),
                          bottom: ScreenUtil().setHeight(20.0),
                          left: ScreenUtil().setHeight(20.0),
                          right: ScreenUtil().setHeight(20.0)),
                      child: ListView.builder(
                          itemCount: test.length,
                          itemBuilder: (context, index) {
                            return Container(
                              height: MediaQuery.of(context).size.height,
                              width: MediaQuery.of(context).size.width,
                              child: ListTile(
                                title: Container(
                                  child: Column(
                                    children: [
                                      Container(
                                        child: Text(
                                          "Thức ăn thô",
                                          style: TextStyle(fontSize: 20.0),
                                        ),
                                        padding: EdgeInsets.all(10.0),
                                        margin: EdgeInsets.all(0.01),
                                        alignment: Alignment.center,
                                        width: 1200,
                                        decoration: BoxDecoration(
                                          color: Colors.orange[200],
                                          borderRadius: BorderRadius.all(
                                              Radius.circular(5.0)),
                                        ),
                                      ),
                                      Row(
                                        mainAxisAlignment:
                                            MainAxisAlignment.spaceAround,
                                        children: [
                                          Text(test[index].content ?? ''),
                                          Row(
                                            children: [
                                              buildTextFormFood(
                                                validatorText:
                                                    "Vui lòng không bỏ trống",

                                                nameController:
                                                    quantityController,
                                                width: 60.0,
                                                // changeValueFuction: changeValue
                                              ),
                                              Text(" Kg")
                                            ],
                                          ),
                                        ],
                                      ),
                                      Row(
                                        mainAxisAlignment:
                                            MainAxisAlignment.spaceAround,
                                        children: [
                                          Text(test[index].content ?? ''),
                                          Row(
                                            children: [
                                              buildTextFormFood(
                                                validatorText:
                                                    "Vui lòng không bỏ trống",

                                                nameController:
                                                    quantityController,
                                                width: 60.0,
                                                // changeValueFuction: changeValue
                                              ),
                                              Text(" Kg")
                                            ],
                                          ),
                                        ],
                                      ),
                                      Divider(
                                        height: 20,
                                        thickness: 1,
                                        color: Colors.grey,
                                      ),
                                      Container(
                                        child: Text(
                                          "Thức ăn tinh",
                                          style: TextStyle(fontSize: 20.0),
                                        ),
                                        padding: EdgeInsets.all(10.0),
                                        margin: EdgeInsets.all(0.01),
                                        alignment: Alignment.center,
                                        width: 1200,
                                        decoration: BoxDecoration(
                                          color: Colors.orange[200],
                                          borderRadius: BorderRadius.all(
                                              Radius.circular(5.0)),
                                        ),
                                      ),
                                      Row(
                                        mainAxisAlignment:
                                            MainAxisAlignment.spaceAround,
                                        children: [
                                          Text(test[index].content ?? ''),
                                          Row(
                                            children: [
                                              buildTextFormFood(
                                                validatorText:
                                                    "Vui lòng không bỏ trống",

                                                nameController:
                                                    quantityController,
                                                width: 60.0,
                                                // changeValueFuction: changeValue
                                              ),
                                              Text(" Kg")
                                            ],
                                          ),
                                        ],
                                      ),
                                      Row(
                                        mainAxisAlignment:
                                            MainAxisAlignment.spaceAround,
                                        children: [
                                          Text(test[index].content ?? ''),
                                          Row(
                                            children: [
                                              buildTextFormFood(
                                                validatorText:
                                                    "Vui lòng không bỏ trống",

                                                nameController:
                                                    quantityController,
                                                width: 60.0,
                                                // changeValueFuction: changeValue
                                              ),
                                              Text(" Kg")
                                            ],
                                          ),
                                        ],
                                      ),
                                      Container(
                                        padding: EdgeInsets.only(top: 20.0),
                                        child: OutlinedButton(
                                          onPressed: () {},
                                          style: ButtonStyle(
                                            backgroundColor:
                                                MaterialStateProperty
                                                    .resolveWith<Color>(
                                              (Set<MaterialState> states) {
                                                if (states.contains(
                                                    MaterialState.pressed))
                                                  return Colors.green[300];
                                                return colorApp; // Use the component's default.
                                              },
                                            ),
                                            shape: MaterialStateProperty.all(
                                                RoundedRectangleBorder(
                                                    borderRadius:
                                                        BorderRadius.circular(
                                                            10.0))),
                                          ),
                                          child: Text(
                                            "Gửi",
                                            style: TextStyle(
                                                fontSize:
                                                    ScreenUtil().setSp(80),
                                                color: Colors.white),
                                          ),
                                        ),
                                      ),
                                    ],
                                  ),
                                ),
                              ),
                            );
                          }),
                    )),
              ],
            )),
          ),
        );
      }

      return SplashPage();
    });
  }
}

Widget buildItem({title, string}) {
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
