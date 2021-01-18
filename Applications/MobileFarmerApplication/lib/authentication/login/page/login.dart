// import 'package:AgrifoodApp/authentication/bloc/authentication.dart';
// import 'package:AgrifoodApp/authentication/login/component/login_form.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';
// import 'package:flutter_screenutil/flutter_screenutil.dart';
// import '../../../respository/authentication_repository.dart';
// import '../login_bloc.dart';


// class LoginPage extends StatelessWidget {
//   final AuthenticationRepository authenticationRepository;


//   LoginPage({Key key, @required this.authenticationRepository})
//       : assert(authenticationRepository != null),
//         super(key: key);

//   Widget horizontalLine() {
//     return Padding(
//       padding: EdgeInsets.symmetric(horizontal: 16.0),
//       child: Container(
//         width: ScreenUtil.getInstance().setWidth(120),
//         height: 1.0,
//         color: Colors.black26.withOpacity(.2),
//       ),
//     );
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       backgroundColor: Colors.grey[200],
//       body: BlocProvider(
//           create: (context) {
//             return LoginBloc(
//               authenticationBloc: BlocProvider.of<AuthenticationBloc>(context),
//               authenticationRepository: authenticationRepository,
//             );
//           },
//           child: LoginComponent()),
//     );
//   }
// }

