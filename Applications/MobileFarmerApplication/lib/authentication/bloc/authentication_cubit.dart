import 'package:AgrifoodApp/respository/authentication_repository.dart';
import 'package:AgrifoodApp/respository/register_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'authentication.dart';

class AuthenticationCubit extends Cubit<AuthenticationState> {
  final RegisterReponsitory _registerReponsitory;
  AuthenticationCubit(
    this._registerReponsitory,
  ) : super(AuthenticationUnauthenticated());

  Future<void> checkPhoneNumber(String phoneNumber) async {
    try {
      // emit(WeatherLoading());
      final result = await this._registerReponsitory.checkPhoneNumber(phoneNumber: phoneNumber);

      emit(CheckPhoneNumberLoaded(result));
    } catch (ex) {
      print(ex);
    }
  }
}
