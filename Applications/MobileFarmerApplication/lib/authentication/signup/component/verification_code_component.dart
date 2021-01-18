// import 'package:AgrifoodApp/authentication/signup/bloc/signUp_cubit.dart';
// import 'package:AgrifoodApp/authentication/signup/component/verification_phoneNumber_component.dart';
// import 'package:AgrifoodApp/authentication/signup/page/signup.dart';
// import 'package:AgrifoodApp/respository/register_repository.dart';
// import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
// import 'package:AgrifoodApp/ui/utils/show_toast.dart';
// import 'package:firebase_auth/firebase_auth.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';

// class VerificationCodeComponent extends StatefulWidget {
//   final String phoneNumber;

//   const VerificationCodeComponent({Key key, this.phoneNumber}) : super(key: key);
//   @override
//   _VerificationCodeComponentState createState() => _VerificationCodeComponentState();
// }

// class _VerificationCodeComponentState extends State<VerificationCodeComponent> {
//   final FirebaseAuth _firebaseAuth = FirebaseAuth.instance;

//   TextEditingController _codeController = TextEditingController();
//   bool isCodeSent = false;
//   String _verificationId;
//   @override
//   void initState() {
//     WidgetsBinding.instance.addPostFrameCallback((_) {
//       this.verifyCode(widget.phoneNumber);
//     });
//     super.initState();
//   }

//   void _onFormSubmitted(String code) async {
//     AuthCredential _authCredential = PhoneAuthProvider.credential(verificationId: _verificationId, smsCode: code);
//     final FirebaseAuth _firebaseAuth = FirebaseAuth.instance;

//     _firebaseAuth.signInWithCredential(_authCredential).then((UserCredential value) {
//       if (value.user != null) {
//         Navigator.push(
//             context,
//             MaterialPageRoute(
//               builder: (context) => BlocProvider(
//                   create: (context) => SignUpCubit(RegisterReponsitory()),
//                   child: new SignUpPage(
//                     phoneNumber: widget.phoneNumber,
//                   )),
//             ));
//       }
//     }).catchError((error) {
//       print(error);
//     });
//   }

//   void verifyCode(String phone) async {
//     setState(() {
//       isCodeSent = true;
//     });
//     final PhoneVerificationCompleted verificationCompleted = (AuthCredential phoneAuthCredential) {
//       _firebaseAuth.signInWithCredential(phoneAuthCredential).then((UserCredential value) {
//         if (value.user != null) {
//           print(value.user.phoneNumber);
//           //Navigator.pushAndRemoveUntil(context, MaterialPageRoute(builder: (context) => CheckCodePage()), (Route<dynamic> route) => false);
//         } else {
//           print("sai ma");
//         }
//       }).catchError((error) {
//         print("Sai");
//       });
//     };
//     PhoneVerificationFailed verificationFailed = (FirebaseAuthException authException) {
//       showToast(string: 'Mã xác nhận không đúng. Code: ${authException.code}. Message: ${authException.message}', context: context);
//     };
//     final PhoneCodeAutoRetrievalTimeout codeAutoRetrievalTimeout = (String verificationId) {
//       _verificationId = verificationId;
//       setState(() {
//         _verificationId = verificationId;
//       });
//     };
//     PhoneCodeSent codeSent = (String verificationId, [int forceResendingToken]) async {
//       showToast(string: "Mã đã được gửi về số điện thoại", context: context);
//       _verificationId = verificationId;
//     };

//     try {
//       await _firebaseAuth.verifyPhoneNumber(
//           phoneNumber: "+84${widget.phoneNumber}",
//           timeout: const Duration(seconds: 5),
//           verificationCompleted: verificationCompleted,
//           verificationFailed: verificationFailed,
//           codeSent: codeSent,
//           codeAutoRetrievalTimeout: codeAutoRetrievalTimeout);
//     } catch (e) {
//       print(e);
//     }
//   }

//   @override
//   void dispose() {
//     _codeController.dispose();
//     super.dispose();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//         resizeToAvoidBottomInset: true,
//         backgroundColor: Colors.white,
//         appBar: AppBar(
//           elevation: 0,
//           brightness: Brightness.light,
//           backgroundColor: Colors.white,
//           leading: IconButton(
//             onPressed: () {
//               Navigator.pop(context);
//             },
//             icon: Icon(
//               Icons.arrow_back_ios,
//               size: 20,
//               color: Colors.black,
//             ),
//           ),
//         ),
//         body: SingleChildScrollView(
//             child: Container(
//                 padding: EdgeInsets.symmetric(horizontal: 40),
//                 height: MediaQuery.of(context).size.height - 50,
//                 width: double.infinity,
//                 child: Column(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: <Widget>[
//                   Column(
//                     children: <Widget>[
//                       FadeAnimation(
//                           1,
//                           Text(
//                             "Xác thực mã xác nhận",
//                             style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
//                           )),
//                       SizedBox(
//                         height: 20,
//                       ),
//                       FadeAnimation(
//                           1.2,
//                           Text(
//                             "Mã xác thực đã được gửi về số điện thoại",
//                             style: TextStyle(fontSize: 15, color: Colors.grey[700]),
//                           )),
//                     ],
//                   ),
//                   Column(
//                     children: <Widget>[
//                       FadeAnimation(1.2, makeInput(label: "Mã xác nhận", controller: _codeController)),
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
//                               final code = _codeController.text.trim();
//                               _onFormSubmitted(code);
//                             });
//                           },
//                           color: Colors.greenAccent,
//                           elevation: 0,
//                           shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(50)),
//                           child: Text(
//                             "Xác nhận",
//                             style: TextStyle(fontWeight: FontWeight.w600, fontSize: 18),
//                           ),
//                         ),
//                       ))
//                 ]))));
//   }
// }
