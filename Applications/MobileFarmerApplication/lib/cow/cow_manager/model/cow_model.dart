import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';

class CowModel {
  List<CowItem> cowItem;

  CowModel({this.cowItem});

  factory CowModel.fromJson(List<dynamic> parsedJson) {
    List<CowItem> cowItem = new List<CowItem>();
    cowItem = parsedJson.map((i) => CowItem.fromJson(i)).toList();
    return new CowModel(
      cowItem: cowItem,
    );
  }
}
