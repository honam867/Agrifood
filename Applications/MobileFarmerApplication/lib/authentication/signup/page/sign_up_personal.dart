// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';
// import 'package:toast/toast.dart';

// import '../../../main.dart';
// import '../../../respository/authentication_repository.dart';
// import '../../../respository/register_repository.dart';
// import '../../../ui/splash_page.dart';
// import '../../../ui/utils/palette.dart';
// import '../models/employee_model.dart';
// import '../models/employee_person.model.dart';

// class SignUpPersonal extends StatefulWidget {
//   @required
//   final int codeId;
//   const SignUpPersonal({Key key, this.codeId}) : super(key: key);
//   @override
//   _SignUpPersonalState createState() => _SignUpPersonalState(this.codeId);
// }

// class _SignUpPersonalState extends State<SignUpPersonal> {
//   final RegisterReponsitory registerReponsitory = new RegisterReponsitory();

//   SignUpModel customerItem = new SignUpModel();
//   SignUpPersonModel signUpPersonModel = new SignUpPersonModel();

//   TextEditingController _usernameController = TextEditingController();
//   TextEditingController _passController = TextEditingController();
//   TextEditingController _emailController = TextEditingController();
//   TextEditingController _phoneNumberController = TextEditingController();

//   var group = true;
//   int _codeId;
//   bool _obscureTextPassword = true;
//   bool isValid = false;
//   var _usernameLength;
//   var _passLength;
//   void _showOrHidePassword() {
//     setState(() {
//       _obscureTextPassword = !_obscureTextPassword;
//     });
//   }

//   void checkValidation() {
//     setState(() {
//       isValid = this._passController.text.isNotEmpty;
//     });
//   }

//   bool _usernameInvalid = false;
//   bool _passwordInvalid = false;

//   bool _emailInvalid = false;
//   bool _phoneInvalid = false;

//   var _usernameError = "Tên đăng nhập không được bỏ trống";
//   var _passError = "Mật khẩu không được bỏ trống";

//   var _emailError = "Email không được bỏ trống";

//   _SignUpPersonalState(this._codeId);

//   @override
//   void initState() {
//     _usernameController = TextEditingController();
//     _passController = TextEditingController();

//     _emailController = TextEditingController();
//     _phoneNumberController = TextEditingController();

//     super.initState();
//   }

//   @override
//   void dispose() {
//     _usernameController.dispose();
//     _passController.dispose();

//     _emailController.dispose();
//     _phoneNumberController.dispose();

//     super.dispose();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Container(
//       child: Card(
//         child: Container(child:
//         Column(
//           children: <Widget>[
//             Container(
//                 width: double.maxFinite,
//                 margin: EdgeInsets.fromLTRB(20, 10, 20, 20),
//                 child: Column(
//                   children: <Widget>[
//                     Row(
//                       children: <Widget>[
//                         Flexible(
//                           child: TextField(
//                             controller: _usernameController,
//                             onChanged: (value) {
//                               _usernameController.value = TextEditingValue(
//                                   text: value.toLowerCase(),
//                                   selection: _usernameController.selection);
//                             },
//                             decoration: InputDecoration(
//                                 border: OutlineInputBorder(),
//                                 errorText: _usernameInvalid
//                                     ? _usernameError
//                                     : _usernameLength,
//                                 labelText: 'Tên đăng nhập *'),
//                             style: Theme.of(context).textTheme.body1,
//                           ),
//                         ),
//                       ],
//                     ),
//                     SizedBox(height: 10),
//                     Row(
//                       children: <Widget>[
//                         Flexible(
//                           child: TextFormField(
//                             controller: _passController,
//                             onTap: () {
//                               setState(() {
//                                 _usernameController.text.isEmpty
//                                     ? _usernameInvalid = true
//                                     : _usernameInvalid = false;

//                                 if (_usernameController.text.length < 6 &&
//                                     _usernameInvalid == false) {
//                                   _usernameLength =
//                                       "Tên đăng nhập không hợp lê";
//                                 } else {
//                                   _usernameLength = null;
//                                 }
//                               });
//                             },
//                             onChanged: (password) {
//                               checkValidation();
//                             },
//                             obscureText: _obscureTextPassword,
//                             style: TextStyle(
//                                 color: Colors.black, fontFamily: 'SFUIDisplay'),
//                             decoration: InputDecoration(
//                                 border: OutlineInputBorder(),
//                                 labelText: 'Mật khẩu *',
//                                 errorText:
//                                     _passwordInvalid ? _passError : _passLength,
//                                 suffixIcon: IconButton(
//                                   icon: _obscureTextPassword
//                                       ? Icon(Icons.remove_red_eye)
//                                       : Icon(Icons.visibility_off),
//                                   onPressed: _showOrHidePassword,
//                                 ),
//                                 labelStyle: TextStyle(fontSize: 15)),
//                           ),
//                         ),
//                       ],
//                     ),
//                     SizedBox(height: 10),
//                     Row(
//                       children: <Widget>[
//                         Flexible(
//                           child: TextField(
//                             controller: _emailController,
//                             decoration: InputDecoration(
//                               border: OutlineInputBorder(),
//                               labelText: 'Email*',
//                               // errorText: _emailInvalid ? _emailError : null,
//                             ),
//                             onTap: () {
//                               setState(() {
//                                 _passController.text.isEmpty
//                                     ? _passwordInvalid = true
//                                     : _passwordInvalid = false;
//                                 _usernameController.text.isEmpty
//                                     ? _usernameInvalid = true
//                                     : _usernameInvalid = false;

