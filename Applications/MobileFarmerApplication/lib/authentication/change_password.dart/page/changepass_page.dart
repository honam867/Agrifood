// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';
// import 'package:toast/toast.dart';

// import '../../../respository/authentication_repository.dart';
// import '../../../ui/utils/color.dart';
// import '../../../ui/utils/palette.dart';
// import '../models/changepass_model.dart';
// import '../models/checkpass_model.dart';


// class ChangePassPage extends StatefulWidget {
//   @override
//   _ChangePassPageState createState() => _ChangePassPageState();
// }

// class _ChangePassPageState extends State<ChangePassPage> {
//   bool isValid = false;
//   final _oldPasswordController = TextEditingController();
//   var _oldpassInvalid = false;
//   var _oldpassErr = "Mật khẩu cũ không đúng";

//   final _newpasswordController = TextEditingController();
//   var _newpassInvalid = false;
//   var _newpassErr = "Mật khẩu mới không hợp lệ";

//   final _confirmpasswordController = TextEditingController();
//   var _confirmpassInvalid = false;
//   var _confirmpassErr = "Mật khẩu mới không hợp lệ";

//   bool _obscureTextOldPassword = true;
//   bool _obscureTextNewPassword = true;
//   bool _obscureTextConfirmPassword = true;

//   String get name => null;
//   @override
//   void dispose() {
//     _oldPasswordController.dispose();
//     _newpasswordController.dispose();
//     _confirmpasswordController.dispose();
//     super.dispose();
//   }

//   void checkValidation() {
//     setState(() {
//       isValid = this._oldPasswordController.text.isNotEmpty &&
//           this._newpasswordController.text.isNotEmpty &&
//           this._confirmpasswordController.text.isNotEmpty &&
//           this._newpasswordController.text ==
//               this._confirmpasswordController.text;
//     });
//   }

//   @override
//   Widget build(BuildContext context) {
//     return MaterialApp(
//       home: Scaffold(
//         appBar: AppBar(
//           centerTitle: true,
//           title: Text('Đổi mật khẩu'),
//           leading: IconButton(
//             icon: Icon(Icons.arrow_back),
//             onPressed: () => Navigator.pop(context, false),
//           ),
//           flexibleSpace: Container(decoration: BoxDecoration(
//               gradient: LinearGradient(
//                 begin: Alignment.topLeft,
//                 end: Alignment.bottomRight,
//                 colors: <Color>[
//                   Color.fromRGBO(24, 133, 196, 1),
//                   Color.fromRGBO(216, 44, 46, 1),
//                 ],
//               ),
//             ),)
//         ),
//         body: Form(
//           child: Column(
//             children: [
//               Padding(
//                 padding: const EdgeInsets.only(top:20,bottom:20),
//                 child: Text('Vui lòng nhập thông tin',style:TextStyle(fontSize:18,fontWeight: FontWeight.bold)),
//               ),
//               Padding(
//                 padding: EdgeInsets.fromLTRB(20, 10, 20, 0),
//                 child: TextFormField(
//                   enableInteractiveSelection: false,
//                   controller: _oldPasswordController,
//                   onChanged: (oldPassword) {
//                     checkValidation();
//                   },
//                   obscureText: _obscureTextOldPassword,
//                   decoration: InputDecoration(
//                     border: OutlineInputBorder(
//                         borderSide:
//                             BorderSide(color: Color(0xffCED0D2), width: 1),
//                         borderRadius: BorderRadius.all(Radius.circular(10))),
//                     errorText: _oldpassInvalid ? _oldpassErr : null,
//                     labelText: 'Mật khẩu cũ',
//                     suffixIcon: IconButton(
//                       icon: _obscureTextOldPassword
//                           ? Icon(Icons.remove_red_eye)
//                           : Icon(Icons.visibility_off),
//                       onPressed: () {
//                         setState(() {
//                           this._obscureTextOldPassword =
//                               !this._obscureTextOldPassword;
//                         });
//                       },
//                     ),
//                   ),
//                 ),
//               ),
//               Padding(
//                 padding: EdgeInsets.fromLTRB(20, 20, 20, 0),
//                 child: TextFormField(
//                   enableInteractiveSelection: false,
//                   controller: _newpasswordController,
//                   onChanged: (newpassword) {
//                     checkValidation();
//                   },
//                   obscureText: _obscureTextNewPassword,
//                   decoration: InputDecoration(
//                     border: OutlineInputBorder(
//                         borderSide:
//                             BorderSide(color: Color(0xffCED0D2), width: 1),
//                         borderRadius: BorderRadius.all(Radius.circular(10))),
//                     errorText: _newpassInvalid ? _newpassErr : null,
//                     labelText: 'Mật khẩu mới',
//                     suffixIcon: IconButton(
//                       icon: _obscureTextNewPassword
//                           ? Icon(Icons.remove_red_eye)
//                           : Icon(Icons.visibility_off),
//                       onPressed: () {
//                         setState(() {
//                           this._obscureTextNewPassword =
//                               !this._obscureTextNewPassword;
//                         });
//                       },
//                     ),
//                   ),
//                 ),
//               ),
//               Padding(
//                 padding: EdgeInsets.fromLTRB(20, 20, 20, 0),
//                 child: TextFormField(
//                   enableInteractiveSelection: false,
//                   controller: _confirmpasswordController,
//                   onChanged: (confirmpassword) {
//                     checkValidation();
//                   },
//                   obscureText: _obscureTextConfirmPassword,
//                   decoration: InputDecoration(
//                     border: OutlineInputBorder(
//                         borderSide:
//                             BorderSide(color: Color(0xffCED0D2), width: 1),
//                         borderRadius: BorderRadius.all(Radius.circular(10))),
//                     errorText: _confirmpassInvalid ? _confirmpassErr : null,
//                     labelText: 'Nhập lại mật khẩu mới',
//                     suffixIcon: IconButton(
//                       icon: _obscureTextConfirmPassword
//                           ? Icon(Icons.remove_red_eye)
//                           : Icon(Icons.visibility_off),
//                       onPressed: () {
//                         setState(() {
//                           this._obscureTextConfirmPassword =
//                               !this._obscureTextConfirmPassword;
//                         });
//                       },
//                     ),
//                   ),
//                 ),
//               ),
//               Container(
//                 decoration: BoxDecoration(
//                   borderRadius: BorderRadius.all(
//                     Radius.circular(27),
//                   ),
//                   color: Colors.white,
//                   gradient: isValid ? Palette.activeLinearGradient : null,
//                 ),
//                 margin: EdgeInsets.only(top: 20.0),
//                 child: OutlineButton(
//                   color: Palette.paleGrey,
//                   shape: new RoundedRectangleBorder(
//                     borderRadius: new BorderRadius.circular(10),
//                   ),
//                   onPressed: () async {
//                     setState(() async {
//                       AuthenticationRepository authenticationRepository =
//                           new AuthenticationRepository();
//                       CheckPassModel checkPassModel = new CheckPassModel();
//                       checkPassModel.password = _oldPasswordController.text;
//                       var checkresult = await authenticationRepository
//                           .checkPass(checkPass: checkPassModel);

