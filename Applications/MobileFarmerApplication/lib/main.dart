import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'authentication/authentication.dart';
import 'authentication/login/page/login.dart';
import 'authentication/login/page/onboarding.dart';
import 'respository/authentication_repository.dart';
import 'ui/splash_page.dart';
import 'ui/utils/palette.dart';
import 'authentication/login/page/initpage.dart';

class AppBlocDelegate extends BlocObserver {
  @override
  void onEvent(Bloc bloc, Object event) {
    super.onEvent(bloc, event);
    print(event);
  }

  @override
  void onChange(Cubit cubit, Change change) {
    print(change);
    super.onChange(cubit, change);
  }

  @override
  void onTransition(Bloc bloc, Transition transition) {
    super.onTransition(bloc, transition);
    print(transition);
  }

  @override
  void onError(Cubit cubit, Object error, StackTrace stackTrace) {
    print(error);
    super.onError(cubit, error, stackTrace);
  }
}

void main() {
  Bloc.observer = AppBlocDelegate();
  final authenticationRepository = AuthenticationRepository();

  runApp(
    BlocProvider<AuthenticationBloc>(
      create: (context) {
        return AuthenticationBloc(authenticationRepository)..add(AppStarted());
      },
      child: App(authenticationRepository: authenticationRepository),
    ),
  );
}

class App extends StatelessWidget {
  final AuthenticationRepository authenticationRepository;

  App({Key key, this.authenticationRepository}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Tuloc Technology',
      theme: ThemeData(
        scaffoldBackgroundColor: Palette.white,
      ),
      // routes: {'/home': (_) => LayoutPageNew()},
      home: BlocBuilder<AuthenticationBloc, AuthenticationState>(
        builder: (context, state) {
          if (state is AuthenticationAuthenticated) {
            return HomePage();
          }
          if (state is AuthenticationLoginPage) {
            return LoginPage(
              authenticationRepository: authenticationRepository,
            );
          }
          if (state is AuthenticationUnauthenticated) {
            return InitPage();
          }
          if (state is AuthenticationLoading) {
            return SplashPage();
          }
          return SplashPage();
        },
      ),
    );
  }
}

class HomePage extends StatefulWidget {
  @override
  _HomaPageState createState() => _HomaPageState();
}

class _HomaPageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width,
      height: MediaQuery.of(context).size.height,
    );
  }
}
