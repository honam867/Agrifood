import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';

typedef ResposiveBuilder = Widget Function(BuildContext context, Size size);

class ResposiveSafeArea extends StatelessWidget {
  final ResposiveBuilder resposiveBuilder;

  const ResposiveSafeArea({Key key, @required ResposiveBuilder builder})
      : resposiveBuilder = builder,
        super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(child: LayoutBuilder(
      builder: (context, constraints) {
        return resposiveBuilder(context, constraints.biggest);
      },
    ));
  }
}
