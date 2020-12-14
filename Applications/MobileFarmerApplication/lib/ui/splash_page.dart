import 'package:flutter/material.dart';
import 'package:flutter_spinkit/flutter_spinkit.dart';
import 'package:AgrifoodApp/ui/utils/palette.dart';

class SplashPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: const SpinKitDualRing(color: Palette.dodgerBlue),
      ),
    );
  }
}
