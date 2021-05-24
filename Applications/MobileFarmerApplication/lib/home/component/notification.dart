import 'package:AgrifoodApp/home/model/notification_item.dart';
import 'package:AgrifoodApp/home/model/notification_model.dart';
import 'package:AgrifoodApp/respository/notification_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class PopupNotification extends StatefulWidget {
  @override
  _PopupNotificationState createState() => _PopupNotificationState();
}

class _PopupNotificationState extends State<PopupNotification> {
  @override
  Widget build(BuildContext context) {
    NotificationRepository notificationRepository = new NotificationRepository();
    return Container(child: FutureBuilder<NotificationModel>(
      future: notificationRepository.getNotificationByFarmerId(),
      builder: (context, snapshot){
        if(snapshot.hasData){
          return ListView.builder(
            itemCount: snapshot.data.notificationItem.length,
            itemBuilder: (context, index){
              return Text(snapshot.data.notificationItem[index].content);
          });
        } else {
          return Container();
        }
      },
    ));
  }
}