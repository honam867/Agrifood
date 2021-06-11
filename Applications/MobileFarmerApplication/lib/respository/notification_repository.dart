import 'package:AgrifoodApp/core/api_client.dart';
import 'package:AgrifoodApp/core/storage.dart';
import 'package:AgrifoodApp/home/model/notification_model.dart';

class NotificationRepository {
  Future<NotificationModel> getNotificationByFarmerId() async {
    try {
      String farmerId;
      List<dynamic> jsonRs;
      await Future.wait<String>({
        Storage.getString('farmerId').then((value) {
          return farmerId = value;
        })
      });
      print(farmerId);
      jsonRs =
          await APIClient.getList("api/notify/farmer/${int.parse(farmerId)}");

      if (jsonRs != null) {
        NotificationModel notificationModel =
            NotificationModel.fromJson(jsonRs);
        return notificationModel;
      } else {
        return null;
      }
    } catch (error) {
      throw error;
    }
  }

  Future<bool> deleteNoti({int farmerId}) async {
    var rs = await APIClient.delete('api/notify/farmer/${(farmerId)}');
    if (rs != null) {
      //var data = json.decode(rs);
      //print(data);
      return true;
    }
    return false;
  }
}

  
