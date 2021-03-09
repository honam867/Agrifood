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

  const FoodSuggestionLoaded([this.foodSuggestionModel ]);

  @override
  List<Object> get props => [foodSuggestionModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $foodSuggestionModel }';
}

class CowLoaded extends CowState {
  final CowModel cowModel;

  const CowLoaded([this.cowModel ]);

  @override
  List<Object> get props => [cowModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $cowModel }';
}

class CowDeleted extends CowState {
  final String result;

  const CowDeleted([this.result ]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Xóa thành công { todos: $result }';
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



