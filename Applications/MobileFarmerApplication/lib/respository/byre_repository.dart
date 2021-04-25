import 'dart:convert';
import 'package:AgrifoodApp/byre/model/breed_model.dart';
import 'package:AgrifoodApp/byre/model/byre_item.dart';
import 'package:AgrifoodApp/byre/model/byre_model.dart';
import '../core/api_client.dart';

class ByreRepository {
  Future<ByreModel> getAllByre() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/byre");
      ByreModel byreModel = ByreModel.fromJson(jsonRs);
      return byreModel;
    } catch (error) {
      throw error;
    }
  }

  // Future<ByreModel> getByreByFarmerId({int farmerId}) async {
  //   try {
  //     List<dynamic> jsonRs = await APIClient.getList("api/byre/farmer/$farmerId");
  //     ByreModel byreModel = ByreModel.fromJson(jsonRs);
  //     return byreModel;
  //   } catch (error) {
  //     throw error;
  //   }
  // }

  Future<ByreModel> getByreByFarmerId() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/byre/farmer/");
      ByreModel byreModel = ByreModel.fromJson(jsonRs);
      return byreModel;
    } catch (error) {
      throw error;
    }
  }

  Future<BreedModel> getListBreeds() async {
    try {
      List<dynamic> jsonRs = await APIClient.getList("api/breed");
      BreedModel breedModel = BreedModel.fromJson(jsonRs);
      return breedModel;
    } catch (error) {
      throw error;
    }
  }

  Future<bool> deleteByre({int byreId}) async {
    var rs = await APIClient.delete('api/byre/$byreId');
    if (rs != null) {
      //var data = json.decode(rs);
      //print(data);
      return true;
    }
    return false;
  }

  Future<bool> addByre({ByreItem byreItem}) async {
    Map rqData = byreItem.toJson();
    var rs = await APIClient.post('api/byre', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<bool> updateByre(int id,{ByreItem byreItem}) async {
    Map rqData = byreItem.toJson();
    var rs = await APIClient.put('api/byre/$id', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

}
