import 'package:flutter/material.dart';
import '../../../respository/register_repository.dart';
import 'sign_up_company.dart';

class SignUpPage extends StatefulWidget {
  @required
  final int codeId;
  const SignUpPage({Key key, this.codeId}) : super(key: key);
  @override
  _SignUpPageState createState() => _SignUpPageState(this.codeId);
}

class _SignUpPageState extends State<SignUpPage> {
  final RegisterReponsitory registerReponsitory = new RegisterReponsitory();



  var group = 1;
  int _codeId;

  bool isValid = false;


  _SignUpPageState(this._codeId);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          centerTitle: true,
          title: Text('Đăng ký tài khoản'),
          leading: IconButton(
              icon: Icon(Icons.arrow_back),
              onPressed: () {
                Navigator.pushReplacementNamed(context, "/");
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
        body: SingleChildScrollView(
            child: Card(
          child: Container(
            height: MediaQuery.of(context).size.height,
            width: MediaQuery.of(context).size.width,
            child: Card(
              child: Column(
                children: <Widget>[
                 SignUpCompany(codeId: _codeId,)
                  
                  
                ],
              ),
            ),
          ),
        )));
  }
}
