import 'package:AgrifoodApp/core/api_client.dart';
import 'package:AgrifoodApp/core/storage.dart';
import 'package:AgrifoodApp/home/model/notification_model.dart';

class NotificationRepository {
  Future<NotificationModel> getNotificationByFarmerId() async {
    try {
      int farmerId = int.parse(await Storage.getString('farmerId'));

      List<dynamic> jsonRs =
          await APIClient.getList("api/notify/farmer/$farmerId");
      NotificationModel cowModel = NotificationModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }
}
