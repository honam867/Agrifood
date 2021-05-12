part of 'cow_bloc.dart';

abstract class CowEvent extends Equatable {
  const CowEvent();

  @override
  List<Object> get props => [];
}

class CowLoadedSucces extends CowEvent {}

class GetCowByByreId extends CowEvent {
  final int id;
  const GetCowByByreId(this.id);
  @override
  List<Object> get props => [];
}

class GetCowByFarmerId extends CowEvent {
  @override
  List<Object> get props => [];
}

class FoodSuggestionSuccess extends CowEvent {
  
  @override
  List<Object> get props => [];
}

class CowAddProcess extends CowEvent {
  final CowItem cowItem;

  const CowAddProcess(this.cowItem);

  @override
  List<Object> get props => [cowItem];

  @override
  String toString() => 'TodoAdded { todo: $cowItem }';
}

class CowDeleteProcess extends CowEvent {
  final int id;

  const CowDeleteProcess(this.id);

  @override
  List<Object> get props => [id];

  @override
  String toString() => 'Đã xóa thành công';
}

class CowAdded extends CowEvent {
  final CowItem cowItem;

  const CowAdded(this.cowItem);

  @override
  List<Object> get props => [cowItem];

  @override
  String toString() => 'TodoAdded { todo: $cowItem }';
}

class CowUpdated extends CowEvent {
  final CowItem cowItem;

  const CowUpdated(this.cowItem);

  @override
  List<Object> get props => [cowItem];

  @override
  String toString() => 'TodoUpdated { todo: $cowItem }';
}

class ClearCompleted extends CowEvent {}

class CowNope extends CowEvent {}

class ToggleAll extends CowEvent {}
