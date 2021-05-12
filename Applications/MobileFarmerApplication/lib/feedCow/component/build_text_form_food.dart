import 'package:AgrifoodApp/feedCow/model/food_item.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

typedef SetTextFuction2 = void Function(
    {TextEditingController controller,
    String value,
    FoodItem foodItem,
    int feedHistoryId});
typedef AddControllerToList = void Function({TextEditingController controller});
typedef SetFoodItem = void Function(
    {TextEditingController textEditingController,
    FoodItem foodItem,
    int feedHistoryId});

class TextFieldFeedCow extends StatefulWidget {
  final SetTextFuction2 setTextFuction2;
  final TextEditingController valueController;
  final String validatorText;
  final FoodItem foodItem;
  final feedHistoryId;
  final double width;
  final AddControllerToList addControllerToList;

  const TextFieldFeedCow(
      {Key key,
      this.setTextFuction2,
      this.valueController,
      this.validatorText,
      this.width,
      this.foodItem,
      this.addControllerToList,
      this.feedHistoryId})
      : super(key: key);
  @override
  _TextFieldFeedCowState createState() => _TextFieldFeedCowState();
}

class _TextFieldFeedCowState extends State<TextFieldFeedCow> {
  TextEditingController controller = new TextEditingController();
  @override
  Widget build(BuildContext context) {
    String hint = "Kg";

    return Padding(
        padding: EdgeInsets.only(
          top: ScreenUtil().setSp(50.0),
        ),
        child: Container(
          height: ScreenUtil().setHeight(200.0),
          width: ScreenUtil().setWidth(200.0),
          child: TextField(
            //keyboardType: TextInputType.number,
            controller: controller,
            decoration: InputDecoration(
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xff9CCC65)),
                  //borderRadius: BorderRadius.all(Radius.circular(30)),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xff9CCC65)),
                  borderRadius: BorderRadius.all(Radius.circular(
                    ScreenUtil().setSp(40.0),
                  )),
                ),
                hintText: hint),
            maxLength: 3,

            onSubmitted: (value) {
              widget.addControllerToList(controller: controller);
              widget.setTextFuction2(
                  value: value,
                  feedHistoryId: widget.feedHistoryId,
                  controller: controller,
                  foodItem: widget.foodItem);
              print(value);
            },
            // onFieldSubmitted: (value) {

            // },
            // onSaved: (String value) {
            //   widget.setTextFuction2(value: value, controller: controller);
            //   widget.setFoodItem(
            //       foodSuggestionItem: widget.foodSuggestionItem,
            //       textEditingController: controller);
            // },
          ),
        ));
  }
}
