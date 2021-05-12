part of 'foodSuggestion_bloc.dart';

abstract class FoodEvent extends Equatable {
  const FoodEvent();

  @override
  List<Object> get props => [];
}

class FoodLoadedSuccess extends FoodEvent {
  final int cowId;

  FoodLoadedSuccess(this.cowId);
  @override
  List<Object> get props => [];

  // @override
  // String toString() => 'TodoLoaded { todo: $foodSuggestionItem }';
}

class SendFoodEvent extends FoodEvent {
  final FeedHistoryDetailItem feedHistoryDetailItem;

  SendFoodEvent(this.feedHistoryDetailItem);
  @override
  List<Object> get props => [];

  // @override
  // String toString() => 'TodoLoaded { todo: $foodSuggestionItem }';
}
