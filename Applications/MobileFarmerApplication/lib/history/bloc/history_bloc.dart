//import 'package:AgrifoodApp/core/storage.dart';
import 'package:AgrifoodApp/feedCow/model/feed_history_model.dart';
//import 'package:AgrifoodApp/history/model/day_month.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_model.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/respository/milkingslip_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'history_event.dart';
part 'history_state.dart';

class HistoryBloc extends Bloc<HistoryEvent, HistoryState> {
  final FoodSuggestionRepository foodSuggestionRepository;
  final ByreRepository byreRepository;

  HistoryBloc({this.foodSuggestionRepository, this.byreRepository})
      : super(HistoryLoadInprocess());

  @override
  Stream<HistoryState> mapEventToState(HistoryEvent event) async* {
    if (event is HistoryLoadedSucces) {
      yield* _mapHistoryLoadedToState(event);
    } else if (event is ClearCompleted) {
      //yield* _mapClearCompletedToState();
    } else if (event is GetHistoryByByreId) {
      yield* _mapGetHistoryByByreIdState(event);
    } else if (event is GetHistoryByFarmerId) {
      yield* _mapGetHistoryByFarmerIdState(event);
    } else if (event is OnClickFetchList) {
      yield* _mapOnClickState(event);
    }
  }

  Stream<HistoryState> _mapOnClickState(
      OnClickFetchList event) async* {
    try {
      yield HistoryButtonClick(
        day: event.day,
        farmerId: event.farmerId,
        isFood: event.isFood,
        month: event.month, 
        session: event.session,
        year: event.year
      );
    } catch (_) {
      yield HistoryError();
    }
  }


  Stream<HistoryState> _mapHistoryLoadedToState(
      HistoryLoadedSucces event) async* {
    //yield HistoryLoading();
    try {
      if (event.isFood == false) {
        MilkingSlipRepository milkingSlipRepository =
            new MilkingSlipRepository();
        final mikingSlipId =
            await milkingSlipRepository.getMilkingSlipByDateAsync(
                day: event.day,
                month: event.month,
                year: event.year,
                session: event.session ?? 0);

        if (mikingSlipId != null) {
          final milkingSlipDetailItem =
              await milkingSlipRepository.getMilkingSlipDetailByMilkingSlipId(
                  milkingSlipId: mikingSlipId.id);
          yield HistoryLoaded(historyModel: milkingSlipDetailItem);
        }
      } else if (event.isFood == true) {
        FoodSuggestionRepository foodSuggestionRepository =
            new FoodSuggestionRepository();
        final listFeedHistory =
            await foodSuggestionRepository.getFeedHistoryMaster(
                day: event.day,
                month: event.month,
                year: event.year,
                farmerId: event.farmerId);
        if (listFeedHistory != null) {
          yield HistoryLoaded(feedHistoryModel: listFeedHistory);
        } else {
          yield HistoryLoaded(feedHistoryModel: null);
        }
      }
    } catch (_) {
      yield HistoryError();
    }
  }

  Stream<HistoryState> _mapGetHistoryByByreIdState(
      GetHistoryByByreId event) async* {
    try {
      // final historyModel =
      //     await this.historyRepository.getHistoryByByreId(byreId: event.id);
      // yield HistoryLoaded(historyModel);
    } catch (_) {
      yield HistoryError();
    }
  }

  Stream<HistoryState> _mapGetHistoryByFarmerIdState(
      GetHistoryByFarmerId event) async* {
    try {
      //  var farmerId = await Storage.getString("farmerId");

      // final historyModel =
      //     await this.historyRepository.getHistoryByFatmerId(farmerId: int.parse(farmerId));
      // yield HistoryLoaded(historyModel);
    } catch (_) {
      yield HistoryError();
    }
  }

  // ignore: unused_element
  Stream<HistoryState> _mapTodoDeletedToState(
      HistoryDeleteProcess event) async* {
    try {
      // final result = await this.historyRepository.deleteHistory(historyId: event.id);
      // if (result == true) {
      //   final historyModel = await this.historyRepository.getAllHistory();
      //   yield HistoryLoaded(historyModel);
      //   yield HistoryDeleted("Xóa thành công!");
      // }
    } catch (_) {
      yield HistoryError();
    }
  }

  // ignore: unused_element
  Stream<HistoryState> _mapFoodSuggestionLoadInprocessToState() async* {
    try {
      // final foodSuggestionModel =
      //     await this.foodSuggestionRepository.getAllFoodSuggestion();
      // final byreModel = await this.foodSuggestionRepository.getAllByre();
      // final historyModel = await this.historyRepository.getAllHistory();
      // yield FoodSuggestionLoaded(foodSuggestionModel, byreModel, historyModel);
    } catch (_) {
      yield HistoryError();
    }
  }

  // ignore: unused_element
  Stream<HistoryState> _mapTodoUpdatedToState(HistoryUpdated event) async* {
    // final result = await this
    //     .historyRepository
    //     .updateHistory(event.historyItem.id, historyItem: event.historyItem);
    // if (result == true) {
    //   yield HistoryUpdateResult("Cập nhật thành công");
    // } else {
    //   yield HistoryUpdateResult("Cập nhật thất bại");
    // }
  }

  // Future _saveHistory(HistoryModel history) {
  //   return historyRepository.getAllHistory();
  // }
}
