import 'package:AgrifoodApp/authentication/login/component/login_form.dart';
import 'package:AgrifoodApp/authentication/login/login_bloc.dart';
import 'package:AgrifoodApp/authentication/login/page/onboarding.dart';
import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/home_page.dart';
import 'package:AgrifoodApp/home/page/home_page_new.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/ui/utils/palette.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'authentication/bloc/authentication.dart';
import 'respository/authentication_repository.dart';
import 'ui/splash_page.dart';
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

void main() async {
  Bloc.observer = AppBlocDelegate();
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp();
  final authenticationRepository = AuthenticationRepository();

  runApp(
    BlocProvider<AuthenticationBloc>(
      create: (context) {
        return AuthenticationBloc(authenticationRepository)
          ..add(AppStarted(loginModel: null));
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
    return ScreenUtilInit(
      designSize: Size(1080, 2340),
      allowFontScaling: false,
      builder: () => MaterialApp(
        title: 'Agrifood App',
        theme: ThemeData(
          scaffoldBackgroundColor: Palette.white,
        ),
        routes: {
          '/home': (_) => HomePage(),
          '/test': (_) => InitPage(
                authenticationRepository: authenticationRepository,
              )
        },
        home: BlocBuilder<AuthenticationBloc, AuthenticationState>(
          builder: (context, state) {
            final ByreRepository byreRepository = new ByreRepository();
            final CowRepository cowRepository = new CowRepository();
            if (state is AuthenticationAuthenticated) {
              return BlocProvider(
                  create: (context) {
                    return HomeCubit(byreRepository, cowRepository);
                  },
                  // child: HomePage(
                  //   farmerInfoModel: state.farmerInfoModel,
                  // ));
                  child: MyHomePage(farmerInfoModel: state.farmerInfoModel));
            }
            if (state is LoginFormButtonState) {
              return BlocProvider(
                  create: (context) {
                    return LoginBloc(
                      authenticationBloc:
                          BlocProvider.of<AuthenticationBloc>(context),
                      authenticationRepository: authenticationRepository,
                    );
                  },
                  child: LoginComponent());
            }
            if (state is AuthenticationLoginPage) {
              return InitPage(
                authenticationRepository: authenticationRepository,
              );
            }
            if (state is AuthenticationUnauthenticated) {
              return OnBoardingPage();
            }
            if (state is AuthenticationLoading) {
              return SplashPage();
            }
            return SplashPage();
          },
        ),
      ),
    );
  }
}
