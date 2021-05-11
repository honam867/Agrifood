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
  final List<FoodSuggestionItem> listBoKho;
  final List<FoodSuggestionItem> listBoTinh;
  const FoodLoaded({this.foodSuggestionModel, this.listBoKho, this.listBoTinh});

  @override
  List<Object> get props => [foodSuggestionModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $foodSuggestionModel }';
}