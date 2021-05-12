import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

typedef SetTextFuction2 = void Function(
    {TextEditingController controller, String value});

class TextFieldFeedCow extends StatefulWidget {
  final  SetTextFuction2 setTextFuction2;
  final TextEditingController valueController;
  final String validatorText;
  final double width;

  const TextFieldFeedCow({Key key, this.setTextFuction2, this.valueController, this.validatorText, this.width}) : super(key: key);
  @override
  _TextFieldFeedCowState createState() => _TextFieldFeedCowState();
}

class _TextFieldFeedCowState extends State<TextFieldFeedCow> {
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
        child: TextFormField(
          keyboardType: TextInputType.number,
          controller: widget.valueController,
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
          // onChanged: (value){
          //   widget.setTextFuction2(value: value, controller: widget.valueController);
          // },
          onSaved: (String value) {
            widget.setTextFuction2(value: value, controller: widget.valueController);
          },
        ),
      ));
  }
}

