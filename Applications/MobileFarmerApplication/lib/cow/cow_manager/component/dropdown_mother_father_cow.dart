import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_model.dart';
import 'package:flutter/material.dart';

typedef ChangeValueFuction = Function({
  String title,
  int value,
});
Widget buildIdFather(
    {title,
    FoodSuggestionModel foodSuggestionModel,
    ByreModel byreModel,
    CowModel cowModel,
    foodSuggestionId,
    cowFatherId,
    cowMotherId,
    byreId,
    ChangeValueFuction changeValueFuction}) {
  var items;
  if (title == "Thức ăn") {
    items = foodSuggestionModel.foodSuggestionItem.map((car) {
      return new DropdownMenuItem(
        value: car.id,
        child: new Text(
          car.name,
          style: new TextStyle(color: Colors.black),
        ),
      );
    }).toList();
  } else if (title == "Chuồng") {
    items = byreModel.byreItem.map((car) {
      return new DropdownMenuItem(
        value: car.id,
        child: new Text(
          car.name,
          style: new TextStyle(color: Colors.black),
        ),
      );
    }).toList();
  } else {
   items = cowModel.cowItem.map((car) {
      return new DropdownMenuItem(
        value: car.id,
        child: new Text(
          car.name,
          style: new TextStyle(color: Colors.black),
        ),
      );
    }).toList();
  }

  return DropdownButton(
      value: title == "Thức ăn"
          ? foodSuggestionId
          : title == "Chuồng"
              ? byreId
              : title == "Bò cha"
                  ? cowFatherId
                  : cowMotherId,
      hint: Text(title),
      onChanged: (car) {
        changeValueFuction(title: title, value: car);
      },
      items: items);
}
