part of 'foodSuggestion_bloc.dart';

abstract class FoodState extends Equatable {
  const FoodState();

  @override
  List<Object> get props => [];
}

class FoodError extends FoodState {}

class FoodLoadInprocess extends FoodState {}

class FoodLoaded extends FoodState {
  final FoodSuggestionModel foodSuggestionModel;

  const FoodLoaded([this.foodSuggestionModel]);

  @override
  List<Object> get props => [foodSuggestionModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $foodSuggestionModel }';
}