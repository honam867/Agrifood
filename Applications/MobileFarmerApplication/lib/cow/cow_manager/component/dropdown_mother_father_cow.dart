import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_model.dart';
import 'package:flutter/material.dart';

typedef ChangeValueFuction = Function({String title,int value,});
Widget buildIdFather({title, FoodSuggestionModel foodSuggestionModel, CowModel cowModel, foodSuggestionId, cowFatherId, cowMotherId, ChangeValueFuction changeValueFuction}) {
      var items = title == "Thức ăn"
          ? foodSuggestionModel.foodSuggestionItem.map((car) {
              return new DropdownMenuItem(
                value: car.id,
                child: new Text(
                  car.content,
                  style: new TextStyle(color: Colors.black),
                ),
              );
            }).toList()
          : cowModel.cowItem.map((car) {
              return new DropdownMenuItem(
                value: car.id,
                child: new Text(
                  car.name,
                  style: new TextStyle(color: Colors.black),
                ),
              );
            }).toList();

      return DropdownButton(
          value: title == "Thức ăn"
              ? foodSuggestionId
              : title == "Bò cha"
                  ? cowFatherId
                  : cowMotherId,
          hint: Text(title),
          onChanged: (car) {
            changeValueFuction(title:title,value:car);
          },
          items: items);
    }