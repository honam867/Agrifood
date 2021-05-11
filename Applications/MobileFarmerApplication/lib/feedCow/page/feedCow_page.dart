import 'package:AgrifoodApp/feedCow/component/build_item.dart';
import 'package:AgrifoodApp/feedCow/component/build_text_form_food.dart';
import 'package:AgrifoodApp/feedCow/component/button_send.dart';
import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

class FeedCow extends StatefulWidget {
  final BuildContext contextfoodPage;
  final String routefoodName;
  const FeedCow(
      {Key key,
      this.contextfoodPage,
      this.routefoodName,
      FoodSuggestionItem foodSuggestionItem})
      : super(key: key);
  @override
  _FeedCowState createState() => _FeedCowState();
}

class _FeedCowState extends State<FeedCow> {
  bool sended = false;
  bool isShow = false;
  int foodId;
  String status = "Đang tải", foodName = "";
  FoodSuggestionItem optionItemSelected =
      FoodSuggestionItem(id: null, name: "Chọn loại thức ăn");

  List<FoodSuggestionItem> list;
  List<FoodSuggestionItem> listResoult;
  TextEditingController quantityController;

  void showed() {
    setState(() {
      isShow = !isShow ;
    });
  }

  void setText({TextEditingController controller, String value}) {
    setState(() {
      controller.text = value;
      print(value);
    });
  }

  @override
  Widget build(BuildContext context) {
    double height = 105;
    var media = MediaQuery.of(context).size;
    var textEditingControllers = <TextEditingController>[];

    return BlocBuilder<FoodSuggestionBloc, FoodState>(
        builder: (context, state) {
      if (state is FoodLoadInprocess) {
        BlocProvider.of<FoodSuggestionBloc>(context).add(FoodLoadedSuccess());
      }
      if (state is FoodLoaded) {
        list = state.foodSuggestionModel.foodSuggestionItem;
        final listBoKho = state.listBoKho;
        final listBoTinh = state.listBoTinh;

        return SafeArea(
          child: Scaffold(
            backgroundColor: Colors.lightGreen[50],
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
                listBoKho.length > 0
                    ? Column(
                        children: [
                          Padding(
                              padding: EdgeInsets.symmetric(
                                  horizontal: ScreenUtil().setHeight(20),
                                  vertical: ScreenUtil().setWidth(30)),
                              child: ContaineTitleFeed(
                                  title: "Thức ăn thô", showFood: showed)),
                          isShow == false
                              ? Container(
                                  height: height * (listBoKho.length + 0.2),
                                  width: media.width,
                                  child: ListView.builder(
                                      physics: NeverScrollableScrollPhysics(),
                                      itemCount: listBoKho.length,
                                      itemBuilder: (context, index) {
                                        textEditingControllers
                                            .add(quantityController);
                                        return ListTile(
                                          title: Container(
                                            height: ScreenUtil().setHeight(400),
                                            width: media.width /
                                                ScreenUtil().setWidth(2),
                                            child: Column(
                                              children: [
                                                Row(
                                                  mainAxisAlignment:
                                                      MainAxisAlignment
                                                          .spaceAround,
                                                  children: <Widget>[
                                                    Icon(Icons.food_bank),
                                                    Text(listBoKho[index]
                                                            .name ??
                                                        ''),
                                                    Row(
                                                      mainAxisAlignment:
                                                          MainAxisAlignment
                                                              .spaceBetween,
                                                      crossAxisAlignment:
                                                          CrossAxisAlignment
                                                              .center,
                                                      children: [
                                                        TextFieldFeedCow(
                                                          setTextFuction2:
                                                              setText,
                                                          validatorText:
                                                              "Vui lòng không bỏ trống",
                                                          valueController:
                                                              textEditingControllers[
                                                                  index],
                                                          width: ScreenUtil()
                                                              .setWidth(60),
                                                        ),
                                                        Text(" Kg")
                                                      ],
                                                    ),
                                                  ],
                                                ),
                                                Divider(
                                                  height: ScreenUtil()
                                                      .setHeight(70),
                                                  thickness: 5,
                                                  color: Colors.lightGreen[200],
                                                ),
                                              ],
                                            ),
                                          ),
                                        );
                                      }))
                              : SizedBox(),
                        ],
                      )
                    : SizedBox(),
                listBoTinh.length > 0
                    ? Column(children: [
                      
                        ContaineTitleFeed(title: "Thức ăn tinh", showFood: showed),
                        Container(
                            height: height * (listBoTinh.length + 0.2),
                            width: MediaQuery.of(context).size.width,
                            child: ListView.builder(
                                physics:  NeverScrollableScrollPhysics(),
                                itemCount: listBoTinh.length,
                                itemBuilder: (context, index) {
                                  return ListTile(
                                    title: Container(
                                      height: ScreenUtil().setHeight(400),
                                      width: MediaQuery.of(context).size.width /
                                          ScreenUtil().setWidth(2),
                                      child: Column(
                                        children: [
                                          Row(
                                            mainAxisAlignment:
                                                MainAxisAlignment.spaceAround,
                                            children: [
                                              Text(listBoTinh[index].name ??
                                                  ''),
                                              Row(
                                                children: [
                                                  TextFieldFeedCow(
                                                    validatorText:
                                                        "Vui lòng không bỏ trống",
                                                    valueController: null,
                                                    width: ScreenUtil()
                                                        .setWidth(60),
                                                  ),
                                                  Text(" Kg")
                                                ],
                                              ),
                                            ],
                                          ),
                                          Divider(
                                            height: ScreenUtil().setHeight(30),
                                            thickness: 1,
                                            color: Colors.grey,
                                          ),
                                        ],
                                      ),
                                    ),
                                  );
                                })),
                      ])
                    : SizedBox(),
                Container(
                    height: ScreenUtil().setHeight(300), child: ButtonSend())
              ],
            )),
          ),
        );
      }

      return SplashPage();
    });
  }
}
