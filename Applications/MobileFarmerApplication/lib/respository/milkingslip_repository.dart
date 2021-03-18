import 'dart:convert';
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

  Future<bool> deleteMilkingSlip({int milkingSlipId}) async {
    var rs = await APIClient.delete('api/milkingSlip/$milkingSlipId');
    if (rs != null) {
      //var data = json.decode(rs);
      //print(data);
      return true;
    }
    return false;
  }

  Future<bool> addMilkingSlip({MilkingSlipItem milkingSlipItem}) async {
    Map rqData = milkingSlipItem.toJson();
    var rs = await APIClient.post('api/milkingSlip', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<bool> updateMilkingSlip(int id,{MilkingSlipItem milkingSlipItem}) async {
    Map rqData = milkingSlipItem.toJson();
    var rs = await APIClient.put('api/milkingSlip/$id', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

}
