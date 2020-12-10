import 'dart:convert';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:meta/meta.dart';

import '../authentication/change_password.dart/models/changepass_model.dart';
import '../authentication/change_password.dart/models/checkpass_model.dart';
import '../authentication/login/model/login_model.dart';
import '../core/api_client.dart';
import '../core/storage.dart';

class AuthenticationRepository {
  Future<bool> authenticate({@required LoginModel loginModel}) async {
    Map rqData = loginModel.toJson();
    var rs = await APIClient.post('api/auth/clientSignIn', rqData);
    if (rs != null) {
      var data = json.decode(rs);
      Storage.saveString('token', data['access_token']);
      return true;
    }
    return false;
  }

  Future<bool> checkPass({@required CheckPassModel checkPass}) async {
    Map rqData = checkPass.toJson();
    var rs = await APIClient.post('api/auth/checkpassword', rqData);
    if (rs != null) {
      var data = await json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<bool> signUp({@required CheckPassModel checkPass}) async {
    Map rqData = checkPass.toJson();
    var rs = await APIClient.post('api/auth/checkpassword', rqData);
    if (rs != null) {
      var data = await json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  Future<bool> changePass({@required ChangePassModel changePassModel}) async {
    Map rqData = changePassModel.toJson();
    var rs = await APIClient.put('api/auth/changepassword', rqData);
    print(rs);
    if (rs != null) {
      var data = json.decode(rs);
      print(data);
      return true;
    }
    return false;
  }

  // Future<bool> resetPassword(
  //     {@required ResetPasswordModel resetPasswordModel, bool result}) async {
  //   Map rqData = resetPasswordModel.toJson();
  //   var rs = await APIClient.put('api/Auth/mobile/resetpassword', rqData);
  //   print(rs);
  //   if (rs != null) {
  //     var data = json.decode(rs);
  //     print(data);
  //     return result = data;
  //   }
  //   return false;
  // }

  // Future<bool> resetPasswordWithPhone(
  //     {@required ResetPasswordByPhoneModel resetPasswordByPhoneModel,
  //     bool result}) async {
  //   Map rqData = resetPasswordByPhoneModel.toJson();
  //   var rs = await APIClient.put(
  //       'api/Auth/mobile/resetpassword/phonenumber', rqData);
  //   print(rs);
  //   if (rs != null) {
  //     var data = json.decode(rs);
  //     print(data);

  //     return result = data;
  //   }
  //   return false;
  // }

  // Future<CheckEmailModel> fectCheckEmail(
  //     CheckEmailModel checkEmailModel, String email) async {
  //   Map<String, dynamic> jsonRs =
  //       await APIClient.get('api/Auth/emailchecking/$email');
  //   try {
  //     CheckEmailModel checkEmailModel = CheckEmailModel.fromJson(jsonRs);
  //     return checkEmailModel;
  //   } catch (error) {
  //     throw error;
  //   }
  // }

  // Future<CheckPhoneModel> fetchCheckPhone(
  //     CheckPhoneModel checkPhoneMode, String phone) async {
  //   Map<String, dynamic> jsonRs =
  //       await APIClient.get('api/Auth/phonechecking/$phone');
  //   try {
  //     CheckPhoneModel checkPhoneMode = CheckPhoneModel.fromJson(jsonRs);
  //     return checkPhoneMode;
  //   } catch (error) {
  //     throw error;
  //   }
  // }

  // Future<bool> forgotPass({@required ForgotPassModel forgotPass}) async {
  //   Map rqData = forgotPass.toJson();
  //   var rs = await APIClient.post('api/auth/forgotpassword', rqData);
  //   if (rs != null) {
  //     var data = json.decode(rs);
  //     print(data);
  //     return true;
  //   }
  //   return false;
  // }

  Future<void> deleteToken() async {
    await Storage.removeString('token');
    return;
  }

  Future<void> persistToken(String token) async {
    /// write to keystore/keychain
    await Future.delayed(Duration(seconds: 1));
    return;
  }

  Future<bool> hasToken() async {
    String token = await Storage.getString('token');
    if (token != null) {
      return true;
    }
    return false;
  }
}
