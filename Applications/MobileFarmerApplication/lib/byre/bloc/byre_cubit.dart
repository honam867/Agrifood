//import 'package:AgrifoodApp/byre/model/breed_item.dart';
import 'package:AgrifoodApp/byre/model/byre_item.dart';
import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'byre_state.dart';

class ByreCubit extends Cubit<ByreState> {
  final ByreRepository _byreRepository;
  ByreCubit(this._byreRepository) : super(ByreInitial());

  Future<void> checkAmountByre() async {
    try {
      //emit(WeatherLoading());
      final ByreModel byre = await _byreRepository.getAllByre();
      int amonth = byre.byreItem.length;
      emit(ByreLoaded(amonth));
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

  Future<void> getListByreByFarmerId() async {
    try {
      // List<ByreItem> listByre = [];
      // List<ByreItem> result = [];
      final ByreModel byre = await _byreRepository.getByreByFarmerId();
      // listByre.addAll(byre.byreItem);
      // listByre.forEach((element) async {
      //   BreedItem breedItem = await _byreRepository.getBreedNameByBreedId(breedId: element.breedId);
      //   element.breedName = breedItem.name;
      //   result.add(element);
      //  });
      //  ByreModel byreModel = new ByreModel(byreItem: result);
      emit(GetListByre(byre));
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

  Future<void> addByre({ByreItem byreItem}) async {
    try {
      //emit(WeatherLoading());
      final bool result = await _byreRepository.addByre(byreItem: byreItem);
      if (result == true) {
        emit(Result("Tạo thành công"));
        emit(ByreInitial());
      } else {
        emit(Result("Tạo thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

    Future<void> deleteByre({int byreId}) async {
    try {
      //emit(WeatherLoading());
      final bool result = await _byreRepository.deleteByre(byreId: byreId);
      if (result == true) {
        emit(Result("Xóa thành công"));
        emit(ByreInitial());
      } else {
        emit(Result("Xóa thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

  Future<void> updateByre({int byreId, ByreItem byreItem}) async {
    try {
      //emit(WeatherLoading());
      final bool result = await _byreRepository.updateByre(byreId ,byreItem: byreItem);
      if (result == true) {
        emit(Result("Cập nhật thành công"));
        emit(ByreInitial());
      } else {
        emit(Result("Cập nhật thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }
}
