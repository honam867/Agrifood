import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'home_state.dart';

class HomeCubit extends Cubit<HomeState> {
  final ByreRepository _byreRepository;
  HomeCubit(this._byreRepository) : super(HomeInitial());

  Future<void> clickMenu(Items items) async {
    emit(HomeMenu(items: items));
  }

  Future<void> checkAmountByre() async {
    try {
      //emit(WeatherLoading());
      final ByreModel byre = await _byreRepository.getAllByre();
      int amonth = byre.byreItem.length;
      emit(CheckByreLoaded(amonth));
    } catch (Exception) {
      emit(Exception("Couldn't fetch weather. Is the device online?"));
    }
  }
}
