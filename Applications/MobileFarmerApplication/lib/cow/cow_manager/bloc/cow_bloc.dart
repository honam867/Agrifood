import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/core/storage.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'cow_event.dart';
part 'cow_state.dart';

class CowBloc extends Bloc<CowEvent, CowState> {
  final CowRepository cowRepository;
  final FoodSuggestionRepository foodSuggestionRepository;
  final ByreRepository byreRepository;

  CowBloc(
      {this.cowRepository, this.foodSuggestionRepository, this.byreRepository})
      : super(CowLoadInprocess());

  @override
  Stream<CowState> mapEventToState(CowEvent event) async* {
    if (event is CowLoadedSucces) {
      yield* _mapCowLoadedToState();
    } else if (event is CowAddProcess) {
      yield* _mapTodoAddedToState(event);
    } else if (event is CowUpdated) {
      yield* _mapTodoUpdatedToState(event);
    } else if (event is CowDeleteProcess) {
      yield* _mapTodoDeletedToState(event);
    } else if (event is FoodSuggestionSuccess) {
      yield* _mapFoodSuggestionLoadInprocessToState();
    } else if (event is ClearCompleted) {
      //yield* _mapClearCompletedToState();
    } else if (event is GetCowByByreId) {
      yield* _mapGetCowByByreIdState(event);
    } else if (event is GetCowByFarmerId){
      yield* _mapGetCowByFarmerIdState(event);
    }
  }

  Stream<CowState> _mapCowLoadedToState() async* {
    try {
      final cowModel = await this.cowRepository.getAllCow();
      yield CowLoaded(cowModel);
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapGetCowByByreIdState(GetCowByByreId event) async* {
    try {
      final cowModel =
          await this.cowRepository.getCowByByreId(byreId: event.id);
      yield CowLoaded(cowModel);
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapGetCowByFarmerIdState(GetCowByFarmerId event) async* {
    try {
      var farmerId = await Storage.getString("farmerId");
      final cowModel =
          await this.cowRepository.getCowByFatmerId(farmerId: int.parse(farmerId));
      yield CowLoaded(cowModel);
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapTodoAddedToState(CowAddProcess event) async* {
    try {
      final result = await this.cowRepository.addCow(cowItem: event.cowItem);
      if (result == true) {
        final cowModel = await this.cowRepository.getAllCow();
        yield CowLoaded(cowModel);
      }
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapTodoDeletedToState(CowDeleteProcess event) async* {
    try {
      final result = await this.cowRepository.deleteCow(cowId: event.id);
      if (result == true) {
        final cowModel = await this.cowRepository.getAllCow();
        yield CowLoaded(cowModel);
        yield CowDeleted("Xóa thành công!");
      }
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapFoodSuggestionLoadInprocessToState() async* {
    try {
      final foodSuggestionModel =
          await this.foodSuggestionRepository.getAllFoodSuggestion();
      final byreModel = await this.foodSuggestionRepository.getAllByre();
      final cowModel = await this.cowRepository.getAllCow();
      yield FoodSuggestionLoaded(foodSuggestionModel, byreModel, cowModel);
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapTodoUpdatedToState(CowUpdated event) async* {
    final result = await this
        .cowRepository
        .updateCow(event.cowItem.id, cowItem: event.cowItem);
    if (result == true) {
      yield CowUpdateResult("Cập nhật thành công");
    } else {
      yield CowUpdateResult("Cập nhật thất bại");
    }
  }

  Future _saveCow(CowModel cow) {
    return cowRepository.getAllCow();
  }
}
