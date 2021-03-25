import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:flutter/material.dart';

class DropListModel {
  DropListModel(this.listOptionItems);

  final List<CowItem> listOptionItems;
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
