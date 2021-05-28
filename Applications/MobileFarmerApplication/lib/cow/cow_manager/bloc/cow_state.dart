//part of 'cow_cubit.dart';
part of 'cow_bloc.dart';

abstract class CowState extends Equatable {
  const CowState();

  @override
  List<Object> get props => [];
}

class CowError extends CowState {}

class CowLoadInprocess extends CowState {}

class FoodSuggestionLoadInprocess extends CowState {}

class FoodSuggestionLoaded extends CowState {
  final FoodSuggestionModel foodSuggestionModel;
  final ByreModel byreModel;
  final CowModel listCowMale;
  final CowModel listCowFeMale;

  const FoodSuggestionLoaded(
      {this.foodSuggestionModel, this.byreModel, this.listCowMale, this.listCowFeMale});

  @override
  List<Object> get props => [foodSuggestionModel, byreModel, listCowMale, listCowFeMale];

  @override
  String toString() => 'TodosLoadSuccess { todos: $foodSuggestionModel }';
}

class CowLoaded extends CowState {
  final CowModel cowModel;

  const CowLoaded([this.cowModel]);

  @override
  List<Object> get props => [cowModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $cowModel }';
}

class ByreLoaded extends CowState{
  final ByreModel byreModel;
  
  const ByreLoaded([this.byreModel]);

  @override
  List<Object> get props => [byreModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $byreModel }';
}

class GetCowFatherMotherName extends CowState {
  final CowItem cowItem;

  const GetCowFatherMotherName([this.cowItem]);

  @override
  List<Object> get props => [cowItem];

  @override
  String toString() => 'TodosLoadSuccess { todos: $cowItem }';
}

class CowDeleted extends CowState {
  final String result;

  const CowDeleted([this.result]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Xóa thành công { todos: $result }';
}

class CowUpdateResult extends CowState {
  final String result;

  const CowUpdateResult([this.result]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Cập nhật thành công { todos: $result }';
}

class CowLoading extends CowState {
  const CowLoading();
}

class AddCowDoneLoaded extends CowState {
  const AddCowDoneLoaded();
}

// class CowDeleted extends CowEvent {
//   final String result;

//   const CowDeleted(this.result);

//   @override
//   List<Object> get props => [result];

//   @override
//   String toString() => 'TodoDeleted { todo: $result }';
// }

class GetListCowLoaded extends CowState {
  final CowModel cowModel;
  const GetListCowLoaded(this.cowModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListCowLoaded && o.cowModel == cowModel;
  }

  @override
  int get hashCode => cowModel.hashCode;
}
