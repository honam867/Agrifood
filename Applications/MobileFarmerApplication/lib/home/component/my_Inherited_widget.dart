import 'package:flutter/widgets.dart';

class MyInheritedWidget extends InheritedWidget {
   MyInheritedWidget({
      Key key,
      @required Widget child,
      this.data,
   }): super(key: key, child: child);
	
   final data;
	
   static MyInheritedWidget of(BuildContext context) {
      return context.dependOnInheritedWidgetOfExactType();
   }

   @override
   bool updateShouldNotify(MyInheritedWidget oldWidget) => data != oldWidget.data;
}