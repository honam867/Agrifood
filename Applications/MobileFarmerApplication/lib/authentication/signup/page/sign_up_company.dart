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

// class SignUpCompany extends StatefulWidget {
//   @required
//   final int codeId;
//   const SignUpCompany({Key key, this.codeId}) : super(key: key);
//   @override
//   _SignUpCompanyState createState() => _SignUpCompanyState(this.codeId);
// }

// class _SignUpCompanyState extends State<SignUpCompany> {
//   final RegisterReponsitory registerReponsitory = new RegisterReponsitory();

//   SignUpModel customerItem = new SignUpModel();
//   TextEditingController _nameController = TextEditingController();
//   TextEditingController _usernameController = TextEditingController();
//   TextEditingController _passController = TextEditingController();
//   TextEditingController _emailController = TextEditingController();
//   TextEditingController _phoneNumberController = TextEditingController();
//   TextEditingController _lastNameController = TextEditingController();

//   TextEditingController _otherContactController = TextEditingController();
//   TextEditingController _remarksController = TextEditingController();

//   var group = true;
//   int _codeId;
//   bool _obscureTextPassword = true;
//   bool isValid = false;
//   var _nameLength;
//   var _passLength;
//   var _userNameLength;

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
//   bool _nameInvalid = false;
//   bool _emailInvalid = false;
//   bool _phoneInvalid = false;

//   String text = '';

//   var _usernameError = "Tên đăng nhập không được bỏ trống";
//   var _passError = "Mật khẩu không được bỏ trống";
//   var _nameError = "Tên không được bỏ trống";
//   var _phoneError = "Số điện thoại  không được bỏ trống";

//   var _emailError = "Email không được bỏ trống";

//   _SignUpCompanyState(this._codeId);

//   @override
//   void initState() {
//     _nameController = TextEditingController();
//     _usernameController = TextEditingController();
//     _passController = TextEditingController();
//     _lastNameController = TextEditingController();
//     _otherContactController = TextEditingController();
//     _emailController = TextEditingController();
//     _phoneNumberController = TextEditingController();
//     _remarksController = TextEditingController();

//     super.initState();
//   }

//   @override
//   void dispose() {
//     _nameController.dispose();
//     _usernameController.dispose();
//     _passController.dispose();
//     _lastNameController.dispose();
//     _otherContactController.dispose();
//     _emailController.dispose();
//     _phoneNumberController.dispose();
//     _remarksController.dispose();

//     super.dispose();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Container(
//       child: Column(
//         children: <Widget>[
//           Container(
//               width: double.maxFinite,
//               margin: EdgeInsets.fromLTRB(20, 10, 20, 20),
//               child: Column(
//                 children: <Widget>[
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _usernameController,
//                           onChanged: (value) {
//                             _usernameController.value = TextEditingValue(text: value.toLowerCase(), selection: _usernameController.selection);
//                           },
//                           decoration: InputDecoration(
//                               border: OutlineInputBorder(),
//                               errorText: _usernameInvalid ? _usernameError : _userNameLength,
//                               labelText: 'Tên đăng nhập *'),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextFormField(
//                           controller: _passController,
//                           onTap: () {
//                             setState(() {
//                               _usernameController.text.isEmpty ? _usernameInvalid = true : _usernameInvalid = false;

//                               if (_usernameController.text.length < 6 && _usernameInvalid == false) {
//                                 _userNameLength = "Tên đăng nhập không hợp lê";
//                               } else {
//                                 _userNameLength = null;
//                               }
//                             });
//                           },
//                           onChanged: (password) {
//                             checkValidation();
//                           },
//                           obscureText: _obscureTextPassword,
//                           style: TextStyle(color: Colors.black, fontFamily: 'SFUIDisplay'),
//                           decoration: InputDecoration(
//                               border: OutlineInputBorder(),
//                               labelText: 'Mật khẩu *',
//                               errorText: _passwordInvalid ? _passError : _passLength,
//                               suffixIcon: IconButton(
//                                 icon: _obscureTextPassword ? Icon(Icons.remove_red_eye) : Icon(Icons.visibility_off),
//                                 onPressed: _showOrHidePassword,
//                               ),
//                               labelStyle: TextStyle(fontSize: 15)),
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _nameController,
//                           onTap: () {
//                             setState(() {
//                               _passController.text.isEmpty ? _passwordInvalid = true : _passwordInvalid = false;
//                               _usernameController.text.isEmpty ? _usernameInvalid = true : _usernameInvalid = false;

//                               if (_passController.text.length < 6 && _passwordInvalid == false) {
//                                 _passLength = "Mật khẩu không hợp lê";
//                               } else {
//                                 _passLength = null;
//                               }
//                             });
//                           },
//                           decoration: InputDecoration(
//                             border: OutlineInputBorder(),
//                             labelText: 'Tên khách hàng *',
//                             errorText: _nameInvalid ? _nameError : _nameLength,
//                           ),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _lastNameController,
//                           onTap: () {
//                             setState(() {
//                               _nameController.text.isEmpty ? _nameInvalid = true : _nameInvalid = false;

