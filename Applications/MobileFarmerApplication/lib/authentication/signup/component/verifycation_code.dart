import 'package:AgrifoodApp/ui/animation/FadeAnimation.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:toast/toast.dart';
import 'resend_button.dart';

class VerifycationCode extends StatefulWidget {
  @required
  final String phone;

  const VerifycationCode({Key key, this.phone}) : super(key: key);

  @override
  _VerifycationCodeState createState() => _VerifycationCodeState(this.phone);
}

class _VerifycationCodeState extends State<VerifycationCode> {
  var _phone, _value;
  bool isValid = false;
  _VerifycationCodeState(this._phone);

  final FirebaseAuth _firebaseAuth = FirebaseAuth.instance;
  final _codeController = TextEditingController();
  // @override
  // void initState() {
  //   verifyCode(this._phone);
  //   super.initState();
  // }

  bool isCodeSent = false;
  String _verificationId;
  void _onFormSubmitted(String code) async {
    AuthCredential _authCredential = PhoneAuthProvider.credential(verificationId: _verificationId, smsCode: code);
    final FirebaseAuth _firebaseAuth = FirebaseAuth.instance;

    _firebaseAuth.signInWithCredential(_authCredential).then((UserCredential value) {
      if (value.user != null) {
        // Handle loogged in state
        print(value.user.phoneNumber);
        showToast(context: context, string: "done");
        // Navigator.push(
        //     context,
        //     MaterialPageRoute(
        //         builder: (context) => new RestPasswordPhone(
        //               phone: _phone,
        //               value: _value,
        //             )));
        //(Route<dynamic> route) => false);
      } else {
        print("Sai");
      }
    }).catchError((error) {
      Toast.show("Mã xác nhận không đúng!!", context, duration: Toast.LENGTH_SHORT, gravity: Toast.CENTER);
    });
  }

  void verifyCode(String phone) async {
    setState(() {
      isCodeSent = true;
    });
    final PhoneVerificationCompleted verificationCompleted = (AuthCredential phoneAuthCredential) {
      _firebaseAuth.signInWithCredential(phoneAuthCredential).then((UserCredential value) {
        if (value.user != null) {
          // Handle loogged in state
          print(value.user.phoneNumber);
          // Navigator.pushAndRemoveUntil(
          //     context,
          //     MaterialPageRoute(builder: (context) => CheckCodePage()),
          //     (Route<dynamic> route) => false);
        } else {
          print("sai ma");
        }
      }).catchError((error) {
        print("Sai");
      });
    };

    final PhoneVerificationFailed verificationFailed = (FirebaseAuthException authException) {
      print(authException.message);
      setState(() {
        isCodeSent = false;
      });
    };

    final PhoneCodeSent codeSent = (String verificationId, [int forceResendingToken]) async {
      _verificationId = verificationId;
      setState(() {
        _verificationId = verificationId;
      });
    };
    final PhoneCodeAutoRetrievalTimeout codeAutoRetrievalTimeout = (String verificationId) {
      _verificationId = verificationId;
      setState(() {
        _verificationId = verificationId;
      });
    };

    await _firebaseAuth.verifyPhoneNumber(
        phoneNumber: "+84${widget.phone}",
        timeout: const Duration(seconds: 60),
        verificationCompleted: verificationCompleted,
        verificationFailed: verificationFailed,
        codeSent: codeSent,
        codeAutoRetrievalTimeout: codeAutoRetrievalTimeout);
  }

  @override
  void dispose() {
    _codeController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Lấy lại mật khẩu', style: TextStyle(color: Colors.white)),
        leading: IconButton(
            icon: Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.pop(context);
            }),
        elevation: 1.0,
        flexibleSpace: Container(
          decoration: BoxDecoration(
            gradient: LinearGradient(
              begin: Alignment.topLeft,
              end: Alignment.bottomRight,
              colors: <Color>[
                Color.fromRGBO(24, 133, 196, 1),
                Color.fromRGBO(216, 44, 46, 1),
              ],
            ),
          ),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.only(top: 20, right: 20, left: 20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            FadeAnimation(
                1.7,
                Container(
                  decoration: BoxDecoration(borderRadius: BorderRadius.circular(10), color: Colors.white, boxShadow: [
                    BoxShadow(
                      color: Color.fromRGBO(130, 100, 240, 3),
                      blurRadius: 20,
                      offset: Offset(0, 10),
                    )
                  ]),
                  child: Column(
                    children: <Widget>[
                      Container(
                        padding: EdgeInsets.all(10),
                        decoration: BoxDecoration(border: Border(bottom: BorderSide(color: Colors.grey[200]))),
                        child: TextField(
                          controller: _codeController,
                          // onChanged: (value) {
                          //   this.phoneNo = value;
                          // },
                          decoration: InputDecoration(
                              border: InputBorder.none,
                              //errorText: _phoneInvail ? _phoneError : null,
                              hintText: "Vui lòng nhập mã xác nhận",
                              hintStyle: TextStyle(color: Colors.grey)),
                        ),
                      ),
                    ],
                  ),
                )),
            FadeAnimation(
                1.9,
                Container(
                  padding: EdgeInsets.fromLTRB(0, 10, 0, 0),
                  child: Center(
                    child: ResendButton(onPress: () {
                      verifyCode(this._phone);
                    }),
                  ),
                )),
            SizedBox(
              height: 5,
            ),
            FadeAnimation(
                1.9,
                Container(
                  padding: EdgeInsets.fromLTRB(0, 10, 0, 0),
                  child: Center(
                    child: ConfirmButton(onPress: () {
                      setState(() {
                        final code = _codeController.text.trim();
                        _onFormSubmitted(code);
                      });
                    }),
                  ),
                )),
            SizedBox(
              height: 30,
            ),
          ],
        ),
      ),
    );
  }
}
