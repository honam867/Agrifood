
import 'package:shared_preferences/shared_preferences.dart';

class Storage {
  static saveString(key, value) async {
    SharedPreferences pref = await SharedPreferences.getInstance();
    pref.setString(key, value);
  }

  static Future<String> getString(key) async {
    SharedPreferences pref = await SharedPreferences.getInstance();
    return pref.getString(key);
  }
  
  static removeString(key) async {
    SharedPreferences pref = await SharedPreferences.getInstance();
    pref.remove(key);
  }
}
