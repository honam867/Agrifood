import 'dart:convert';
import 'package:http/http.dart' as http;
import 'dart:io';
import 'package:async/async.dart';
import 'package:path/path.dart';
import 'storage.dart';

class APIClient {
  //http://192.168.1.199:5000/
  //static const baseUrl = 'http://192.168.1.199:5000/';
  //static const baseUrl = 'http://localhost:63646/';

  static const baseUrl = 'http://cntttest.vanlanguni.edu.vn:18080/CP23Team2/';

  static Future<Map<String, String>> addHeader() async {
    Map<String, String> header = {
      'Content-Type': 'application/json',
    };

    var token = await Storage.getString('token');
    if (token != null) {
      header.addAll({
        'Authorization': 'Bearer $token',
      });
    }
    return header;
  }

  static Future<Map<String, dynamic>> get(String url) async {
    String apiUrl = baseUrl + url;
    var response = await http.get(
      apiUrl,
      headers: await addHeader(),
    );
    return json.decode(response.body) as Map<String, dynamic>;
  }

  static Future<List<dynamic>> getList(String url) async {
    String apiUrl = baseUrl + url;
    var response = await http.get(
      apiUrl,
      headers: await addHeader(),
    );
    return json.decode(response.body) as List<dynamic>;
  }

  static Future post(String url, Map data) async {
    String apiUrl = baseUrl + url;
    var body = json.encode(data);
    var response = await http.post(
      apiUrl,
      headers: await addHeader(),
      body: body,
    );
    if (response.statusCode == 200 || response.statusCode == 201) {
      return response.body;
    }
    return null;
  }

  static Future put(String url, Map data) async {
    String apiUrl = baseUrl + url;
    var body = json.encode(data);
    var response = await http.put(
      apiUrl,
      headers: await addHeader(),
      body: body,
    );
    if (response.statusCode == 200 || response.statusCode == 201) {
      return response.body;
    }
    return null;
  }

  static Future getCustomer(String url, Map data) async {
    String apiUrl = baseUrl + url;
    var response = await http.get(
      apiUrl,
      headers: await addHeader(),
    );
    if (response.statusCode == 200 || response.statusCode == 201) {
      return response.body;
    }
    return null;
  }

  static Future putId(String url) async {
    String apiUrl = baseUrl + url;
    var response = await http.put(
      apiUrl,
      headers: await addHeader(),
    );
    if (response.statusCode == 200 || response.statusCode == 201) {
      return response.body;
    }
    return null;
  }

  static Future delete(String url) async {
    String apiUrl = baseUrl + url;
    var response = await http.delete(
      apiUrl,
      headers: await addHeader(),
    );
    if (response.statusCode == 200 || response.statusCode == 201) {
      return response.body;
    }
    return null;
  }

  static Future uploadFile(String url, File file) async {
    var stream = new http.ByteStream(DelegatingStream.typed(file.openRead()));
    var length = await file.length();

    var uri = Uri.parse(baseUrl + url);
    print(baseUrl + url);
    // create multipart request
    var request = new http.MultipartRequest("POST", uri);

    // multipart that takes file
    var multipartFile = new http.MultipartFile('Avatar', stream, length,
        filename: basename(file.path));
    print(url);
    // add file to multipart
    request.files.add(multipartFile);
    request.headers.addAll(await addHeader());
    // send
    var response = await request.send();
    print(response.statusCode);
  }
}
