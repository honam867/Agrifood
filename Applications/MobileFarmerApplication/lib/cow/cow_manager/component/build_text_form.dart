  import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

typedef SetTextFuction = Function({String value, String title});
Widget buildTextForm({hint, validatorText, nameController, codeController, width, SetTextFuction setTextFuction}) {
    return Padding(
        padding: EdgeInsets.only(
          top: 10.0,
        ),
        child: Container(
          height: 80,
          width: hint == "Mã bò" ? width / 4 : width,
          child: TextFormField(
            controller: hint == "Mã bò" ? codeController : nameController,
            decoration: InputDecoration(
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xFF26A69A)),
                  //borderRadius: BorderRadius.all(Radius.circular(30)),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xFF26A69A)),
                  borderRadius: BorderRadius.all(Radius.circular(30)),
                ),
                hintText: hint),
            maxLength: hint == "Mã bò" ? 3 : 10,
            validator: (String value) {
              if (value.isEmpty) {
                return validatorText;
              }
              return null;
            },
            onSaved: (String value) {
             setTextFuction(value: value, title: hint);
            },
          ),
        ));
  }