import 'food_item.dart';

class FoodModel {
  List<FoodItem> foodItem;

  FoodModel({this.foodItem});

  factory FoodModel.fromJson(List<dynamic> parsedJson) {
    List<FoodItem> foodItem = [];
    foodItem = parsedJson.map((i) => FoodItem.fromJson(i)).toList();
    return new FoodModel(
      foodItem: foodItem,
    );
  }
}
