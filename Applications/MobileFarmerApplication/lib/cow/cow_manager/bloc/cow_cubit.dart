import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'cow_state.dart';

class CowCubit extends Cubit<CowState> {
  final CowRepository _cowRepository;
  CowCubit(this._cowRepository) : super(CowInitial());

  // Future<void> checkAmountCow() async {
  //   try {
  //     //emit(WeatherLoading());
  //     final CowModel byre = await _cowRepository.getAllCow();
  //     int amonth = byre.byreItem.length;
  //     emit(CowLoaded(amonth));
  //   } catch (Exception) {
  //     emit(Exception("Kiểm tra lại kết nối của bạn"));
  //   }
  // }

  Future<void> getListCow() async {
    try {
      //emit(WeatherLoading());
      final CowModel byre = await _cowRepository.getAllCow();
      emit(CowLoaded(byre));
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

  Future<void> addCow({CowItem cowItem}) async {
    try {
      //emit(WeatherLoading());
      final bool result = await _cowRepository.addCow(cowItem: cowItem);
      if (result == true) {
        emit(Result("Tạo thành công"));
        emit(CowInitial());
      } else {
        emit(Result("Tạo thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

  Future<void> deleteCow({int cowId}) async {
    try {
      //emit(WeatherLoading());
      final bool result = await _cowRepository.deleteCow(cowId: cowId);
      if (result == true) {
        emit(Result("Xóa thành công"));
        emit(CowInitial());
      } else {
        emit(Result("Xóa thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }

  Future<void> updateCow({int byreId, CowItem cowItem}) async {
    try {
      //emit(WeatherLoading());
      final bool result =
          await _cowRepository.updateCow(byreId, cowItem: cowItem);
      if (result == true) {
        emit(Result("Cập nhật thành công"));
        emit(CowInitial());
      } else {
        emit(Result("Cập nhật thất bại"));
      }
    } catch (Exception) {
      emit(Exception("Kiểm tra lại kết nối của bạn"));
    }
  }
}
