import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';


class FoodSuggestionModel {
  List<FoodSuggestionItem> foodSuggestionItem;

  FoodSuggestionModel({this.foodSuggestionItem});

  factory FoodSuggestionModel.fromJson(List<dynamic> parsedJson) {
    List<FoodSuggestionItem> foodSuggestionItem = new List<FoodSuggestionItem>();
    foodSuggestionItem = parsedJson.map((i) => FoodSuggestionItem.fromJson(i)).toList();
    return new FoodSuggestionModel(
      foodSuggestionItem: foodSuggestionItem,
    );
  }
}
