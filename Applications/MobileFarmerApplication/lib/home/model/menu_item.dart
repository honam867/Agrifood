import 'package:flutter/material.dart';

class MenuItem {
  Icon icon;
  String title;
  VoidCallback onPress;
  List<String> accressedRoles;

  MenuItem({
    this.icon,
    this.title,
    this.onPress,
    this.accressedRoles
  });
}
