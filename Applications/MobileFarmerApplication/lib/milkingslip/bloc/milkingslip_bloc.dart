import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_model.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/respository/milkingslip_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'milkingslip_event.dart';
part 'milkingslip_state.dart';

class MilkingSlipBloc extends Bloc<MilkingSlipEvent, MilkingSlipState> {
  final FoodSuggestionRepository foodSuggestionRepository;

  MilkingSlipBloc({this.foodSuggestionRepository})
      : super(MilkingSlipLoading());

  @override
  Stream<MilkingSlipState> mapEventToState(MilkingSlipEvent event) async* {
    if (event is MilkingSlipLoadedSucces) {
      yield* _mapMilkingSlipLoadedToState();
    } else if (event is MilkingSlipAddProcess) {
      yield* _mapTodoAddedToState(event);
    } else if (event is MilkingSlipDeleteProcess) {
      yield* _mapTodoDeletedToState(event);
    } else if (event is CreateMilkingSlipDetail) {
      yield* _mapToCreateMilkingSlipDetaillState(event);
    } else if (event is MilkingSlipDetailoading) {
      yield* _mapMilkingSlipDetailLoadedToState();
    } else if (event is OnPressAddItemMilkingSlipEvent) {
      yield* _mapOnPressAddItemMilkingSlipEvent();
    } else if (event is MilkingSlipDetailUpdated) {
      yield* _mapTodoUpdatedToState(event);
    }
  }

  Stream<MilkingSlipState> _mapOnPressAddItemMilkingSlipEvent() async* {
    try {
      CowRepository cowRepository = new CowRepository();
      final cowModel = await cowRepository.getAllCow();
      yield OnPressAddItemMilkingSlipState(cowModel);
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapMilkingSlipDetailLoadedToState() async* {
    try {
      CowRepository cowRepository = new CowRepository();
      final cowModel = await cowRepository.getAllCow();
      yield MilkingSlipDetailLoadedState(cowModel);
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapMilkingSlipLoadedToState() async* {
    yield MilkingSlipLoading();
    try {
      // final milkingSlipModel =
      //     await this.milkingSlipRepository.getAllMilkingSlip();
      yield MilkingSlipLoaded();
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapTodoAddedToState(
      MilkingSlipAddProcess event) async* {
    final MilkingSlipRepository milkingSlipRepository =
        new MilkingSlipRepository();
    try {
      var result = await milkingSlipRepository.addMilkingSlip(
          milkingSlipItem: event.milkingSlipItem);
      if (result != "0") {
        yield AddMilkingSlipDoneLoaded(milkingSlipId: int.parse(result));
      }
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapToCreateMilkingSlipDetaillState(
      CreateMilkingSlipDetail event) async* {
    final MilkingSlipRepository milkingSlipRepository =
        new MilkingSlipRepository();
    try {
      var result = await milkingSlipRepository.addMilkingSlipDetail(
          milkingSlipDetailItem: event.milkingSlipDetailItem);
      if (result != 0) {
        yield CreateMilkingSlipDetailDone(milkingdetailId: result);
      }
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapTodoDeletedToState(
      MilkingSlipDeleteProcess event) async* {
    try {
      final MilkingSlipRepository milkingSlipRepository =
          new MilkingSlipRepository();
      final result = await milkingSlipRepository.deleteMilkingSlip(
          milkingSlipId: event.id);
      if (result == true) {
        final milkingSlipModel =
            await milkingSlipRepository.getAllMilkingSlip();
        yield MilkingSlipLoaded(milkingSlipModel);
        yield MilkingSlipDeleted("Xóa thành công!");
      }
    } catch (_) {
      yield MilkingSlipError();
    }
  }

  Stream<MilkingSlipState> _mapTodoUpdatedToState(
      MilkingSlipDetailUpdated event) async* {
    try {
      final MilkingSlipRepository milkingSlipRepository =
          new MilkingSlipRepository();
      final result = await milkingSlipRepository.updateMilkingSlipDetail(
          event.milkingSlipDetailItem.id,
          milkingSlipDetailItem: event.milkingSlipDetailItem);
      if (result == true) {
       yield UpdateMilkingSlipDetailDone(result: result);
      }
    } catch (_) {
      yield MilkingSlipError();
    }
  }
}
