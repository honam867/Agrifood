import 'dart:convert';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_model.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_model.dart';

import '../core/api_client.dart';

class MilkingSlipRepository {
  Future<MilkingSlipModel> getAllMilkingSlip() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/milkingSlip");
      MilkingSlipModel milkingSlipModel = MilkingSlipModel.fromJson(jsonRs);
      return milkingSlipModel;
    } catch (error) {
      throw error;
    }
  }

  Future<MilkingSlipDetailModel> getMilkingSlipDetailByMilkingSlipId(
      {int milkingSlipId}) async {
    try {
      List<dynamic> jsonRs = await APIClient.getList(
          "api/milkingSlipDetail/detail/$milkingSlipId");
      if (jsonRs != null) {
        MilkingSlipDetailModel milkingSlipModel =
            MilkingSlipDetailModel.fromJson(jsonRs);
        return milkingSlipModel;
      } else {
        return null;
      }
    } catch (error) {
      throw error;
    }
  }

  Future<MilkingSlipItem> getMilkingSlipByDateAsync(
      {int day, int month, int year, int session}) async {
    try {
      Map<String, dynamic> jsonRs =
          await APIClient.get("api/milkingSlip/$day/$month/$year/$session");
       MilkingSlipItem milkingSlipModel = MilkingSlipItem.fromJson(jsonRs);
        return milkingSlipModel;
    } catch (error) {
      throw error;
    }
  }

  Future<bool> deleteMilkingSlip({int milkingSlipId}) async {
    var rs = await APIClient.delete('api/milkingSlip/$milkingSlipId');
    if (rs != null) {
      //var data = json.decode(rs);
      //print(data);
      return true;
    }
    return false;
  }

  Future<int> addMilkingSlipDetail(
      {MilkingSlipDetailItem milkingSlipDetailItem}) async {
    Map rqData = milkingSlipDetailItem.toJson();
    var rs = await APIClient.post('api/milkingSlipDetail', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return int.parse(rs);
    }
    return 0;
  }

  Future<String> addMilkingSlip({MilkingSlipItem milkingSlipItem, int day, int month, int year}) async {
    Map rqData = milkingSlipItem.toJson();
    var rs = await APIClient.post('api/milkingSlip/$day/$month/$year', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return rs;
    }
    return "0";
  }

  Future<bool> updateMilkingSlip(int id,
      {MilkingSlipItem milkingSlipItem}) async {
    Map rqData = milkingSlipItem.toJson();
    var rs = await APIClient.put('api/milkingSlip/$id', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<bool> updateMilkingSlipDetail(int id,
      {MilkingSlipDetailItem milkingSlipDetailItem}) async {
    Map rqData = milkingSlipDetailItem.toJson();
    var rs = await APIClient.put('api/milkingSlipDetail/$id', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }
}