//                               if (_nameController.text.length < 2 && _nameInvalid == false) {
//                                 _nameLength = "Tên không hợp lê";
//                               } else {
//                                 _nameLength = null;
//                               }
//                             });
//                           },
//                           decoration: InputDecoration(
//                             border: OutlineInputBorder(),
//                             labelText: 'Họ khách hàng',
//                           ),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Card(
//                     child: Row(
//                       mainAxisAlignment: MainAxisAlignment.spaceAround,
//                       children: <Widget>[
//                         Text("Giới tính"),
//                         SizedBox(
//                           width: 50,
//                         ),
//                         Radio(
//                           value: true,
//                           groupValue: group,
//                           onChanged: (var value) {
//                             setState(() {
//                               // _lastNameController.text.isEmpty
//                               //     ? _lastNameInvalid = true
//                               //     : _lastNameInvalid = false;
//                               group = value;
//                               print('$group');
//                             });
//                           },
//                         ),
//                         Text("Nam"),
//                         SizedBox(
//                           width: 60,
//                         ),
//                         Radio(
//                           value: false,
//                           groupValue: group,
//                           onChanged: (var value) {
//                             setState(() {
//                               // _lastNameController.text.isEmpty
//                               //     ? _lastNameInvalid = true
//                               //     : _lastNameInvalid = false;
//                               group = value;
//                               print('$group');
//                             });
//                           },
//                         ),
//                         Text("Nữ"),
//                       ],
//                     ),
//                   ),
//                   SizedBox(
//                     height: 10,
//                   ),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _emailController,
//                           decoration: InputDecoration(
//                             border: OutlineInputBorder(),
//                             labelText: 'Email ',
//                             errorText: _emailInvalid ? _emailError : null,
//                           ),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _phoneNumberController,
//                           keyboardType: TextInputType.number,
//                           onTap: () {
//                             setState(() {
//                               _emailController.text.isEmpty ? _emailInvalid = true : _emailInvalid = false;
//                             });
//                           },
//                           decoration: InputDecoration(
//                             labelText: 'Số điện thoại *',
//                             border: OutlineInputBorder(),
//                             errorText: _phoneInvalid ? _phoneError : null,
//                           ),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _otherContactController,
//                           keyboardType: TextInputType.number,
//                           onTap: () {
//                             setState(() {
//                               _phoneNumberController.text.isEmpty ? _phoneInvalid = true : _phoneInvalid = false;
//                             });
//                           },
//                           decoration: InputDecoration(
//                             border: OutlineInputBorder(),
//                             labelText: 'Liên hệ khác',
//                           ),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   Row(
//                     children: <Widget>[
//                       Flexible(
//                         child: TextField(
//                           controller: _remarksController,
//                           onTap: () {
//                             setState(() {});
//                           },
//                           decoration: InputDecoration(
//                             border: OutlineInputBorder(),
//                             labelText: 'Ghi chú',
//                           ),
//                           style: Theme.of(context).textTheme.body1,
//                         ),
//                       ),
//                     ],
//                   ),
//                   SizedBox(height: 10),
//                   MaterialButton(
//                       shape: RoundedRectangleBorder(borderRadius: BorderRadius.all(Radius.circular(10))),
//                       child: Text('Đăng ký',
//                           textAlign: TextAlign.center, style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 16.0)),
//                       color: Palette.dodgerBlue,
//                       onPressed: () async {
//                         setState(() async {
//                           _nameController.text.isEmpty ? _nameInvalid = true : _nameInvalid = false;
//                           _passController.text.isEmpty ? _passwordInvalid = true : _passwordInvalid = false;
//                           _usernameController.text.isEmpty ? _usernameInvalid = true : _usernameInvalid = false;
//                           _emailController.text.isEmpty ? _emailInvalid = true : _emailInvalid = false;
//                           _phoneNumberController.text.isEmpty ? _phoneInvalid = true : _phoneInvalid = false;

//                           if (!_nameInvalid && !_passwordInvalid && !_usernameInvalid && !_emailInvalid && !_phoneInvalid) {
//                             RegisterReponsitory registerReponsitory = new RegisterReponsitory();
//                             SignUpModel signUpModel = new SignUpModel();

//                             signUpModel.name = _nameController.text ?? "";
//                             signUpModel.userName = _usernameController.text ?? "";
//                             signUpModel.customerId = _codeId;
//                             signUpModel.password = _passController.text ?? "";
//                             signUpModel.email = _emailController.text ?? "";
//                             if (_lastNameController.text.isNotEmpty) {
//                               signUpModel.lastName = _lastNameController.text;
//                             } else {
//                               signUpModel.lastName = "null";
//                             }
//                             signUpModel.phoneNumber = int.parse(_phoneNumberController.text) ?? "";
//                             // signUpModel.otherContact =
//                             //     int.parse(_otherContactController.text) ??
//                             //         "";
//                             signUpModel.sex = group;

//                             if (_remarksController.text.isNotEmpty) {
//                               signUpModel.remarks = _remarksController.text;
//                             } else {
//                               signUpModel.remarks = "null";
//                             }
//                             if (_otherContactController.text.isNotEmpty) {
//                               signUpModel.otherContact = int.parse(_otherContactController.text);
//                             } else {
//                               signUpModel.otherContact = int.parse("0");
//                             }

//                             var checkrs = await registerReponsitory.newUser(signUpModel: signUpModel);

//                             if (checkrs == true) {
//                               Bloc.observer = AppBlocDelegate();
//                               final authenticationRepository = AuthenticationRepository();
//                               Navigator.push(
//                                   context, MaterialPageRoute(builder: (context) => new App(authenticationRepository: authenticationRepository)));
//                               Toast.show("Đăng ký thành công", context, duration: Toast.LENGTH_SHORT, gravity: Toast.CENTER);
//                               print('Them thanh cong');
//                             }
//                           } else {
//                             Toast.show("Kiểm tra lại thông tin", context, duration: Toast.LENGTH_SHORT, gravity: Toast.CENTER);
//                           }
//                         });
//                         return SplashPage();
//                       })
//                 ],
//               ))
//         ],
//       ),
//     );
//   }
// }
