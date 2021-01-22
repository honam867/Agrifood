import 'package:flutter/material.dart';

class CustomClipPathByHomePage extends CustomClipper<Path> {
  var radius = 10.0;
  @override
  Path getClip(Size size) {
    Path path = Path();
    path.lineTo(0, size.height - 100);
    path.quadraticBezierTo(
        size.width / 2, size.height, 
  size.width, size.height - 100);
    path.lineTo(size.width, 0);
    path.close();

    return path;
  }

  @override
  bool shouldReclip(CustomClipper<Path> oldClipper) => false;
}

class CustomClipPathBottomByHomePage extends CustomClipper<Path> {
  var radius = 10.0;
  @override
  Path getClip(Size size) {
    var path = Path();
    path.lineTo(0.0, size.height);
    path.quadraticBezierTo(size.width / 4, size.height-40,        size.width / 2, size.height-40);
    path.quadraticBezierTo(size.width - (size.width / 4), size.height-40,        size.width, size.height - 0);
    path.lineTo(size.width, 0.0);
    path.close();
    return path;
  }

  @override
  bool shouldReclip(CustomClipper<Path> oldClipper) => false;
}