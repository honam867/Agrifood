part of 'history_bloc.dart';

abstract class HistoryEvent extends Equatable {
  const HistoryEvent();

  @override
  List<Object> get props => [];
}

class HistoryLoadedSucces extends HistoryEvent {
  final int day;
  final int month;
  final int year;
  final int session;

  HistoryLoadedSucces({this.day, this.month, this.year, this.session});
  @override
  List<Object> get props => [];
}

class GetHistoryByByreId extends HistoryEvent {
  final int id;
  const GetHistoryByByreId(this.id);
}

class GetHistoryByFarmerId extends HistoryEvent {
  @override
  List<Object> get props => [];
}

class HistoryDeleteProcess extends HistoryEvent {
  final int id;

  const HistoryDeleteProcess(this.id);

  @override
  List<Object> get props => [id];

  @override
  String toString() => 'Đã xóa thành công';
}

class HistoryAdded extends HistoryEvent {
  final MilkingSlipItem historyItem;

  const HistoryAdded(this.historyItem);

  @override
  List<Object> get props => [historyItem];

  @override
  String toString() => 'TodoAdded { todo: $historyItem }';
}

class HistoryUpdated extends HistoryEvent {
  final MilkingSlipItem historyItem;

  const HistoryUpdated(this.historyItem);

  @override
  List<Object> get props => [historyItem];

  @override
  String toString() => 'TodoUpdated { todo: $historyItem }';
}

class ClearCompleted extends HistoryEvent {}

class HistoryNope extends HistoryEvent {}

class ToggleAll extends HistoryEvent {}
