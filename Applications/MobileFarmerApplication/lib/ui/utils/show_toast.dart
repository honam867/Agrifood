import 'package:edge_alert/edge_alert.dart';
import 'package:toast/toast.dart';

void showToast({string, context}) {
  return Toast.show(string, context, duration: Toast.LENGTH_SHORT, gravity: Toast.BOTTOM,);
}

void showAlert({tittle, desciption, context}) {
  return EdgeAlert.show(context, title: tittle, description: desciption, gravity: EdgeAlert.TOP);
}
