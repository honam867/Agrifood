part of 'milkingslip_bloc.dart';

abstract class MilkingSlipEvent extends Equatable {
  const MilkingSlipEvent();

  @override
  List<Object> get props => [];
}

class MilkingSlipLoadedSucces extends MilkingSlipEvent {}

class FoodSuggestionSuccess extends MilkingSlipEvent {}

class MilkingSlipAddProcess extends MilkingSlipEvent {
  final MilkingSlipItem milkingSlipItem;

  const MilkingSlipAddProcess(this.milkingSlipItem);

  @override
  List<Object> get props => [milkingSlipItem];

  @override
  String toString() => 'TodoAdded { todo: $milkingSlipItem }';
}

class MilkingSlipDeleteProcess extends MilkingSlipEvent {

  final int id;

  const MilkingSlipDeleteProcess( this.id);

  @override
  List<Object> get props => [id];

  @override
  String toString() => 'Đã xóa thành công';
}

class MilkingSlipAdded extends MilkingSlipEvent {
  final MilkingSlipItem milkingSlipItem;

  const MilkingSlipAdded(this.milkingSlipItem);

  @override
  List<Object> get props => [milkingSlipItem];

  @override
  String toString() => 'TodoAdded { todo: $milkingSlipItem }';
}

class MilkingSlipUpdated extends MilkingSlipEvent {
  final MilkingSlipItem milkingSlipItem;

  const MilkingSlipUpdated(this.milkingSlipItem);

  @override
  List<Object> get props => [milkingSlipItem];

  @override
  String toString() => 'TodoUpdated { todo: $milkingSlipItem }';
}


class ClearCompleted extends MilkingSlipEvent {}

class MilkingSlipNope extends MilkingSlipEvent {}

class ToggleAll extends MilkingSlipEvent {}