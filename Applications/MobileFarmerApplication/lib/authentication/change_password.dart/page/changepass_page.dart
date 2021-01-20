import 'package:AgrifoodApp/authentication/bloc/authentication.dart';
import 'package:AgrifoodApp/authentication/bloc/authentication_cubit.dart';
import 'package:AgrifoodApp/authentication/change_password.dart/component/dialog_changpassword.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../models/changepass_model.dart';

class ChangePassPage extends StatefulWidget {
  @override
  _ChangePassPageState createState() => _ChangePassPageState();
}

class _ChangePassPageState extends State<ChangePassPage> {
  bool isValid = false;
  final _oldPasswordController = TextEditingController();
  final _newpasswordController = TextEditingController();
  final _confirmpasswordController = TextEditingController();

  bool _obscureTextOldPassword = true;
  bool _obscureTextNewPassword = true;
  bool _obscureTextConfirmPassword = true;

  void submitPasswordNew(BuildContext context, ChangePassModel model) {
    final authenticationCubit = context.read<AuthenticationCubit>();
    authenticationCubit.changePass(model);
  }

  String get name => null;
  @override
  void dispose() {
    _oldPasswordController.dispose();
    _newpasswordController.dispose();
    _confirmpasswordController.dispose();
    super.dispose();
  }

  void showPassword(String textConfirm) {
    setState(() {
      if (textConfirm == "oldPassword") {
        _obscureTextOldPassword = !_obscureTextOldPassword;
      } else if (textConfirm == "newPassword") {
        _obscureTextNewPassword = !_obscureTextNewPassword;
      } else {
        _obscureTextConfirmPassword = !_obscureTextConfirmPassword;
      }
    });
  }

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<AuthenticationCubit, AuthenticationState>(
      listener: (context, state) {
        if (state is ChangePassLoaded) {
          return showDialog(
              context: context,
              builder: (BuildContext context) {
                return dialogChangPassword(context: context, state: state);
              });
        }
        if (state is ChangePassLoading) {
          return SplashPage();
        }
      },
      builder: (context, state) {
        return MaterialApp(
          home: Scaffold(
            appBar: AppBar(
              centerTitle: true,
              title: Text('Đổi mật khẩu'),
              backgroundColor: Color(0xff9CCC65),
              leading: IconButton(
                icon: Icon(Icons.arrow_back),
                onPressed: () => Navigator.pop(context, false),
              ),
            ),
            body: Form(
              key: _formKey,
              child: Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.only(top: 20, bottom: 20),
                    child: Text('Vui lòng nhập thông tin',
                        style: TextStyle(
                            fontSize: 18, fontWeight: FontWeight.bold)),
                  ),
                  Padding(
                    padding: EdgeInsets.fromLTRB(20, 10, 20, 0),
                    child: textForm(
                        controller: _oldPasswordController,
                        showPassword: showPassword,
                        text: "oldPassword",
                        labelText: "Mật khẩu cũ",
                        obscureText: _obscureTextOldPassword),
                  ),
                  Padding(
                    padding: EdgeInsets.fromLTRB(20, 20, 20, 0),
                    child: textForm(
                        controller: _newpasswordController,
                        showPassword: showPassword,
                        text: "newPassword",
                        labelText: "Mật khẩu mới",
                        obscureText: _obscureTextNewPassword),
                  ),
                  Padding(
                    padding: EdgeInsets.fromLTRB(20, 20, 20, 0),
                    child: textForm(
                        controller: _confirmpasswordController,
                        showPassword: showPassword,
                        text: "reNewPassword",
                        labelText: "Nhập lại mật khẩu mới",
                        obscureText: _obscureTextConfirmPassword),
                  ),
                  Container(
                    decoration: BoxDecoration(
                        borderRadius: BorderRadius.all(
                          Radius.circular(27),
                        ),
                        color: Color(0xff9CCC65)
                        //gradient: Palette.activeLinearGradient,
                        ),
                    margin: EdgeInsets.only(top: 20.0),
                    child: OutlineButton(
                      color: Colors.transparent,
                      shape: new RoundedRectangleBorder(
                        borderRadius: new BorderRadius.circular(10),
                      ),
                      onPressed: () {
                        setState(() {
                          if (_formKey.currentState.validate()) {
                            ChangePassModel changePassModel =
                                new ChangePassModel(
                                    oldPassword: _oldPasswordController.text,
                                    newPassword: _newpasswordController.text,
                                    reNewPassword: _newpasswordController.text);
                            submitPasswordNew(context, changePassModel);
                          }
                        });
                      },
                      padding: EdgeInsets.only(
                        left: 97,
                        top: 16,
                        right: 97,
                        bottom: 16,
                      ),
                      child: Text(
                        'Xác nhận thay đổi',
                        style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w700,
                          fontFamily: "MyriadPro",
                          fontStyle: FontStyle.normal,
                          fontSize: 16.0,
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
        );
      },
    );
  }
}
