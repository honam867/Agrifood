import 'package:flutter/cupertino.dart';
import 'package:giffy_dialog/giffy_dialog.dart';

class DialogCreateCow extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return AssetGiffyDialog(
                        buttonCancelText: Text("Từ chối"),
                        buttonOkText: Text("Đồng ý"),
                            
                            image: Image.asset(
                              'assets/layout/cow.gif',
                              fit: BoxFit.cover,
                            ),
                            title: Text(
                              'Bạn chưa có bò nào!!!',
                              textAlign: TextAlign.center,
                              style: TextStyle(
                                  fontSize: 22.0, fontWeight: FontWeight.w600),
                            ),
                            entryAnimation: EntryAnimation.BOTTOM_RIGHT,
                            description: Text(
                              'Hiện tại chưa có bò nào trong hệ thống! Bạn muốn tạo ngay bây giờ??',
                              textAlign: TextAlign.center,
                              style: TextStyle(),
                            ),
                            onOkButtonPressed: () {},
                          );
  }
}