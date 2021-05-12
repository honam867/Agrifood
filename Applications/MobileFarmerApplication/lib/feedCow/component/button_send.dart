import 'package:AgrifoodApp/feedCow/model/feed_history_detail_item.dart';
import 'package:AgrifoodApp/feedCow/model/food_item.dart';
import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

import '../../foodSuggestion/model/foodSuggestion_item.dart';

class ButtonSend extends StatefulWidget {
  final List<TextEditingController> listTestEditController;
  final List<TextEditingController> listTextEditControllerBoTinh;

  final List<FoodItem> listbotho;

  final List<FoodItem> listbotinh;
  final List<FeedHistoryDetailItem> list;

  const ButtonSend(
      {Key key,
      this.listTestEditController,
      this.listbotho,
      this.listbotinh,
      this.list,
      this.listTextEditControllerBoTinh})
      : super(key: key);

  @override
  _ButtonSendState createState() => _ButtonSendState();
}

class _ButtonSendState extends State<ButtonSend> {
  void sendFood({FeedHistoryDetailItem feedHistoryDetailItem}) {}

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<FoodSuggestionBloc, FoodState>(
      builder: (context, state) {
        return Container(
            color: Colors.lightGreen[50],
            width: MediaQuery.of(context).size.width,
            height: MediaQuery.of(context).size.height,
            child: Padding(
                padding: EdgeInsets.only(
                    top: ScreenUtil().setHeight(20.0),
                    bottom: ScreenUtil().setHeight(20.0),
                    left: ScreenUtil().setHeight(20.0),
                    right: ScreenUtil().setHeight(20.0)),
                child: Column(
                  children: [
                    Container(
                      padding: EdgeInsets.only(top: 20.0),
                      child: OutlinedButton(
                        onPressed: () {
                          widget.list.forEach((element) {
                            BlocProvider.of<FoodSuggestionBloc>(context)
                                .add(SendFoodEvent(element));
                            print(element);
                          });
                        },
                        style: ButtonStyle(
                          backgroundColor:
                              MaterialStateProperty.resolveWith<Color>(
                            (Set<MaterialState> states) {
                              if (states.contains(MaterialState.pressed))
                                return Colors.green[300];
                              return colorApp; // Use the component's default.
                            },
                          ),
                          shape: MaterialStateProperty.all(
                              RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(10.0))),
                        ),
                        child: Text(
                          "Gửi",
                          style: TextStyle(
                              fontSize: ScreenUtil().setSp(80),
                              color: Colors.white),
                        ),
                      ),
                    ),
                  ],
                )));
      },
    );
  }
}
