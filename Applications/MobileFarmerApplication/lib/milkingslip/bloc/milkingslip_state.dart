//part of 'cow_cubit.dart';
part of 'milkingslip_bloc.dart';

abstract class MilkingSlipState extends Equatable {
  const MilkingSlipState();

  @override
  List<Object> get props => [];
}

class MilkingSlipError extends MilkingSlipState {}

class MilkingSlipLoadInprocess extends MilkingSlipState {}

class MilkingSlipLoading extends MilkingSlipState {
  @override
  List<Object> get props => [];
}

class MilkingSlipLoaded extends MilkingSlipState {
  final MilkingSlipModel cowModel;

  const MilkingSlipLoaded([this.cowModel]);

  @override
  List<Object> get props => [cowModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $cowModel }';
}

class MilkingSlipDetailLoadedState extends MilkingSlipState {
  final CowModel cowModel;

  const MilkingSlipDetailLoadedState([this.cowModel]);

  @override
  List<Object> get props => [cowModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $cowModel }';
}

class OnPressAddItemMilkingSlipState extends MilkingSlipState {
  final CowModel cowModel;

  const OnPressAddItemMilkingSlipState([this.cowModel]);

  @override
  List<Object> get props => [cowModel];

  @override
  String toString() => 'TodosLoadSuccess { todos: $cowModel }';
}

class MilkingSlipDeleted extends MilkingSlipState {
  final String result;

  const MilkingSlipDeleted([this.result]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Xóa thành công { todos: $result }';
}

class MilkingSlipUpdateResult extends MilkingSlipState {
  final String result;

  const MilkingSlipUpdateResult([this.result]);

  @override
  List<Object> get props => [result];

  @override
  String toString() => 'Cập nhật thành công { todos: $result }';
}

class AddMilkingSlipDoneLoaded extends MilkingSlipState {
  final int milkingSlipId;
  const AddMilkingSlipDoneLoaded({this.milkingSlipId});
}

class CreateMilkingSlipDetailDone extends MilkingSlipState {
  final int milkingdetailId;
  const CreateMilkingSlipDetailDone({this.milkingdetailId});
}

class UpdateMilkingSlipDetailDone extends MilkingSlipState {
  final bool result;
  const UpdateMilkingSlipDetailDone({this.result});
}

// class MilkingSlipDeleted extends MilkingSlipEvent {
//   final String result;

//   const MilkingSlipDeleted(this.result);

//   @override
//   List<Object> get props => [result];

//   @override
//   String toString() => 'TodoDeleted { todo: $result }';
// }

class GetListMilkingSlipLoaded extends MilkingSlipState {
  final MilkingSlipModel cowModel;
  const GetListMilkingSlipLoaded(this.cowModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListMilkingSlipLoaded && o.cowModel == cowModel;
  }

  @override
  int get hashCode => cowModel.hashCode;
}
