// import 'package:AgrifoodApp/authentication/bloc/authentication_bloc.dart';
// import 'package:AgrifoodApp/authentication/login/component/login_form.dart';
// import 'package:AgrifoodApp/authentication/login/login_bloc.dart';
// import 'package:AgrifoodApp/authentication/signup/bloc/signUp_cubit.dart';
// import 'package:AgrifoodApp/respository/authentication_repository.dart';
// import 'package:AgrifoodApp/ui/utils/show_toast.dart';
// import 'package:flutter/material.dart';
// import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';

// import '../../login/page/login.dart';

// class SignUpPage extends StatefulWidget {
//   final String phoneNumber;

//   const SignUpPage({Key key, this.phoneNumber}) : super(key: key);
//   @override
//   _SignUpPageState createState() => _SignUpPageState();
// }

// class _SignUpPageState extends State<SignUpPage> {
//   final authenticationRepository = new AuthenticationRepository();
//   TextEditingController _usernameController = TextEditingController();
//   TextEditingController _emailController = TextEditingController();
//   TextEditingController _passController = TextEditingController();
//   TextEditingController _confirmPasswordController = TextEditingController();
//   bool _obscureTextPassword = true;

//   @override
//   void initState() {
//     super.initState();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return BlocConsumer<SignUpCubit, SignUpState>(
//       listener: (context, state) {
//         if (state is SignUpLoaded) {
//           showAlert(context: context, desciption: "Đăng kí thành công", tittle: "Thông báo");
//           Navigator.push(
//               context,
//               MaterialPageRoute(
//                 builder: (context) => BlocProvider(
//                     create: (context) {
//                       return LoginBloc(
//                         authenticationBloc: BlocProvider.of<AuthenticationBloc>(context),
//                         authenticationRepository: authenticationRepository,
//                       );
//                     },
//                     child: LoginComponent()),
//               ));
//         }
//         if (state is SignUpError) {}
//       },
//       builder: (context, state) {
//         return Scaffold(
//           resizeToAvoidBottomInset: true,
//           backgroundColor: Colors.white,
//           appBar: AppBar(
//             elevation: 0,
//             brightness: Brightness.light,
//             backgroundColor: Colors.white,
//             leading: IconButton(
//               onPressed: () {
//                 Navigator.pushNamed(context, "/home");
//               },
//               icon: Icon(
//                 Icons.arrow_back_ios,
//                 size: 20,
//                 color: Colors.black,
//               ),
//             ),
//           ),
//           body: SingleChildScrollView(
//             child: Container(
//               padding: EdgeInsets.symmetric(horizontal: 40),
//               height: MediaQuery.of(context).size.height - 50,
//               width: double.infinity,
//               child: Column(
//                 mainAxisAlignment: MainAxisAlignment.spaceEvenly,
//                 children: <Widget>[
//                   Column(
//                     children: <Widget>[
//                       FadeAnimation(
//                           1,
//                           Text(
//                             "Đăng kí",
//                             style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
//                           )),
//                       SizedBox(
//                         height: 20,
//                       ),
//                       FadeAnimation(
//                           1.2,
//                           Text(
//                             "Số điện thoại phải được đăng kí với nhân viên ",
//                             style: TextStyle(fontSize: 15, color: Colors.grey[700]),
//                           )),
//                     ],
//                   ),
//                   Column(
//                     children: <Widget>[
//                       FadeAnimation(1.2, makeInput(label: "Email", controller: _emailController)),
//                       FadeAnimation(1.2, makeInput(label: "Tài khoản", controller: _usernameController)),
//                       FadeAnimation(1.3, makeInput(label: "Mật khẩu", controller: _passController, obscureText: true)),
//                       FadeAnimation(1.4, makeInput(label: "Nhập lại mật khẩu", controller: _confirmPasswordController, obscureText: true)),
//                     ],
//                   ),
//                   FadeAnimation(
//                       1.5,
//                       Container(
//                         padding: EdgeInsets.only(top: 3, left: 3),
//                         decoration: BoxDecoration(
//                             borderRadius: BorderRadius.circular(50),
//                             border: Border(
//                               bottom: BorderSide(color: Colors.black),
//                               top: BorderSide(color: Colors.black),
//                               left: BorderSide(color: Colors.black),
//                               right: BorderSide(color: Colors.black),
//                             )),
//                         child: MaterialButton(
//                           minWidth: double.infinity,
//                           height: 60,
//                           onPressed: () {
//                             setState(() {
//                               if (_passController.text == _confirmPasswordController.text) {
//                                 final signUpCubit = context.bloc<SignUpCubit>();
//                                 signUpCubit.signUpFarmer(
//                                     email: _emailController.text,
//                                     password: _passController.text,
//                                     phoneNumber: "0344978808",
//                                     userName: _usernameController.text);
//                               } else {
//                                 showToast(context: context, string: "Mật khẩu không trùng khớp");
//                               }
//                             });
//                           },
//                           color: Colors.greenAccent,
//                           elevation: 0,
//                           shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(50)),
//                           child: Text(
//                             "Đăng kí",
//                             style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
//                           ),
//                         ),
//                       )),
//                   FadeAnimation(
//                       1.6,
//                       Row(
//                         mainAxisAlignment: MainAxisAlignment.center,
//                         children: <Widget>[
//                           Text("Bạn thật sự đã có tài khoản? "),
//                           TextButton(
//                             onPressed: () => Navigator.push(
//                                 context,
//                                 MaterialPageRoute(
//                                     builder: (context) => LoginPage(
//                                           authenticationRepository: authenticationRepository,
//                                         ))),
//                             child: Text(
//                               "Đăng nhập",
//                               style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
//                             ),
//                           )
//                         ],
//                       )),
//                 ],
//               ),
//             ),
//           ),
//         );
//       },
//     );
//   }

//   void _showOrHidePassword() {
//     setState(() {
//       _obscureTextPassword = !_obscureTextPassword;
//     });
//   }

//   Widget makeInput({label, controller, obscureText = false}) {
//     return Column(
//       crossAxisAlignment: CrossAxisAlignment.start,
//       children: <Widget>[
//         Text(
//           label,
//           style: TextStyle(fontSize: 15, fontWeight: FontWeight.w400, color: Colors.black87),
//         ),
//         SizedBox(
//           height: 5,
//         ),
//         TextField(
//           controller: controller,
//           obscureText: label != "Tài khoản" && label != "Email" ? _obscureTextPassword : false,
//           decoration: InputDecoration(
//             contentPadding: EdgeInsets.symmetric(vertical: 0, horizontal: 10),
//             enabledBorder: OutlineInputBorder(borderSide: BorderSide(color: Colors.grey[400])),
//             border: OutlineInputBorder(borderSide: BorderSide(color: Colors.grey[400])),
//             suffixIcon: label != "Tài khoản" && label != "Email"
//                 ? IconButton(icon: obscureText ? Icon(Icons.remove_red_eye) : Icon(Icons.visibility_off), onPressed: _showOrHidePassword)
//                 : null,
//           ),
//         ),
//         SizedBox(
//           height: 30,
//         ),
//       ],
//     );
//   }
// }
