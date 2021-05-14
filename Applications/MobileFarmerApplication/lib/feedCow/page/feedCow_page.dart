import 'package:AgrifoodApp/feedCow/component/build_item.dart';
import 'package:AgrifoodApp/feedCow/component/build_text_form_food.dart';
import 'package:AgrifoodApp/feedCow/component/button_send.dart';
import 'package:AgrifoodApp/feedCow/model/feed_history_detail_item.dart';
import 'package:AgrifoodApp/feedCow/model/food_item.dart';
import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

class FeedCow extends StatefulWidget {
  final BuildContext contextfoodPage;
  final String routefoodName;
  final int cowId;

  const FeedCow(
      {Key key,
      this.contextfoodPage,
      this.routefoodName,
      FoodSuggestionItem foodSuggestionItem,
      this.cowId})
      : super(key: key);
  @override
  _FeedCowState createState() => _FeedCowState();
}

class _FeedCowState extends State<FeedCow> {
  bool sended = false;
  bool isShow = false;
  int foodId;
  String status = "Đang tải", foodName = "";
  FoodItem optionItemSelected = FoodItem(id: null, name: "Chọn loại thức ăn");

  List<FoodItem> list;
  List<FoodItem> listResoult;
  TextEditingController quantityController;
  List<FoodItem> listFood = [];
  List<FeedHistoryDetailItem> listFeed = [];

  void showed() {
    setState(() {
      isShow = !isShow;
    });
  }

  void addFoodItem() {}

  void setText(
      {TextEditingController controller,
      String value,
      FoodItem foodItem,
      int feedHistoryId}) {
    setState(() {
      controller.text = value;
      FeedHistoryDetailItem feedHistoryDetailItem = new FeedHistoryDetailItem(
          foodId: foodItem.id,
          feedHistoryId: feedHistoryId,
          code: 'NYU',
          quantity: int.parse(controller.text));
      List<FeedHistoryDetailItem> l = [];
      l.add(feedHistoryDetailItem);
      listFeed.addAll(l);
      print(listFeed);
    });
  }

  @override
  Widget build(BuildContext context) {
    double height = 105;
    var media = MediaQuery.of(context).size;
    var textEditingControllers = <TextEditingController>[];
    var textEditContrllersBoTinh = <TextEditingController>[];

    void addController({TextEditingController controller}) {
      textEditingControllers.add(controller);
    }

    return BlocConsumer<FoodSuggestionBloc, FoodState>(
        listener: (context, state) {
      if (state is SendFoodLoaded) {
        if (state.result == "Thành công") {
          Navigator.pop(context);
        } else {
          BlocProvider.of<FoodSuggestionBloc>(context)
              .add(FoodLoadedSuccess(widget.cowId));
          final snackBar = SnackBar(content: Text('Gửi thất bại!'));
          ScaffoldMessenger.of(context).showSnackBar(snackBar);
        }
      }
    }, builder: (context, state) {
      if (state is FoodLoadInprocess) {
        BlocProvider.of<FoodSuggestionBloc>(context)
            .add(FoodLoadedSuccess(widget.cowId));
      }

      if (state is FoodLoaded) {
        list = state.foodModel.foodItem;
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
                                                    Text(
                                                        listBoKho[index].name ??
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
                                                          addControllerToList:
                                                              addController,
                                                          foodItem:
                                                              listBoKho[index],
                                                          feedHistoryId: state
                                                              .feedHistoryMasterId,
                                                          setTextFuction2:
                                                              setText,
                                                          validatorText:
                                                              "Vui lòng không bỏ trống",
                                                          valueController:
                                                              quantityController,
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
                        Padding(
                            padding: EdgeInsets.symmetric(
                                horizontal: ScreenUtil().setHeight(20),
                                vertical: ScreenUtil().setWidth(30)),
                            child: ContaineTitleFeed(
                                title: "Thức ăn tinh", showFood: showed)),
                        Container(
                            height: height * (listBoTinh.length + 0.2),
                            width: MediaQuery.of(context).size.width,
                            child: ListView.builder(
                                physics: NeverScrollableScrollPhysics(),
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
                                              Text(
                                                  listBoTinh[index].name ?? ''),
                                              Row(
                                                children: [
                                                  TextFieldFeedCow(
                                                    addControllerToList:
                                                        addController,
                                                    foodItem: listBoTinh[index],
                                                    setTextFuction2: setText,
                                                    feedHistoryId: state
                                                        .feedHistoryMasterId,
                                                    validatorText:
                                                        "Vui lòng không bỏ trống",
                                                    valueController:
                                                        quantityController,
                                                    width: ScreenUtil()
                                                        .setWidth(60),
                                                  ),
                                                  Text(" Kg")
                                                ],
                                              ),
                                            ],
                                          ),
                                          Divider(
                                            height: ScreenUtil().setHeight(70),
                                            thickness: 5,
                                            color: Colors.lightGreen[200],
                                          ),
                                        ],
                                      ),
                                    ),
                                  );
                                })),
                      ])
                    : SizedBox(),
                Container(
                    height: ScreenUtil().setHeight(300),
                    child: ButtonSend(
                        listTestEditController: textEditingControllers,
                        listTextEditControllerBoTinh: textEditContrllersBoTinh,
                        listbotho: listBoKho,
                        listbotinh: listBoTinh,
                        list: listFeed))
              ],
            )),
          ),
        );
      }

      return SplashPage();
    });
  }
}
