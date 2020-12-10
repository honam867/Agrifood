import 'dart:convert';
import 'package:AgrifoodApp/core/storage.dart';

class Token {
  static String _decodeBase64(String str) {
    String output = str.replaceAll('-', '+').replaceAll('_', '/');

    switch (output.length % 4) {
      case 0:
        break;
      case 2:
        output += '==';
        break;
      case 3:
        output += '=';
        break;
      default:
        throw Exception('Illegal base64url string!"');
    }

    return utf8.decode(base64Url.decode(output));
  }

  static Future<Map<String, dynamic>> parseJwt() async {
    String token = await Storage.getString('token');
    final parts = token.split('.');
    if (parts.length != 3) {
      throw Exception('invalid token');
    }

    final payload = _decodeBase64(parts[1]);
    final payloadMap = json.decode(payload);
    if (payloadMap is! Map<String, dynamic>) {
      throw Exception('invalid payload');
    }
    return payloadMap;
  }

  static Future<Object> getLoggedCustomerId () async {
    Map<String, dynamic> parseToken = await parseJwt();
    return  parseToken[
            'customer'].toString();
      
  }

  static Future<Object> getLoggedCustomerEmployeeId() async {
    Map<String, dynamic> parseToken = await parseJwt();
    return  parseToken[
            'customerEmployee'].toString();
      
  }

 
  static Future<String> getLoggedFullname() async {
    Map<String, dynamic> parseToken = await parseJwt();
    return parseToken['fullName'].toString();
  }

  static Future<String> getLoggedRole() async {
    Map<String, dynamic> parseToken = await parseJwt();
    return parseToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'].toString();
  }

  static Future<String> getLoggedAvatar() async {
    Map<String, dynamic> parseToken = await parseJwt();
    return parseToken['avatarURL'].toString();
  }

  static Future<bool> hasToken() async {
    String token = await Storage.getString('token');
    if (token != null) {
      return true;
    }
    return false;
  }

  static Future<bool> isValidToken() async {
    bool hasToken = await Token.hasToken();
    if (!hasToken) {
      return false;
    }
    Map<String, dynamic> parseToken = await parseJwt();
    int timestamp = int.parse(parseToken['exp'].toString());
    DateTime exp = new DateTime.fromMillisecondsSinceEpoch(timestamp * 1000);
    return DateTime.now().isBefore(exp);
  }
}
