part of 'foodSuggestion_bloc.dart';


abstract class FoodEvent extends Equatable {
  const FoodEvent();

  @override
  List<Object> get props => [];
}

class FoodLoadedSuccess extends FoodEvent {
  
  @override
  List<Object> get props => [];

  // @override
  // String toString() => 'TodoLoaded { todo: $foodSuggestionItem }';
}