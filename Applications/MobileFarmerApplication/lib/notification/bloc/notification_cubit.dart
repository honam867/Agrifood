import 'package:AgrifoodApp/home/model/notification_model.dart';
import 'package:AgrifoodApp/notification/bloc/notification_state.dart';
import 'package:AgrifoodApp/respository/notification_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class NotificationCubit extends Cubit<NotificationState> {
  final NotificationRepository notificationRepository;
  NotificationCubit(this.notificationRepository,) : super(NotificationInitial());

       Future<void> getListNoti() async {
    try {
      final NotificationModel notificationModel = await notificationRepository.getNotificationByFarmerId();

      emit(GetListNotiLoaded(notificationModel));
    } catch (Exception) {
      emit(Exception("Couldn't fetch weather. Is the device online?"));
    }
  }

         Future<void> deleteNoti({int notiId}) async {
    try {
      //emit(WeatherLoading());
      final bool result = await notificationRepository.deleteNoti(farmerId: notiId);
      if (result == true) {
        emit(NotiResult("Xóa thành công"));
        emit(NotificationInitial());
      } else {
        emit(NotiResult("Xóa thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }


 
      
 
  }