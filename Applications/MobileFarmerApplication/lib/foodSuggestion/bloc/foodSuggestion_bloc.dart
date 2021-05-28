//import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/feedCow/model/feed_history_detail_item.dart';
import 'package:AgrifoodApp/feedCow/model/feed_history_item.dart';
import 'package:AgrifoodApp/feedCow/model/food_item.dart';
import 'package:AgrifoodApp/feedCow/model/food_model.dart';
//import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

part 'foodSuggestion_event.dart';
part 'foodSuggestion_state.dart';

class FoodSuggestionBloc extends Bloc<FoodEvent, FoodState> {
  final FoodSuggestionRepository foodSuggestionRepository;
  FoodSuggestionBloc({this.foodSuggestionRepository})
      : super(FoodLoadInprocess());
  @override
  Stream<FoodState> mapEventToState(FoodEvent event) async* {
    if (event is FoodLoadedSuccess) {
      yield* _mapfoodLoadedToState(event);
    } else if (event is SendFoodEvent) {
      yield* _mapsendFoodLoadedToState(event);
    }
  }

  Stream<FoodState> _mapsendFoodLoadedToState(SendFoodEvent event) async* {
    try {
      yield SendFoodInprocess();
      final result = await this.foodSuggestionRepository.addFeedHistoryDetail(
          feedHistoryDetailItem: event.feedHistoryDetailItem);
      yield SendFoodLoaded(result == true ? "Thành công" : "Thất bại");
    } catch (_) {
      yield SendFoodLoaded("Kiểm tra lại");
    }
  }

  Stream<FoodState> _mapfoodLoadedToState(FoodLoadedSuccess event) async* {
    try {
      FeedHistoryItem feedHistoryItem = new FeedHistoryItem(cowId: event.cowId);
      final int feedHistoryMasterId = await this
          .foodSuggestionRepository
          .addFeedHistoryMaster(feedHistoryItem: feedHistoryItem);
      final foodModel =
          await this.foodSuggestionRepository.getAllFood();
      List<FoodItem> listThoTemp = new List<FoodItem>();
      List<FoodItem> listTinhTemp = new List<FoodItem>();
      List<FoodItem> listTho = new List<FoodItem>();
      List<FoodItem> listTinh = new List<FoodItem>();

      foodModel.foodItem.forEach((item) {
        if (item.type.contains("Thô") || item.type.contains("Kho")) {
          listThoTemp.add(item);
        } else if (item.type.contains("Tinh")) {
          listTinhTemp.add(item);
        }
      });
      listTho.addAll(listThoTemp);
      listTinh.addAll(listTinhTemp);
      yield FoodLoaded(
          feedHistoryMasterId: feedHistoryMasterId,
          foodModel: foodModel,
          listBoKho: listTho,
          listBoTinh: listTinh);
    } catch (_) {
      yield FoodError();
    }
  }
}
