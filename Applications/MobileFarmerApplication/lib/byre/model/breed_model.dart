import 'package:AgrifoodApp/byre/model/breed_item.dart';


class BreedModel {
  List<BreedItem> breedItem;

  BreedModel({this.breedItem});

  factory BreedModel.fromJson(List<dynamic> parsedJson) {
    List<BreedItem> breedItem = new List<BreedItem>();
    breedItem = parsedJson.map((i) => BreedItem.fromJson(i)).toList();
    return new BreedModel(
      breedItem: breedItem,
    );
  }
}
