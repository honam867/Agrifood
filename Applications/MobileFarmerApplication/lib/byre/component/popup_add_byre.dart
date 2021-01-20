import 'package:AgrifoodApp/byre/model/breed_item.dart';
import 'package:AgrifoodApp/byre/model/breed_model.dart';
import 'package:AgrifoodApp/byre/model/byre_item.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';
import 'package:rflutter_alert/rflutter_alert.dart';

typedef AddByreFuction = void Function(BuildContext context, ByreItem byreItem);
typedef DeleteByreFuction = void Function(BuildContext context, int id);

typedef UpdateByreFuction = void Function(
    BuildContext context, int id, ByreItem byreItem);
typedef ChangeBreedFuction = void Function(BuildContext context, int value);

openPopupAddByre(BuildContext context,
    {AddByreFuction addByreFuction,
    UpdateByreFuction updateByreFuction,
    update = false,
    ByreItem byreItem,
    List<BreedItem> listBreedItem,
    ChangeBreedFuction changeBreedFuction,
    int breedId}) {
  final _formKey = GlobalKey<FormState>();
  TextEditingController _nameByreController = new TextEditingController();
  TextEditingController _rationController = new TextEditingController();
  TextEditingController _codeController = new TextEditingController();

  if (update == true) {
    _nameByreController.text = byreItem.name;
    _rationController.text = byreItem.ration;
    _codeController.text = byreItem.code;
  }
  String breedName = "Loại bò";

  Alert(
      closeFunction: () =>
          Navigator.pop(context, changeBreedFuction(context, null)),
      context: context,
      onWillPopActive: false,
      title: update == false ? "Thêm chuồng" : "Chỉnh sửa chuồng",
      content: Form(
        key: _formKey,
        child: Column(
          children: <Widget>[
            TextFormField(
              controller: _nameByreController,
              validator: (value) =>
                  value.isEmpty ? 'Tên chuồng không được bỏ trống' : null,
              decoration: InputDecoration(
                icon: Icon(Icons.font_download),
                labelText: 'Tên chuồng',
              ),
            ),
            // StatefulBuilder(
            //     builder: (BuildContext context, StateSetter setState) {
            //   return Center(
            //     child: new DropdownButton(
            //       hint: Text(breedName),
            //       items: listBreedItem.map((item) {
            //         return new DropdownMenuItem(
            //           child: new Text(item.name),
            //           value: item,
            //         );
            //       }).toList(),
            //       onChanged: (newVal) {
            //         print(newVal.id);
            //         changeBreedFuction(context, newVal.id);
            //         // breedName = newVal;
            //       },
            //       value: breedId,
            //     ),
            //   );
            // }),
            TextFormField(
              controller: _codeController,
              validator: (value) =>
                  value.isEmpty ? 'Mã chuồng không được bỏ trống' : null,
              decoration: InputDecoration(
                icon: Icon(Icons.format_shapes),
                labelText: 'Mã chuồng',
              ),
            ),
            TextFormField(
              controller: _rationController,
              //validator: (value) => value.isEmpty ? 'Email cannot be blank':null,
              decoration: InputDecoration(
                icon: Icon(Icons.grass),
                labelText: 'Khẩu phần ăn',
              ),
            ),
          ],
        ),
      ),
      buttons: [
        DialogButton(
          color: Colors.green,
          onPressed: () {
            if (_formKey.currentState.validate()) {
              ByreItem byreItemTree = new ByreItem(
                  id: update == false ? null : byreItem.id,
                  name: _nameByreController.text,
                  breedId: breedId,
                  code: _codeController.text,
                  ration: _rationController.text,
                  quantityCow: 0,
                  farmerId: 20);
              update == false
                  ? addByreFuction(context, byreItemTree)
                  : updateByreFuction(context, byreItem.id, byreItemTree);
            }
          },
          child: Text(
            update == false ? "Tạo" : "Cập nhật",
            style: TextStyle(color: Colors.white, fontSize: 20),
          ),
        )
      ]).show();
}

openPopupDeleteByre(BuildContext context,
    {DeleteByreFuction deleteByreFuction, int byreId}) {
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
          style: TextStyle(color: Colors.white, fontSize: 20),
        ),
        onPressed: () => Navigator.pop(context),
        color: Colors.grey,
        radius: BorderRadius.circular(0.0),
      ),
      DialogButton(
        child: Text(
          "Đồng ý",
          style: TextStyle(color: Colors.white, fontSize: 20),
        ),
        onPressed: () {
          deleteByreFuction(context, byreId);
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
    borderRadius: BorderRadius.circular(0.0),
    side: BorderSide(
      color: Colors.grey,
    ),
  ),
  titleStyle: TextStyle(
    color: Colors.red,
  ),
  alertAlignment: Alignment.topCenter,
);
