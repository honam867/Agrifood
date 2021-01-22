// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';
// import 'package:toast/toast.dart';

// class RestPasswordPhone extends StatefulWidget {
//   @required
//   final String value;
//   final String phone;
//   const RestPasswordPhone({Key key, this.value, this.phone}) : super(key: key);
//   @override
//   _RestPasswordPhoneState createState() =>
//       _RestPasswordPhoneState(this.value, this.phone);
// }

// class _RestPasswordPhoneState extends State<RestPasswordPhone> {
//   final RegisterReponsitory registerReponsitory = new RegisterReponsitory();
//   final AuthenticationRepository authenticationRepository =
//       new AuthenticationRepository();
//   _RestPasswordPhoneState(this._value, this._phone);

//   String _value = "";
//   String _phone = "";

//   SignUpModel customerItem = new SignUpModel();

//   TextEditingController _passController = TextEditingController();
//   TextEditingController _newPassController = TextEditingController();

//   bool _obscureTextPassword = true;
//   bool isValid = false;

//   var _passError = "Vui lòng nhập mật khẩu";

//   var _passLength;
//   void _showOrHidePassword() {
//     setState(() {
//       _obscureTextPassword = !_obscureTextPassword;
//     });
//   }

//   bool result;

//   Future<void> resetPassword() async {}

//   void checkValidation() {
//     setState(() {
//       isValid = this._passController.text.isNotEmpty &&
//           this._newPassController.text.isNotEmpty &&
//           this._passController.text == this._newPassController.text;
//     });
//   }

//   bool _passwordInvalid = false;

//   @override
//   void initState() {
//     _passController = TextEditingController();

//     super.initState();
//   }

//   @override
//   void dispose() {
//     _passController.dispose();

//     super.dispose();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//         appBar: AppBar(
//           centerTitle: true,
//           title: Text('Khởi tạo lại mật khẩu'),
//           leading: IconButton(
//               icon: Icon(Icons.arrow_back),
//               onPressed: () {
//                 Navigator.pushReplacementNamed(context, "/");
//               }),
//           elevation: 1.0,
//           flexibleSpace: Container(
//             decoration: BoxDecoration(
//               gradient: LinearGradient(
//                 begin: Alignment.topLeft,
//                 end: Alignment.bottomRight,
//                 colors: <Color>[
//                   Color.fromRGBO(24, 133, 196, 1),
//                   Color.fromRGBO(216, 44, 46, 1),
//                 ],
//               ),
//             ),
//           ),
//         ),
//         body: SingleChildScrollView(
//             child: Card(
//           child: Container(
//             height: MediaQuery.of(context).size.height,
//             width: MediaQuery.of(context).size.width,
//             child: Card(
//               child: Column(
//                 children: <Widget>[
//                   Container(
//                     child: Card(
//                         child: Container(
//                       child: Column(
//                         children: <Widget>[
//                           Container(
//                               width: double.maxFinite,
//                               margin: EdgeInsets.fromLTRB(20, 10, 20, 20),
//                               child: Column(
//                                 children: <Widget>[
//                                   Row(
//                                     children: <Widget>[
//                                       Flexible(
//                                         child: TextFormField(
//                                           controller: _passController,
//                                           onChanged: (password) {
//                                             checkValidation();
//                                           },
//                                           obscureText: _obscureTextPassword,
//                                           style: TextStyle(
//                                               color: Colors.black,
//                                               fontFamily: 'SFUIDisplay'),
//                                           decoration: InputDecoration(
//                                               border: OutlineInputBorder(),
//                                               labelText: 'Mật khẩu mới*',
//                                               errorText: _passwordInvalid
//                                                   ? _passError
//                                                   : _passLength,
//                                               suffixIcon: IconButton(
//                                                 icon: _obscureTextPassword
//                                                     ? Icon(Icons.remove_red_eye)
//                                                     : Icon(
//                                                         Icons.visibility_off),
//                                                 onPressed: _showOrHidePassword,
//                                               ),
//                                               labelStyle:
//                                                   TextStyle(fontSize: 15)),
//                                         ),
//                                       ),
//                                     ],
//                                   ),
//                                   SizedBox(
//                                     height: 10,
//                                   ),
//                                   Row(
//                                     children: <Widget>[
//                                       Flexible(
//                                         child: TextFormField(
//                                           controller: _newPassController,
//                                           onChanged: (password) {
//                                             checkValidation();
//                                           },
//                                           obscureText: _obscureTextPassword,
//                                           style: TextStyle(
//                                               color: Colors.black,
//                                               fontFamily: 'SFUIDisplay'),
//                                           decoration: InputDecoration(
//                                               border: OutlineInputBorder(),
//                                               labelText:
//                                                   'Nhập lại mật khẩu mới*',
//                                               errorText: _passwordInvalid
//                                                   ? _passError
//                                                   : _passLength,
//                                               suffixIcon: IconButton(
//                                                 icon: _obscureTextPassword
//                                                     ? Icon(Icons.remove_red_eye)
//                                                     : Icon(
//                                                         Icons.visibility_off),
//                                                 onPressed: _showOrHidePassword,
//                                               ),
//                                               labelStyle:
//                                                   TextStyle(fontSize: 15)),
//                                         ),
//                                       ),
//                                     ],
//                                   ),
//                                   Container(
//                                     decoration: BoxDecoration(
//                                       borderRadius: BorderRadius.all(
//                                         Radius.circular(27),
//                                       ),
//                                       color: Colors.white,
//                                       gradient: isValid
//                                           ? Palette.activeLinearGradient
//                                           : null,
//                                     ),
//                                     margin: EdgeInsets.only(top: 20.0),
//                                     child: OutlineButton(
//                                       color: Palette.paleGrey,
//                                       shape: new RoundedRectangleBorder(
//                                         borderRadius:
//                                             new BorderRadius.circular(10),
//                                       ),
//                                       onPressed: () async {
//                                         setState(() async {
//                                           _passController.text.isEmpty
//                                               ? _passwordInvalid = true
//                                               : _passwordInvalid = false;

