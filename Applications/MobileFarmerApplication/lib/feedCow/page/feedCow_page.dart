import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/feedCow/component/select_drop_list_food.dart';
import 'package:AgrifoodApp/feedcow/model/drop_model_food.dart';
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
  const FeedCow(
      {Key key,
      this.contextfoodPage,
      this.routefoodName})
      : super(key: key);
  @override
  _FeedCowState createState() => _FeedCowState();
}

class _FeedCowState extends State<FeedCow> {
  bool sended = false;
  bool _validate = false;
  int foodId;
  String status = "Đang tải", foodName = "";
  FoodSuggestionItem optionItemSelected =
      FoodSuggestionItem(id: null, content: "Chọn loại thức ăn");
  TextEditingController quantiTyController = TextEditingController();
  int _counter = 0;
  void increment() {
    setState(() {
      _counter++;
    });
  }

  void decrement() {
    setState(() {
      _counter--;
    });
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<FoodSuggestionBloc, FoodState>(
        builder: (context, state) {
      if (state is FoodLoadInprocess) {
        BlocProvider.of<FoodSuggestionBloc>(context).add(FoodLoadedSuccess());
      }
      if (state is FoodLoaded) {
        DropListFoodModel dropListFoodModel =
            DropListFoodModel(state.foodSuggestionModel.foodSuggestionItem);
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
                child: Column(
                  children: [
                    //sended == false
                    Padding(
                      padding: EdgeInsets.only(
                          top: ScreenUtil().setHeight(20.0),
                          bottom: ScreenUtil().setHeight(10.0),
                          left: ScreenUtil().setHeight(20.0),
                          right: ScreenUtil().setHeight(20.0)),
                      child: Container(
                        width: MediaQuery.of(context).size.width,
                        // child: SelectDropListFood(
                        //   this.optionItemSelected,
                        //   dropListFoodModel,
                        //   (optionItem) {
                        //     optionItemSelected = optionItem;
                        //     setState(() {
                        //       foodId = int.parse(optionItem.id.toString());
                        //       foodName = optionItem.content;
                        //       print(foodId);
                        //     });
                        //   },
                        // ),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          children: <Widget>[
                            Text(
                                        "Số lượng:",
                                        style: TextStyles.labelTextStyle,
                                      ),
                                      SizedBox(
                                        width: ScreenUtil().setWidth(10.0),
                                      ),
                                      Container(
                                        height: ScreenUtil().setWidth(120.0),
                                        width:
                                            MediaQuery.of(context).size.width -
                                                ScreenUtil().setWidth(600.0),
                            child:
                            TextField(
                              decoration: InputDecoration(
                                errorText: _validate == true
                                    ? 'Không được bỏ trống'
                                    : null,
                              ),
                              // enabled:
                              //     sended == true ? false : true,
                              controller: quantiTyController,
                              keyboardType: TextInputType.phone,
                            ),
                            
                                      )
                          ],
                        ),
                      ),
                    )
                    //     : Padding(
                    //         padding: EdgeInsets.all(ScreenUtil().setHeight(10.0)),
                    //         child: Row(
                    //           crossAxisAlignment:
                    //               CrossAxisAlignment.center,
                    //           children: [
                    //             Text(
                    //               "Bò:",
                    //               style: TextStyles.labelTextStyle,
                    //             ),
                    //             SizedBox(
                    //               width: ScreenUtil().setWidth(20.0)
                    //             ),
                    //             RichText(
                    //                 text: TextSpan(
                    //               text: cowName,
                    //               style: DefaultTextStyle.of(context)
                    //                   .style,
                    //             ))
                    //           ],
                    //         )),
                    // Padding(
                    //     padding: EdgeInsets.all(ScreenUtil().setWidth(20.0)),
                    //     child: Row(
                    //       crossAxisAlignment:
                    //           CrossAxisAlignment.center,
                    //       children: [
                    //         Text(
                    //           "Số lượng:",
                    //           style: TextStyles.labelTextStyle,
                    //         ),
                    //         SizedBox(
                    //           width: ScreenUtil().setWidth(10.0),
                    //         ),
                    //         Container(
                    //           height: ScreenUtil().setWidth(120.0),
                    //           width:
                    //               MediaQuery.of(context).size.width -
                    //                   ScreenUtil().setWidth(600.0),
                    //           child: TextField(
                    //             decoration: InputDecoration(
                    //               errorText: _validate == true
                    //                   ? 'Không được bỏ trống'
                    //                   : null,
                    //             ),
                    //             enabled:
                    //                 sended == true ? false : true,
                    //             controller: quantiTyController,
                    //             keyboardType: TextInputType.phone,
                    //           ),
                    //         ),
                    //         //ew Spacer(),
                    //         RichText(
                    //             text: TextSpan(
                    //           text: " ml",
                    //           style:
                    //               DefaultTextStyle.of(context).style,
                    //         ))
                    //       ],
                    //     )),
                    // Padding(
                    //     padding: EdgeInsets.all(ScreenUtil().setWidth(20.0)),
                    //     child: Row(
                    //       crossAxisAlignment:
                    //           CrossAxisAlignment.center,
                    //       children: [
                    //         Text(
                    //           "Ghi chú:",
                    //           style: TextStyles.labelTextStyle,
                    //         ),
                    //         SizedBox(
                    //           width: ScreenUtil().setWidth(10.0),
                    //         ),
                    //         Container(
                    //           height: ScreenUtil().setWidth(140.0),
                    //           width:
                    //               MediaQuery.of(context).size.width -
                    //                   ScreenUtil().setWidth(480.0),
                    //           child: TextField(
                    //             controller: noteController,
                    //             enabled:
                    //                 sended == true ? false : true,
                    //             keyboardType: TextInputType.multiline,
                    //           ),
                    //         )
                    //       ],
                    //     )),
                    // Divider(),
                    // Row(
                    //   crossAxisAlignment: CrossAxisAlignment.center,
                    //   mainAxisAlignment:
                    //       MainAxisAlignment.spaceAround,
                    //   children: [
                    //     FlatButton(
                    //         onPressed: () {
                    //           deleteItem();
                    //         },
                    //         child: Row(
                    //           crossAxisAlignment:
                    //               CrossAxisAlignment.center,
                    //           mainAxisAlignment:
                    //               MainAxisAlignment.center,
                    //           children: [
                    //             Icon(
                    //               Icons.delete,
                    //               color: Colors.redAccent,
                    //             ),
                    //             Text(
                    //               "Xóa",
                    //               style: TextStyle(
                    //                   color: Colors.redAccent),
                    //             )
                    //           ],
                    //         )),
                    //     FlatButton(
                    //         onPressed: sended == false
                    //             ? () {
                    //                 setState(() {
                    //                   quantiTyController.text.isEmpty
                    //                       ? _validate = true
                    //                       : _validate = false;
                    //                   if (isEdited == true) {
                    //                     MilkingSlipDetailItem
                    //                         milkingSlipDetailItem =
                    //                         new MilkingSlipDetailItem(
                    //                             id:
                    //                                 milkingSlipDetailId,
                    //                             cowId: cowId,
                    //                             milkingSlipId: widget
                    //                                 .milkingSlipId,
                    //                             note: noteController
                    //                                 .text,
                    //                             quantity: int.parse(
                    //                                 quantiTyController
                    //                                     .text));
                    //                     BlocProvider.of<
                    //                         MilkingSlipBloc>(context)
                    //                       ..add((MilkingSlipDetailUpdated(
                    //                           milkingSlipDetailItem)));
                    //                   } else {
                    //                     if (_validate == false) {
                    //                       MilkingSlipDetailItem
                    //                           milkingSlipDetailItem =
                    //                           new MilkingSlipDetailItem(
                    //                               cowId: cowId,
                    //                               milkingSlipId: widget
                    //                                   .milkingSlipId,
                    //                               note: noteController
                    //                                   .text,
                    //                               quantity: int.parse(
                    //                                   quantiTyController
                    //                                       .text));
                    //                       print(
                    //                           milkingSlipDetailItem);
                    //                       BlocProvider.of<
                    //                               MilkingSlipBloc>(
                    //                           context)
                    //                         ..add(CreateMilkingSlipDetail(
                    //                             milkingSlipDetailItem));
                    //                     }
                    //                   }
                    //                 });
                    //               }
                    //             : () {
                    //                 setState(() {
                    //                   isEdited = true;
                    //                   sended = false;
                    //                 });
                    //               },
                    //         child: Row(
                    //           crossAxisAlignment:
                    //               CrossAxisAlignment.center,
                    //           mainAxisAlignment:
                    //               MainAxisAlignment.center,
                    //           children: [
                    //             Icon(
                    //               isEdited == true ? Icons.edit : Icons.send,
                    //               color: sended == false
                    //                   ? Colors.yellowAccent
                    //                   : Colors.grey,
                    //             ),
                    //             Text(
                    //               isEdited == true ? "Chỉnh sửa" : "Gửi",
                    //               style: TextStyle(
                    //                   color: sended == false
                    //                       ? Colors.yellowAccent
                    //                       : Colors.grey),
                    //             )
                    //           ],
                    //         )),
                    //   ],
                    // )
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
              // );
              //}),)
              //],
            ),
          ),
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
