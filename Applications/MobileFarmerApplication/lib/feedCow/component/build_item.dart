import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/screen_util.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:flutter/animation.dart';

typedef ShowFoodFunction = void Function();
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

class ContaineTitleFeed extends StatefulWidget {
  final String title;
  final ShowFoodFunction showFood;

  const ContaineTitleFeed({Key key, this.title, this.showFood})
      : super(key: key);

  @override
  _ContaineTitleFeedState createState() => _ContaineTitleFeedState();
}

class _ContaineTitleFeedState extends State<ContaineTitleFeed>
    with SingleTickerProviderStateMixin {
  Animation<double> animation;
  AnimationController controller;
  bool isClick = false;

  @override
  void initState() {
    super.initState();
    controller =
        AnimationController(duration: const Duration(milliseconds: 450), vsync: this);
    animation = Tween<double>(begin: 0, end: 400).animate(controller)
      ..addListener(() {
        setState(() {
          // The state that has changed here is the animation object’s value.
        });
      });
    controller.forward();
  }

  @override
  void dispose() {
    controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Row(mainAxisAlignment: MainAxisAlignment.spaceBetween, children: [
        RichText(
          text: TextSpan(
              text: widget.title,
              style: GoogleFonts.libreBaskerville(
                  fontSize: 23.0, color: Colors.black)),
        ),
        
        IconButton(
            icon:  AnimatedBuilder(
          animation: controller,
          builder: (context, child) => Transform.rotate(
           
                angle: controller.value * 3.1 ,
                child: Icon(
                  Icons.arrow_downward,
                ),
              )),

            // Icon(
            //     isClick == false ? Icons.arrow_downward : Icons.arrow_upward),
            onPressed: () {
              setState(() {
                controller.isCompleted
                ? controller.reverse()
                : controller.forward();
                isClick = !isClick;
              });
              widget.showFood();
            })
      ]),
      padding: EdgeInsets.all(10.0),
      margin: EdgeInsets.all(0.01),
      alignment: Alignment.center,
      width: 1200,
      decoration: BoxDecoration(
        color: Colors.orange[200],
        borderRadius: BorderRadius.all(Radius.circular(5.0)),
      ),
    );
  }
}
