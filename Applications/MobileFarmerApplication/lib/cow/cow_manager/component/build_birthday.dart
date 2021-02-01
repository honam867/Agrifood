  import 'package:AgrifoodApp/ui/utils/format.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

typedef SelectDateFunction = Function({DateTime dateTime});
class BuildBirth extends StatefulWidget {
   SelectDateFunction selectDateFunction;

   BuildBirth({Key key, this.selectDateFunction}) : super(key: key);
  @override
  _BuildBirthState createState() => _BuildBirthState();
}

class _BuildBirthState extends State<BuildBirth> {
  String birthdayString = "Chọn ngày sinh";
  @override
  Widget build(BuildContext context) {
    return Row(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            "Ngày sinh của bò",
            style: TextStyles.labelTextStyle,
          ),
          FlatButton(
              onPressed: () {
                DatePicker.showDatePicker(context,
                    showTitleActions: true,
                    minTime: DateTime(2018, 3, 5),
                    maxTime: DateTime(2030, 6, 7), onChanged: (date) {
                  print('change $date');
                }, onConfirm: (date) {
                  widget.selectDateFunction(dateTime: date);
                  birthdayString = Formator.convertDatatimeToString(date);
                }, currentTime: DateTime.now(), locale: LocaleType.vi);
              },
              child: Text(
                birthdayString,
                style: TextStyles.linkStyle,
              ))
        ]);
  }
}
