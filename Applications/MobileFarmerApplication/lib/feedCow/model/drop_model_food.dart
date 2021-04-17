import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:flutter/material.dart';

class DropListFoodModel {
  DropListFoodModel(this.listFoodOptionItems);

  final List<FoodSuggestionItem> listFoodOptionItems;
}

// class DropListCowModel {
//   DropListCowModel(this.listOptionItems);

//   final List<CowItem> listOptionItems;
// }

class OptionItem {
  final String id;
  final String title;

  OptionItem({@required this.id, @required this.title});
}
