//import 'package:AgrifoodApp/home/model/notification_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/widget/slidable_widget.dart';
import 'package:AgrifoodApp/home/component/notification_detail.dart';
import 'package:AgrifoodApp/home/component/popup_delete_noti.dart';
import 'package:AgrifoodApp/home/model/notification_item.dart';
import 'package:AgrifoodApp/home/model/notification_model.dart';
import 'package:AgrifoodApp/notification/bloc/notification_cubit.dart';
import 'package:AgrifoodApp/notification/bloc/notification_state.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

class PopupNotification extends StatefulWidget {
  @override
  _PopupNotificationState createState() => _PopupNotificationState();
}

class _PopupNotificationState extends State<PopupNotification> {
  void deleteNotiFuction(BuildContext context, int notificationId) {
    final notificationCubit = context.read<NotificationCubit>();
    notificationCubit.deleteNoti(notiId: notificationId);
  }

  void getListNoti(BuildContext context) {
    final notificationCubit = context.watch<NotificationCubit>();
    notificationCubit.getListNoti();
  }

  Future<List<NotificationItem>> getNotificationByFarmerId(
      {List<NotificationItem> notificationItem}) async {
    List<NotificationItem> listNoti = [];
    List<NotificationItem> result = [];
    listNoti.addAll(notificationItem);
    return result;
  }

  Widget build(BuildContext context) {
    return BlocConsumer<NotificationCubit, NotificationState>(
      listener: (context, state) {
        if (state is NotiResult) {
          if (state.notimessage == "Xóa thành công" ||
              state.notimessage == "Cập nhật thành công" ||
              state.notimessage == "Tạo thành công") {
            showToast(context: context, string: state.notimessage);
            Navigator.pop(context);
            getListNoti(context);
          } else {
            showToast(string: "Kiểm tra lại thông tin", context: context);
          }
        }
      },
      builder: (context, state) {
        if (state is NotificationInitial) {
          getListNoti(context);
        }
        if (state is GetListNotiLoaded) {
          final NotificationModel notificationModel = state.notificationModel;
          return SafeArea(
            child: Scaffold(
              backgroundColor: Colors.lightGreen[200],
              appBar: AppBar(
                backgroundColor: Color(0xff9CCC65),
                title: Text('Thông báo'),
                leading: IconButton(
                  icon: Icon(Icons.navigate_before),
                  onPressed: () {
                    Navigator.pop(context);
                  },
                ),
              ),
              body: Column(
                children: <Widget>[
                  Expanded(
                      child: Padding(
                          padding:
                              EdgeInsets.only(top: ScreenUtil().setHeight(50)),
                          child: ListView.builder(
                            itemCount:
                                notificationModel.notificationItem.length,
                            itemBuilder: (BuildContext context, int index) {
                              final notificationItem =
                                  notificationModel.notificationItem[index];
                              return SlidableWidget(
                                child: NotiCard(notiItem: notificationItem),
                                onDismissed: (action) => dismissSlidableItem(
                                    context, index, action, notificationItem),
                              );
                            },
                          ))),
                ],
              ),
            ),
          );
        } else {
          return SafeArea(
              child: Scaffold(
                  backgroundColor: Colors.lightGreen[200],
                  appBar: AppBar(
                    backgroundColor: Color(0xff9CCC65),
                    title: Text('Thông báo'),
                  )));
        }
      },
    );
  }

  void dismissSlidableItem(BuildContext context, int index,
      SlidableAction action, NotificationItem notificationItem) {
    switch (action) {
      case SlidableAction.more:
      case SlidableAction.delete:
        openPopupDeleteNoti(context,
            deleteNotiFuction: deleteNotiFuction, notiId: notificationItem.id);
        break;
    }
  }
}