//                       ChangePassModel models = new ChangePassModel();
//                       models.oldPassword = _oldPasswordController.text;
//                       models.newPassword = _newpasswordController.text;
//                       models.reNewPassword = _newpasswordController.text;
//                       authenticationRepository.changePass(
//                           changePassModel: models);
//                       showDialog(
//                           context: context,
//                           builder: (BuildContext context) {
//                             return AlertDialog(
//                               shape: RoundedRectangleBorder(
//                                   borderRadius:
//                                       BorderRadius.all(Radius.circular(32.0))),
//                               contentPadding: EdgeInsets.only(top: 10.0),
//                               content: Container(
//                                 width: 300.0,
//                                 child: Column(
//                                   mainAxisAlignment: MainAxisAlignment.start,
//                                   crossAxisAlignment:
//                                       CrossAxisAlignment.stretch,
//                                   mainAxisSize: MainAxisSize.min,
//                                   children: <Widget>[
//                                     Row(
//                                       mainAxisAlignment:
//                                           MainAxisAlignment.center,
//                                       mainAxisSize: MainAxisSize.max,
//                                       children: <Widget>[
//                                         Text(
//                                           "Thông Báo",
//                                           style: TextStyle(fontSize: 24.0),
//                                         ),
//                                       ],
//                                     ),
//                                     SizedBox(
//                                       height: 5.0,
//                                     ),
//                                     Divider(
//                                       color: Colors.grey,
//                                       height: 4.0,
//                                     ),
//                                     Container(
//                                         width: 100,
//                                         height: 100,
//                                         padding: EdgeInsets.only(
//                                             top: 20, left: 30.0, right: 30.0),
//                                         child: Text(checkresult == true
//                                             ? 'Bạn đã thay đổi mật khẩu thành công'
//                                             : 'Mật khẩu cũ không chính xác')),
//                                     InkWell(
//                                       child: Container(
//                                         padding: EdgeInsets.only(
//                                             top: 10.0, bottom: 10.0),
//                                         decoration: BoxDecoration(
//                                           color: bgColor,
//                                           borderRadius: BorderRadius.only(
//                                               bottomLeft: Radius.circular(32.0),
//                                               bottomRight:
//                                                   Radius.circular(32.0)),
//                                         ),
//                                         child: FlatButton(
//                                           child: Text('Trở về',
//                                               style: TextStyle(
//                                                   color: Colors.white,
//                                                   fontSize: 15)),
//                                           onPressed: () {
//                                             if (checkresult == true) {

//                                               Navigator.pushReplacementNamed(context, "/");
//                                             } else {
//                                                Toast.show("Mật khẩu cũ không đúng",
//                                                 context,
//                                                 duration: Toast.LENGTH_SHORT,
//                                                 gravity: Toast.CENTER);
//                                             }
//                                           },
//                                         ),
//                                       ),
//                                     ),
//                                   ],
//                                 ),
//                               ),
//                             );
//                           });
//                     });
//                   },
//                   padding: EdgeInsets.only(
//                     left: 97,
//                     top: 16,
//                     right: 97,
//                     bottom: 16,
//                   ),
//                   child: Text(
//                     'Xác nhận thay đổi',
//                     style: isValid
//                         ? TextStyle(
//                             color: Colors.white,
//                             fontWeight: FontWeight.w700,
//                             fontFamily: "MyriadPro",
//                             fontStyle: FontStyle.normal,
//                             fontSize: 16.0,
//                           )
//                         : TextStyle(
//                             color: Colors.grey,
//                             fontWeight: FontWeight.w700,
//                             fontFamily: "MyriadPro",
//                             fontStyle: FontStyle.normal,
//                             fontSize: 16.0,
//                           ),
//                     textAlign: TextAlign.center,
//                   ),
//                 ),
//               ),
//             ],
//           ),
//         ),
//       ),
//     );
//   }
// }
