import 'dart:convert';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import '../core/api_client.dart';

class CowRepository {
  Future<CowModel> getAllCow() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow");
      CowModel cowModel = CowModel.fromJson(jsonRs);
      return cowModel;
    } catch (error) {
      throw error;
    }
  }

  Future<CowModel> getCowByDateMilkingSlip({milkingSlipId}) async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow/checkcow/$milkingSlipId");
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

  Future<CowModel> getCowByFatmerId({farmerId}) async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/cow/user/$farmerId");
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