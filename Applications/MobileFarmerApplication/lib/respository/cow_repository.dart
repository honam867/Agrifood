import 'dart:convert';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import '../core/api_client.dart';

class CowRepository {
  Future<CowModel> getAllCow() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow/farmer");
      CowModel cowModel = CowModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }

  Future<CowModel> getCowByGender({gender}) async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow/gender/$gender");
      CowModel cowModel = CowModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }

  Future<CowItem> getCowById({int cowId }) async {
    try {
      Map<String, dynamic> jsonRs = await APIClient.get("api/cow/$cowId");
      var cowItem = CowItem.fromJson(jsonRs);
      return cowItem;
    } catch (error) {
      throw error;
    }
  }

  Future<CowModel> getCowByDateMilkingSlip({milkingSlipId}) async {
    try {
      List<dynamic> jsonRs =
          await APIClient.getList("api/cow/checkcow/$milkingSlipId");
      CowModel cowModel = CowModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }

  Future<CowModel> getCowByByreId({byreId}) async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow/byre/$byreId");
      CowModel cowModel = CowModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }

  Future<CowModel> getCowByFatmerId() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow/farmer");
      CowModel cowModel = CowModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }

  Future<bool> deleteCow({int cowId}) async {
    var rs = await APIClient.delete('api/cow/$cowId');
    if (rs != null) {
      //var data = json.decode(rs);
      //print(data);
      return true;
    }
    return false;
  }

  Future<bool> addCow({CowItem cowItem}) async {
    Map rqData = cowItem.toJson();
    var rs = await APIClient.post('api/cow', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<bool> updateCow(int id, {CowItem cowItem}) async {
    Map rqData = cowItem.toJson();
    var rs = await APIClient.put('api/cow/$id', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }
}
