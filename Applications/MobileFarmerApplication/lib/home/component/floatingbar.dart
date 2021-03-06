import 'package:AgrifoodApp/byre/component/popup_add_byre.dart';
import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_speed_dial/flutter_speed_dial.dart';

SpeedDial buildSpeedDial({context}) {
  return SpeedDial(
    /// both default to 16
    marginEnd: 18,
    marginBottom: 20,
    // animatedIcon: AnimatedIcons.menu_close,
    // animatedIconTheme: IconThemeData(size: 22.0),
    /// This is ignored if animatedIcon is non null
    icon: Icons.add,
    activeIcon: Icons.remove,
    // iconTheme: IconThemeData(color: Colors.grey[50], size: 30),

    /// The label of the main button.
    // label: Text("Open Speed Dial"),
    /// The active label of the main button, Defaults to label if not specified.
    // activeLabel: Text("Close Speed Dial"),
    /// Transition Builder between label and activeLabel, defaults to FadeTransition.
    // labelTransitionBuilder: (widget, animation) => ScaleTransition(scale: animation,child: widget),
    /// The below button size defaults to 56 itself, its the FAB size + It also affects relative padding and other elements
    buttonSize: 56.0,
    visible: true,

    /// If true user is forced to close dial manually
    /// by tapping main button and overlay is not rendered.
    closeManually: false,
    curve: Curves.bounceIn,
    overlayColor: Colors.black,
    overlayOpacity: 0.5,
    onOpen: () => print('OPENING DIAL'),
    onClose: () => print('DIAL CLOSED'),
    tooltip: 'Speed Dial',
    heroTag: 'speed-dial-hero-tag',
    backgroundColor: Colors.white,
    foregroundColor: Colors.black,
    elevation: 8.0,
    shape: CircleBorder(),
    // orientation: SpeedDialOrientation.Up,
    // childMarginBottom: 2,
    // childMarginTop: 2,
    children: [
      SpeedDialChild(
        child: Icon(Icons.add_box_outlined),
        backgroundColor: Colors.red,
        label: 'Tạo báo cáo',
        labelStyle: TextStyle(fontSize: 18.0),
        onTap: () => print('FIRST CHILD'),
        onLongPress: () => print('FIRST CHILD LONG PRESS'),
      ),
      SpeedDialChild(
        child: Icon(Icons.add_circle_sharp),
        backgroundColor: Colors.blue,
        label: 'Tạo bò',
        labelStyle: TextStyle(fontSize: 18.0),
        onTap: () => {
          Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => BlocProvider(
                  create: (context) => CowBloc(
                      cowRepository: CowRepository(),
                      foodSuggestionRepository: FoodSuggestionRepository()),
                  child: FormCreateCow(
                    contextCowPage: context,
                    routeName: "HomePage",
                  ),
                ),
              ))
        },
        onLongPress: () => print('SECOND CHILD LONG PRESS'),
      ),
      // SpeedDialChild(
      //   child: Icon(Icons.add_circle_outline_outlined),
      //   backgroundColor: Colors.green,
      //   label: 'Tạo chuồng',
      //   labelStyle: TextStyle(fontSize: 18.0),
      //   onTap: () => {
      //    // typeTrue(context)
      //   },
      //   onLongPress: () => print('THIRD CHILD LONG PRESS'),
      // ),
    ],
  );
}
