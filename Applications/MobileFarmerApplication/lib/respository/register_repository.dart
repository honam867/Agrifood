
import 'dart:convert';

import 'package:flutter/cupertino.dart';

import '../authentication/signup/models/employee_model.dart';
import '../authentication/signup/models/employee_person.model.dart';
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

  Future<bool> newUserPersonal({@required SignUpPersonModel signUpPersonModel}) async {
    Map rqData = signUpPersonModel.toJson();
    var rs = await APIClient.post('api/user/registration/', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }


    Future<bool> newUser({@required SignUpModel signUpModel}) async {
    Map rqData = signUpModel.toJson();
    var rs = await APIClient.post('api/CustomerEmployee/mobile/registration/', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }



}
