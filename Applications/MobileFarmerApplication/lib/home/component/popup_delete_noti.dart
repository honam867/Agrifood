import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:flutter_screenutil/screen_util.dart';
import 'package:rflutter_alert/rflutter_alert.dart';

typedef DeleteNotiFuction = void Function(BuildContext context, int id);


openPopupDeleteNoti(BuildContext context,
    {DeleteNotiFuction deleteNotiFuction, int notiId}) {
  return Alert(
    context: context,
    style: alertStyle,
    image: Icon(Icons.remove),
    type: AlertType.warning,
    title: "Thông báo",
    desc: "Bạn thực sự muốn xóa?",
    buttons: [
      DialogButton(
        child: Text(
          "Hủy",
          style: TextStyle(color: Colors.white, fontSize: ScreenUtil().setSp(60)),
        ),
        onPressed: () => Navigator.pop(context),
        color: Colors.grey,
        radius: BorderRadius.circular(ScreenUtil().setSp(0.0)),
      ),
      DialogButton(
        child: Text(
          "Đồng ý",
          style: TextStyle(color: Colors.white, fontSize: ScreenUtil().setSp(60)),
        ),
        onPressed: () {
          deleteNotiFuction(context, notiId);
        },
        color: Color.fromRGBO(0, 179, 134, 1.0),
        radius: BorderRadius.circular(0.0),
      ),
    ],
  ).show();
}

var alertStyle = AlertStyle(
  animationType: AnimationType.fromTop,
  isCloseButton: false,
  isOverlayTapDismiss: false,
  descStyle: TextStyle(fontWeight: FontWeight.bold),
  descTextAlign: TextAlign.start,
  animationDuration: Duration(milliseconds: 400),
  alertBorder: RoundedRectangleBorder(
    borderRadius: BorderRadius.circular(ScreenUtil().setSp(60)),
    side: BorderSide(
      color: Colors.grey,
    ),
  ),
  titleStyle: TextStyle(
    color: Colors.red,
  ),
  alertAlignment: Alignment.topCenter,
);