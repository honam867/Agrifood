import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/milkingSlip_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'milkingslip_event.dart';
part 'milkingslip_state.dart';

class MilkingSlipBloc extends Bloc<MilkingSlipEvent, MilkingSlipState> {
  final MilkingSlipRepository milkingSlipRepository;
  final FoodSuggestionRepository foodSuggestionRepository;
  final ByreRepository byreRepository;

  MilkingSlipBloc(
      {this.milkingSlipRepository,
      this.foodSuggestionRepository,
      this.byreRepository})
      : super(MilkingSlipLoadInprocess());

  @override
  Stream<MilkingSlipState> mapEventToState(MilkingSlipEvent event) async* {
    if (event is MilkingSlipLoadedSucces) {
      yield* _mapMilkingSlipLoadedToState();
    } else if (event is MilkingSlipAddProcess) {
      yield* _mapTodoAddedToState(event);
    } else if (event is MilkingSlipDeleteProcess) {
      yield* _mapTodoDeletedToState(event);
    }
  }

  Stream<MilkingSlipState> _mapMilkingSlipLoadedToState() async* {
    try {
      final milkingSlipModel =
          await this.milkingSlipRepository.getAllMilkingSlip();
      yield MilkingSlipLoaded(milkingSlipModel);
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapTodoAddedToState(
      MilkingSlipAddProcess event) async* {
    try {
      final result = await this
          .milkingSlipRepository
          .addMilkingSlip(milkingSlipItem: event.milkingSlipItem);
      if (result == true) {
        final milkingSlipModel =
            await this.milkingSlipRepository.getAllMilkingSlip();
        yield MilkingSlipLoaded(milkingSlipModel);
      }
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapTodoDeletedToState(
      MilkingSlipDeleteProcess event) async* {
    try {
      final result = await this
          .milkingSlipRepository
          .deleteMilkingSlip(milkingSlipId: event.id);
      if (result == true) {
        final milkingSlipModel =
            await this.milkingSlipRepository.getAllMilkingSlip();
        yield MilkingSlipLoaded(milkingSlipModel);
        yield MilkingSlipDeleted("Xóa thành công!");
      }
    } catch (_) {
      yield MilkingSlipError();
    }
  }
}