//                               });
//                             },
//                             style: Theme.of(context).textTheme.body1,
//                           ),
//                         ),
//                       ],
//                     ),
//                     SizedBox(height: 10),
//                     Row(
//                       children: <Widget>[
//                         Flexible(
//                           child: TextField(
//                             controller: _phoneNumberController,
//                             keyboardType: TextInputType.number,
//                             decoration: InputDecoration(
//                               labelText: 'Số điện thoại ',
//                               border: OutlineInputBorder(),

//                             ),
//                             onTap: () {
//                               setState(() {
//                                 _passController.text.isEmpty
//                                     ? _passwordInvalid = true
//                                     : _passwordInvalid = false;
//                                 _usernameController.text.isEmpty
//                                     ? _usernameInvalid = true
//                                     : _usernameInvalid = false;
//                              _emailController.text.isEmpty
//                                     ? _emailInvalid = true
//                                     : _emailInvalid = false;
//                                 if (_passController.text.length < 6 &&
//                                     _passwordInvalid == false) {
//                                   _passLength = "Mật khẩu đăng nhập không hợp lê";
//                                 } else {
//                                   _passLength = null;
//                                 }
//                               });
//                             },
//                             style: Theme.of(context).textTheme.body1,
//                           ),
//                         ),
//                       ],
//                     ),
//                     SizedBox(
//                       height: 10,
//                     ),

//                     MaterialButton(
//                         shape: RoundedRectangleBorder(
//                             borderRadius:
//                                 BorderRadius.all(Radius.circular(10))),
//                         child: Text('Đăng ký',
//                             textAlign: TextAlign.center,
//                             style: TextStyle(
//                                 color: Colors.white,
//                                 fontWeight: FontWeight.bold,
//                                 fontSize: 16.0)),
//                         color: Palette.dodgerBlue,
//                         onPressed: () async {
//                           setState(() async {
//                             _passController.text.isEmpty
//                                 ? _passwordInvalid = true
//                                 : _passwordInvalid = false;
//                             _usernameController.text.isEmpty
//                                 ? _usernameInvalid = true
//                                 : _usernameInvalid = false;
//                             _emailController.text.isEmpty
//                                 ? _emailInvalid = true
//                                 : _emailInvalid = false;

//                             if (!_passwordInvalid &&
//                                 !_usernameInvalid &&
//                                 !_emailInvalid &&
//                                 !_phoneInvalid) {
//                               RegisterReponsitory registerReponsitory =
//                                   new RegisterReponsitory();
//                               // SignUpModel signUpModel = new SignUpModel();
//                               SignUpPersonModel signUpPersonModel =
//                                   new SignUpPersonModel();

//                               // signUpModel.userName =
//                               //     _usernameController.text ?? "";

//                               // signUpModel.customerId = _codeId;
//                               // signUpModel.password = _passController.text ?? "";
//                               // signUpModel.email = _emailController.text ?? "";
//                               signUpPersonModel.customerId = _codeId;
//                               signUpPersonModel.userName =
//                                   _usernameController.text ?? "";

//                               // signUpModel.customerId = _codeId;
//                               signUpPersonModel.passWord =
//                                   _passController.text ?? "";
//                               signUpPersonModel.email =
//                                   _emailController.text ?? "";

//                               // signUpModel.phoneNumber =
//                               //     int.parse(_phoneNumberController.text) ?? "";
//                               signUpPersonModel.phoneNumber =
//                                   int.parse(_phoneNumberController.text) ?? "";

//                               // signUpModel.sex = group;
//                               //signUpPersonModel.customerId = _codeId;

//                                 signUpPersonModel.email =
//                                     _emailController.text ?? "";

//                                if (_phoneNumberController.text.isEmpty) {
//                                 signUpPersonModel.phoneNumber = null;
//                               } else {
//                                 signUpPersonModel.phoneNumber =
//                                     int.parse(_phoneNumberController.text) ?? "";
//                               }

//                               // var checkrs = await registerReponsitory.newUser(
//                               //     signUpModel: signUpModel);
//                               var checkrs2 =
//                                   await registerReponsitory.newUserPersonal(
//                                       signUpPersonModel: signUpPersonModel);

//                               if (!checkrs2) {
//                                 Toast.show("Kiểm tra lại thông tin", context,
//                                     duration: Toast.LENGTH_SHORT,
//                                     gravity: Toast.CENTER);
//                               } else {
//                                Bloc.observer = AppBlocDelegate();
//                                 final authenticationRepository =
//                                     AuthenticationRepository();
//                                 Navigator.push(
//                                     context,
//                                     MaterialPageRoute(
//                                         builder: (context) => new App(
//                                             authenticationRepository:
//                                                 authenticationRepository)));
//                                 Toast.show("Đăng ký thành công", context,
//                                     duration: Toast.LENGTH_SHORT,
//                                     gravity: Toast.CENTER);
//                                 print('Them thanh cong');
//                               }
//                             } else {
//                               Toast.show("Kiểm tra lại thông tin", context,
//                                   duration: Toast.LENGTH_SHORT,
//                                   gravity: Toast.CENTER);
//                             }
//                           });
//                           return SplashPage();
//                         })
//                   ],
//                 ))
//           ],
//         ),)
//       ),
//     );
//   }
// }
