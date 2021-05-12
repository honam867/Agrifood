//import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_model.dart';

part 'foodSuggestion_event.dart';
part 'foodSuggestion_state.dart';

class FoodSuggestionBloc extends Bloc<FoodEvent, FoodState> {
  final FoodSuggestionRepository foodSuggestionRepository;
  FoodSuggestionBloc({this.foodSuggestionRepository})
      : super(FoodLoadInprocess());
  @override
  Stream<FoodState> mapEventToState(FoodEvent event) async* {
    if (event is FoodLoadedSuccess) {
      yield* _mapfoodLoadedToState();
    }
  }

  Stream<FoodState> _mapfoodLoadedToState() async* {
    try {
      final foodSuggestionModel =
          await this.foodSuggestionRepository.getAllFoodSuggestion();
      List<FoodSuggestionItem> listThoTemp = new List<FoodSuggestionItem>();
      List<FoodSuggestionItem> listTinhTemp = new List<FoodSuggestionItem>();
      List<FoodSuggestionItem> listTho = new List<FoodSuggestionItem>();
      List<FoodSuggestionItem> listTinh = new List<FoodSuggestionItem>();

      foodSuggestionModel.foodSuggestionItem.forEach((item) {
        if (item.type.contains("Thô")) {
          listThoTemp.add(item);
        } else if (item.type.contains("Tinh")) {
          listTinhTemp.add(item);
        }
      });
      listTho.addAll(listThoTemp);
      listTinh.addAll(listTinhTemp);
      yield FoodLoaded(
          foodSuggestionModel: foodSuggestionModel,
          listBoTho: listTho,
          listBoTinh: listTinh);
    } catch (_) {
      yield FoodError();
    }
  }
}
