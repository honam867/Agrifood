import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/ui/utils/format.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';

class FormDetailCow extends StatefulWidget {
  final CowItem cowItem;

  const FormDetailCow({Key key, this.cowItem}) : super(key: key);
  @override
  _FormDetailCowState createState() => _FormDetailCowState();
}

class _FormDetailCowState extends State<FormDetailCow> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: Color(0xFF26A69A),
          title: Text('Chi tiết bò'),
          leading: IconButton(
            icon: Icon(Icons.navigate_before),
            onPressed: () {
              Navigator.pop(context);
            },
          ),
        ),
        body: Container(
          width: double.infinity,
          height: double.infinity,
          child: Column(
            children: <Widget>[
              Expanded(
                child: Container(
                  child: ListTile(
                    title: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        builItem(
                            title: "Tên bò: ", string: widget.cowItem.name),
                        builItem(
                            title: "Id bò cha: ",
                            string: widget.cowItem.fatherId.toString()),
                        builItem(
                            title: "Chuồng: ", string: widget.cowItem.byreName ?? ""),
                        builItem(title: "Mã bò: ", string: widget.cowItem.code),
                        builItem(
                            title: "Ngày cai sữa: ",
                            string: Formator.convertDatatimeToString(
                                widget.cowItem.weaningDate ?? DateTime.now())),
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
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}

Widget builItem({title, string}) {
  return Row(
    mainAxisAlignment: MainAxisAlignment.spaceBetween,
    children: <Widget>[
      Text(title, style: TextStyles.labelTextStyle),
      Text(string, style: TextStyles.valueTextStyle),
    ],
  );
}
