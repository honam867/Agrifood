part of 'foodSuggestion_bloc.dart';


abstract class FoodEvent extends Equatable {
  const FoodEvent();

  @override
  List<Object> get props => [];
}

class FoodLoadedSuccess extends FoodEvent {
  final FoodSuggestionItem foodSuggestionItem;

  const FoodLoadedSuccess(this.foodSuggestionItem);

  @override
  List<Object> get props => [foodSuggestionItem];

  @override
  String toString() => 'TodoLoaded { todo: $foodSuggestionItem }';
}