import 'package:AgrifoodApp/home/model/notification_model.dart';

abstract class NotificationState {
  const NotificationState();
}

class NotificationInitial extends NotificationState {
  const NotificationInitial();
}

class GetListNotiLoaded extends NotificationState {
  final NotificationModel notificationModel;
  const GetListNotiLoaded(this.notificationModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListNotiLoaded && o.notificationModel == notificationModel;
  }

  @override
  int get hashCode => notificationModel.hashCode;
}

class NotiResult extends NotificationState {
  final String notimessage;
  const NotiResult(this.notimessage);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is NotiError && o.notimessage == notimessage;
  }
    @override
  int get hashCode => notimessage.hashCode;
}

class NotiError extends NotificationState {
  final String notimessage;
  const NotiError(this.notimessage);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is NotiError && o.notimessage == notimessage;
  }

  @override
  int get hashCode => notimessage.hashCode;
}
