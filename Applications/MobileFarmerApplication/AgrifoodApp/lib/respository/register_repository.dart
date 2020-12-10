import 'dart:convert';

import 'package:AgrifoodApp/core/model_okvalue.dart';
import 'package:flutter/cupertino.dart';
import '../authentication/signup/models/signup_farmer_model.dart';
import '../core/api_client.dart';

class RegisterReponsitory {
  // Future<bool> newCustomer({@required CustomerItem customerItem}) async {
  //   Map rqData = customerItem.toJson();
  //   var rs = await APIClient.post('api/customer/mobile/registration/', rqData);
  //   if (rs != null) {
  //     var data = json.decode(rs);
  //     print(data);
  //     return true;
  //   }
  //   return false;
  // }

  Future<bool> signUpFarmer(SignUpFarmerModel signUpPersonModel) async {
    Map rqData = signUpPersonModel.toJson();
    var rs = await APIClient.post('api/user/farmersignup/', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<OkValueObject> checkPhoneNumber({phoneNumber}) async {
    Map<String, dynamic> jsonRs = await APIClient.get('api/user/phonechecking/$phoneNumber');
    try {
      OkValueObject checkPhoneModel = OkValueObject.fromJson(jsonRs);
      return checkPhoneModel;
    } catch (error) {
      throw error;
    }
  }

  // Future<bool> newUser({@required SignUpModel signUpModel}) async {
  //   Map rqData = signUpModel.toJson();
  //   var rs = await APIClient.post('api/CustomerEmployee/mobile/registration/', rqData);
  //   if (rs != null) {
  //     var data = json.decode(rs);
  //     print(data);
  //     return true;
  //   }
  //   return false;
  // }
}
