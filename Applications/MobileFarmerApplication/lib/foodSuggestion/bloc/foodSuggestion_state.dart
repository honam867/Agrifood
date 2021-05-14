part of 'foodSuggestion_bloc.dart';

abstract class FoodState extends Equatable {
  const FoodState();

  @override
  List<Object> get props => [];
}

class FoodError extends FoodState {}

class FoodLoadInprocess extends FoodState {}

class SendFoodInprocess extends FoodState {}

class SendFoodLoaded extends FoodState {
  final String result;

  SendFoodLoaded(this.result);

  @override
  String toString() => 'Kết quả { todos: $result }';
}

class FoodLoaded extends FoodState {
  final FoodModel foodModel;
  final int feedHistoryMasterId;
  final List<FoodItem> listBoKho;
  final List<FoodItem> listBoTinh;
  const FoodLoaded(
      {this.feedHistoryMasterId,
      this.foodModel,
      this.listBoKho,
      this.listBoTinh});

  @override
  List<Object> get props => [foodModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $foodModel }';
}
