// import 'package:AgrifoodApp/authentication/signup/models/employee_model.dart';
// import 'package:AgrifoodApp/main.dart';
// import 'package:AgrifoodApp/respository/authentication_repository.dart';
// import 'package:AgrifoodApp/respository/register_repository.dart';
// import 'package:AgrifoodApp/ui/utils/palette.dart';
// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';
// import 'package:toast/toast.dart';

// class ResetPasswordC extends StatefulWidget {
//   @required
//   final String email;
//   const ResetPasswordC({Key key, this.email}) : super(key: key);
//   @override
//   _ResetPasswordCState createState() => _ResetPasswordCState(this.email);
// }

// class _ResetPasswordCState extends State<ResetPasswordC> {
//   final RegisterReponsitory registerReponsitory = new RegisterReponsitory();
//   final AuthenticationRepository authenticationRepository =
//       new AuthenticationRepository();
//   _ResetPasswordCState(this._email);

//   String _email = "";

//   SignUpModel customerItem = new SignUpModel();

//   TextEditingController _codeController = TextEditingController();
//   TextEditingController _passController = TextEditingController();
//   TextEditingController _emailController = TextEditingController();

//   bool _obscureTextPassword = true;
//   bool isValid = false;

//   var _passError = "Vui lòng nhập mật khẩu";

//   var _codeError = "Vui lòng nhập mã xác nhận";
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
//       isValid = this._passController.text.isNotEmpty;
//     });
//   }

//   bool _passwordInvalid = false;
//   bool _codeInvaild = false;
//   bool _emailInvaild = false;

//   @override
//   void initState() {
//     _codeController = TextEditingController();
//     _passController = TextEditingController();
//     _emailController = TextEditingController();

//     super.initState();
//   }

//   @override
//   void dispose() {
//     _codeController.dispose();
//     _passController.dispose();
//     _emailController.dispose();

//     super.dispose();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Container(
//       child: Card(
//           child: Container(
//         child: Column(
//           children: <Widget>[
//             Container(
//                 width: double.maxFinite,
//                 margin: EdgeInsets.fromLTRB(20, 10, 20, 20),
//                 child: Column(
//                   children: <Widget>[
//                     Row(
//                       children: <Widget>[
//                         Flexible(
//                           child: TextFormField(
//                             controller: _codeController,
//                             style: TextStyle(
//                                 color: Colors.black, fontFamily: 'SFUIDisplay'),
//                             decoration: InputDecoration(
//                                 border: OutlineInputBorder(),
//                                 labelText: 'Mã xác nhận*',
//                                 errorText: _codeInvaild ? _codeError : null,
//                                 labelStyle: TextStyle(fontSize: 15)),
//                           ),
//                         ),
//                       ],
//                     ),
//                     SizedBox(
//                       height: 10,
//                     ),
//                     Row(
//                       children: <Widget>[
//                         Flexible(
//                           child: TextFormField(
//                             controller: _passController,
//                             onChanged: (password) {
//                               checkValidation();
//                             },
//                             onTap: () {
//                               setState(() {
//                                 _codeController.text.isEmpty
//                                     ? _codeInvaild = true
//                                     : _codeInvaild = false;
//                               });
//                             },
//                             obscureText: _obscureTextPassword,
//                             style: TextStyle(
//                                 color: Colors.black, fontFamily: 'SFUIDisplay'),
//                             decoration: InputDecoration(
//                                 border: OutlineInputBorder(),
//                                 labelText: 'Mật khẩu mới*',
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
//                     MaterialButton(
//                         shape: RoundedRectangleBorder(
//                             borderRadius:
//                                 BorderRadius.all(Radius.circular(10))),
//                         child: Text('Đồng ý',
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
//                             _codeController.text.isEmpty
//                                 ? _codeInvaild = true
//                                 : _codeInvaild = false;

//                             if (!_passwordInvalid && !_codeInvaild) {
//                               // AuthenticationRepository
//                               //     authenticationRepository =
//                               //     new AuthenticationRepository();
//                               // ResetPasswordModel resetPasswordModel =
//                               //     new ResetPasswordModel();
//                               // resetPasswordModel.code = _codeController.text;
//                               // resetPasswordModel.email = _email;
//                               // resetPasswordModel.password =
//                               //     _passController.text;
//                               // var checkresult =
//                               //     await authenticationRepository.resetPassword(
//                               //         resetPasswordModel: resetPasswordModel );
//                               if ( checkresult == true) {
 
                                   
//                               //   BlocSupervisor.delegate = AppBlocDelegate();
//                               //   final authenticationRepository =
//                               //       AuthenticationRepository();
//                               //   Navigator.push(
//                               //       context,
//                               //       MaterialPageRoute(
//                               //           builder: (context) => new App(
//                               //               authenticationRepository:
//                               //                   authenticationRepository)));
//                               //   Toast.show(
//                               //       "Thay đổi mật khẩu thành công", context,
//                               //       duration: Toast.LENGTH_SHORT,
//                               //       gravity: Toast.CENTER);
//                               //   print('Them thanh cong');
//                               // } else {
//                               //   Toast.show("Mã code không đúng", context,
//                               //       duration: Toast.LENGTH_SHORT,
//                               //       gravity: Toast.CENTER);
//                               // }
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
//         ),
//       )),
//     );
//   }
// }
