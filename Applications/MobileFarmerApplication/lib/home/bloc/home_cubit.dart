import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'home_state.dart';

class HomeCubit extends Cubit<HomeState> {
  final ByreRepository _byreRepository;
  final CowRepository _cowRepository;
  HomeCubit(this._byreRepository, this._cowRepository) : super(HomeInitial());

  Future<void> clickMenu(Items items) async {
    emit(HomeMenu(items: items));
  }

  Future<void> checkAmountByre(FarmerInfoModel farmerInfoModel) async {
    try {
      final ByreModel byre =
          await _byreRepository.getByreByFarmerId();
      int amonth = byre.byreItem.length;
      emit(CheckByreLoaded(amonth));
    } catch (Exception) {
      emit(Exception("Couldn't fetch weather. Is the device online?"));
    }       
  }

  Future<void> getListCow() async {
    try {
      final CowModel cowModel = await _cowRepository.getAllCow();

      emit(GetListCowLoaded(cowModel));
    } catch (Exception) {
      emit(Exception("Couldn't fetch weather. Is the device online?"));
    }
  }

  // Future<void> checkFarmer(FarmerInfoModel farmerInfoModel) async {
  //   try {
  //     //emit(WeatherLoading());
  //     if (farmerInfoModel == null) {
  //       emit(CheckFarmer("Bạn chưa phải nông dân"));
  //     } else {
  //       final ByreModel byre = await _byreRepository.getAllByre();
  //       int amonth = byre.byreItem.length;
  //       emit(CheckByreLoaded(amonth));
  //     }
  //   } catch (Exception) {
  //     emit(Exception("Couldn't fetch weather. Is the device online?"));
  //   }
  // }
}
