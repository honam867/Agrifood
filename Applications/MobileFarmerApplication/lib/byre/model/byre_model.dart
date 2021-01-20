import 'package:AgrifoodApp/byre/model/byre_item.dart';

class ByreModel {
  List<ByreItem> byreItem;

  ByreModel({this.byreItem});

  factory ByreModel.fromJson(List<dynamic> parsedJson) {
    List<ByreItem> byreItem = new List<ByreItem>();
    byreItem = parsedJson.map((i) => ByreItem.fromJson(i)).toList();
    return new ByreModel(
      byreItem: byreItem,
    );
  }
}
