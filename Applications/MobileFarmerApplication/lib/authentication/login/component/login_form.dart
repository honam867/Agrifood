// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';
// import 'package:mobile_application/authentication/forgot_password.dart/page/forgotpass_page.dart';
// import 'package:mobile_application/authentication/login/component/login_button.dart';
// import 'package:mobile_application/authentication/login/login_bloc.dart';
// import 'package:mobile_application/authentication/login/login_event.dart';
// import 'package:mobile_application/authentication/login/login_state.dart';
// import 'package:mobile_application/authentication/login/model/login_model.dart';
// import 'package:mobile_application/checkcode/page/checkcode_customer_page.dart';
// import 'package:mobile_application/ui/utils/color.dart';
// import 'package:mobile_application/ui/utils/palette.dart';
// import 'package:mobile_application/ui/utils/screen_size.dart';

// class LoginForm extends StatefulWidget {
//   @override
//   State<LoginForm> createState() => _LoginFormState();
// }

// class _LoginFormState extends State<LoginForm> {
//   bool _obscureTextPassword = true;
//   bool isValid = false;
//   final _userNameController = TextEditingController();
//   final _passwordController = TextEditingController();
//   @override
//   void dispose() {
//     _userNameController.dispose();
//     _passwordController.dispose();
//     super.dispose();
//   }

//   void _showOrHidePassword() {
//     setState(() {
//       _obscureTextPassword = !_obscureTextPassword;
//     });
//   }

//   void checkValidation() {
//     setState(() {
//       isValid = this._userNameController.text.isNotEmpty &&
//           this._passwordController.text.isNotEmpty;
//     });
//   }

//   @override
//   Widget build(BuildContext context) {
//     _onLoginButtonPressed() {
//       BlocProvider.of<LoginBloc>(context).add(
//         LoginButtonPress(
//           loginModel: new LoginModel(
//             _userNameController.text,
//             _passwordController.text,
//             _fingerId
//           ),
//         ),
//       );
//     }

//     return BlocListener<LoginBloc, LoginState>(listener: (context, state) {
//       if (state is LoginFailure) {
//         Scaffold.of(context).showSnackBar(
//           SnackBar(
//             content: Text('${state.error}'),
//             backgroundColor: Colors.red,
//           ),
//         );
//       }
//     }, child: BlocBuilder<LoginBloc, LoginState>(
//       builder: (context, state) {
//         return Stack(
//           children: <Widget>[
//             Container(
//               height: 250,
//               decoration: BoxDecoration(
//                   image: DecorationImage(
//                     image: AssetImage('image/cover4.jpg'),
//                     fit: BoxFit.cover,
//                     // alignment: Alignment.topCenter,
//                   ),
//                   color: Palette.paleGrey),
//             ),
//             SingleChildScrollView(
//               reverse: true,
//               child: Padding(
//                 padding: EdgeInsets.only(bottom: 0.0),
//                 child: Container(
//                   margin: EdgeInsets.only(top: 250),
//                   height: ScreenSize.getFullHeight(context) - 350,
//                   decoration: BoxDecoration(
//                     borderRadius: new BorderRadius.only(
//                       topLeft: const Radius.circular(20.0),
//                       topRight: const Radius.circular(20.0),
//                     ),
//                     color: Colors.white,
//                   ),
//                   child: Padding(
//                     padding: EdgeInsets.all(20),
//                     child: Column(
//                       children: <Widget>[
//                         Padding(
//                           padding: EdgeInsets.fromLTRB(0, 20, 0, 20),
//                           child: Container(
//                             color: Color(0xfff5f5f5),
//                             child: Column(
//                               children: <Widget>[
//                                 TextFormField(
//                                   controller: _userNameController,
//                                   onChanged: (username) {
//                                     checkValidation();
//                                   },
//                                   style: TextStyle(
//                                       color: Colors.black,
//                                       fontFamily: 'SFUIDisplay'),
//                                   decoration: InputDecoration(
//                                       border: OutlineInputBorder(
//                                           borderSide: BorderSide(
//                                               color: Color(0xffCED0D2),
//                                               width: 1),
//                                           borderRadius: BorderRadius.all(
//                                               Radius.circular(10))),
//                                       labelText: 'Tài khoản',
//                                       prefixIcon: Icon(Icons.person_outline),
//                                       labelStyle: TextStyle(fontSize: 15)),
//                                 ),
//                               ],
//                             ),
//                           ),
//                         ),
//                         Container(
//                           color: Color(0xfff5f5f5),
//                           child: TextFormField(
//                             controller: _passwordController,
//                             onChanged: (password) {
//                               checkValidation();
//                             },
//                             obscureText: _obscureTextPassword,
//                             style: TextStyle(
//                                 color: Colors.black, fontFamily: 'SFUIDisplay'),
//                             decoration: InputDecoration(
//                                 border: OutlineInputBorder(
//                                     borderSide:
//                                         BorderSide(color: Colors.red, width: 1),
//                                     borderRadius:
//                                         BorderRadius.all(Radius.circular(10))),
//                                 labelText: 'Mật khẩu',
//                                 prefixIcon: Icon(Icons.lock_outline),
//                                 suffixIcon: IconButton(
//                                   icon: _obscureTextPassword
//                                       ? Icon(Icons.remove_red_eye)
//                                       : Icon(Icons.visibility_off),
//                                   onPressed: _showOrHidePassword,
//                                 ),
//                                 labelStyle: TextStyle(fontSize: 15)),
//                           ),
//                         ),
//                         Padding(
//                           padding: EdgeInsets.only(top: 20),
//                           child: LoginButton(
//                             isDisable: !isValid,
//                             onPress: state is! LoginLoading
//                                 ? _onLoginButtonPressed
//                                 : null,
//                           ),
//                         ),
//                         Padding(
//                             padding: EdgeInsets.only(top: 20),
//                             child: Center(
//                                 child: InkWell(
//                               onTap: () {
//                                 Navigator.push(
//                                     context,
//                                     MaterialPageRoute(
//                                         builder: (context) => ForgotPass()));
//                               },
//                               child: Text(
//                                 "Quên mật khẩu?",
//                                 style: TextStyle(color: textColor),
//                               ),
//                             ))),
//                         Padding(
//                           padding: EdgeInsets.only(top: 10),
//                           child: Center(
//                             child: GestureDetector(
//                               onTap: () {
//                                 Navigator.push(
//                                     context,
//                                     MaterialPageRoute(
//                                         builder: (context) => CheckCodePage()));
//                               },
//                               child: RichText(
//                                 text: TextSpan(children: [
//                                   TextSpan(
//                                       text: "Bạn không có tài khoản? ",
//                                       style: TextStyle(
//                                         fontFamily: 'SFUIDisplay',
//                                         color: Colors.black,
//                                         fontSize: 15,
//                                       )),
                                    
//                                   TextSpan(
//                                       text: " Đăng ký",
//                                       style: TextStyle(
//                                         fontFamily: 'SFUIDisplay',
//                                         color: Color(0xffff2d55),
//                                         fontSize: 16,
//                                       ))
//                                 ]),
//                               ),
//                             ),
//                           ),
//                         )
//                       ],
//                     ),
//                   ),
//                 ),
//               ),
//             )
//           ],
//         );
//       },
//     ));
//   }
// }
