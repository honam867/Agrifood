import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import '../../../ui/utils/color.dart';

Widget dialogChangPassword({BuildContext context, var state}) {
  return AlertDialog(
    shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.all(Radius.circular(32.0))),
    contentPadding: EdgeInsets.only(top: 10.0),
    content: Container(
      width: 300.0,
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.stretch,
        mainAxisSize: MainAxisSize.min,
        children: <Widget>[
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            mainAxisSize: MainAxisSize.max,
            children: <Widget>[
              Text(
                "Thông Báo",
                style: TextStyle(fontSize: 24.0),
              ),
            ],
          ),
          SizedBox(
            height: 5.0,
          ),
          Divider(
            color: Colors.grey,
            height: 4.0,
          ),
          Container(
              width: 100,
              height: 100,
              padding: EdgeInsets.only(top: 20, left: 30.0, right: 30.0),
              child: Text(state.result)),
          InkWell(
            child: Container(
              padding: EdgeInsets.only(top: 10.0, bottom: 10.0),
              decoration: BoxDecoration(
                color: bgColor,
                borderRadius: BorderRadius.only(
                    bottomLeft: Radius.circular(32.0),
                    bottomRight: Radius.circular(32.0)),
              ),
              child: FlatButton(
                child: Text('Trở về',
                    style: TextStyle(color: Colors.white, fontSize: 15)),
                onPressed: () {
                  if(state.result == "Đổi mật khẩu thành công"){
                    Navigator.pushReplacementNamed(context, "/");
                  } else {
                    Navigator.pop(context);
                  }
                  
                },
              ),
            ),
          ),
        ],
      ),
    ),
  );
}

Widget textForm({controller,void showPassword(String title), text, obscureText, labelText}) {
  return TextFormField(
    enableInteractiveSelection: false,
    controller: controller,
    validator: (value) {
      if (value.isEmpty) {
        return "Không được bỏ trống";
      }
      return null;
    },
    obscureText: obscureText,
    decoration: InputDecoration(
      border: OutlineInputBorder(
          borderSide: BorderSide(color: Color(0xffCED0D2), width: 1),
          borderRadius: BorderRadius.all(Radius.circular(10))),
      labelText: labelText,
      suffixIcon: IconButton(
          icon: obscureText
              ? Icon(Icons.remove_red_eye)
              : Icon(Icons.visibility_off),
          onPressed: () => showPassword(text)),
    ),
  );
}