//                                           if (!_passwordInvalid) {
//                                             AuthenticationRepository
//                                                 authenticationRepository =
//                                                 new AuthenticationRepository();
//                                             ResetPasswordByPhoneModel
//                                                 resetPasswordByPhoneModel =
//                                                 new ResetPasswordByPhoneModel();
//                                             resetPasswordByPhoneModel.code =
//                                                 _value;
//                                             resetPasswordByPhoneModel.password =
//                                                 _passController.text;
//                                             resetPasswordByPhoneModel
//                                                 .phoneNumber = _phone;
//                                             var checkresult =
//                                                 await authenticationRepository
//                                                     .resetPasswordWithPhone(
//                                                         resetPasswordByPhoneModel:
//                                                             resetPasswordByPhoneModel);
//                                             if (checkresult == true) {
//                                               BlocSupervisor.delegate =
//                                                   AppBlocDelegate();
//                                               final authenticationRepository =
//                                                   AuthenticationRepository();
//                                               Navigator.push(
//                                                   context,
//                                                   MaterialPageRoute(
//                                                       builder: (context) => new App(
//                                                           authenticationRepository:
//                                                               authenticationRepository)));
//                                               Toast.show(
//                                                   "Thay đổi mật khẩu thành công",
//                                                   context,
//                                                   duration: Toast.LENGTH_SHORT,
//                                                   gravity: Toast.CENTER);
                                             
//                                             } else {
//                                               Toast.show(
//                                                   "Mã code không đúng", context,
//                                                   duration: Toast.LENGTH_SHORT,
//                                                   gravity: Toast.CENTER);
//                                             }
//                                           } else {
//                                             Toast.show("Kiểm tra lại thông tin",
//                                                 context,
//                                                 duration: Toast.LENGTH_SHORT,
//                                                 gravity: Toast.CENTER);
//                                           }
//                                         });
//                                       },
//                                       padding: EdgeInsets.only(
//                                         left: 97,
//                                         top: 16,
//                                         right: 97,
//                                         bottom: 16,
//                                       ),
//                                       child: Text(
//                                         'Đồng ý',
//                                         style: isValid
//                                             ? TextStyle(
//                                                 color: Colors.white,
//                                                 fontWeight: FontWeight.w700,
//                                                 fontFamily: "MyriadPro",
//                                                 fontStyle: FontStyle.normal,
//                                                 fontSize: 16.0,
//                                               )
//                                             : TextStyle(
//                                                 color: Colors.grey,
//                                                 fontWeight: FontWeight.w700,
//                                                 fontFamily: "MyriadPro",
//                                                 fontStyle: FontStyle.normal,
//                                                 fontSize: 16.0,
//                                               ),
//                                         textAlign: TextAlign.center,
//                                       ),
//                                     ),
//                                   ),
//                                 ],
//                               ))
//                         ],
//                       ),
//                     )),
//                   ),
//                 ],
//               ),
//             ),
//           ),
//         )));
//   }
// }
