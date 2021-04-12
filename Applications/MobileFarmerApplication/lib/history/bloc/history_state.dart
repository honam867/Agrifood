//part of 'history_cubit.dart';
part of 'history_bloc.dart';

abstract class HistoryState extends Equatable {
  const HistoryState();

  @override
  List<Object> get props => [];
}

class HistoryError extends HistoryState {}

class HistoryLoadInprocess extends HistoryState {}

class FoodSuggestionLoadInprocess extends HistoryState {}


class HistoryLoaded extends HistoryState {
  final MilkingSlipDetailModel historyModel;

  const HistoryLoaded([this.historyModel]);

  @override
  List<Object> get props => [historyModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $historyModel }';
}

class HistoryDeleted extends HistoryState {
  final String result;

  const HistoryDeleted([this.result]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Xóa thành công { todos: $result }';
}

class HistoryUpdateResult extends HistoryState {
  final String result;

  const HistoryUpdateResult([this.result]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Cập nhật thành công { todos: $result }';
}

class HistoryLoading extends HistoryState {
  const HistoryLoading();
}

class AddHistoryDoneLoaded extends HistoryState {
  const AddHistoryDoneLoaded();
}

// class HistoryDeleted extends HistoryEvent {
//   final String result;

//   const HistoryDeleted(this.result);

//   @override
//   List<Object> get props => [result];

//   @override
//   String toString() => 'TodoDeleted { todo: $result }';
// }

class GetListHistoryLoaded extends HistoryState {
  final MilkingSlipModel historyModel;
  const GetListHistoryLoaded(this.historyModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListHistoryLoaded && o.historyModel == historyModel;
  }

  @override
  int get hashCode => historyModel.hashCode;
}
