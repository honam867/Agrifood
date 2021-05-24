import 'package:AgrifoodApp/home/model/notification_item.dart';

class NotificationModel {
  List<NotificationItem> notificationItem;

  NotificationModel({this.notificationItem});

  factory NotificationModel.fromJson(List<dynamic> parsedJson) {
    List<NotificationItem> notificationItem = [];
    notificationItem = parsedJson.map((i) => NotificationItem.fromJson(i)).toList();
    return new NotificationModel(
      notificationItem: notificationItem,
    );
  }
}
