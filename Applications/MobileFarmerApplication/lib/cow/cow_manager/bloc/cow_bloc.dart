import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_model.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'cow_event.dart';
part 'cow_state.dart';

class CowBloc extends Bloc<CowEvent, CowState> {
  final CowRepository cowRepository;
  final FoodSuggestionRepository foodSuggestionRepository;

  CowBloc({this.cowRepository, this.foodSuggestionRepository})
      : super(CowLoadInprocess());

  @override
  Stream<CowState> mapEventToState(CowEvent event) async* {
    if (event is CowLoadedSucces) {
      yield* _mapCowLoadedToState();
    } else if (event is CowAddProcess) {
      yield* _mapTodoAddedToState(event);
    } else if (event is CowUpdated) {
      yield* _mapTodoUpdatedToState(event);
    } else if (event is CowDeleteProcess) {
      yield* _mapTodoDeletedToState(event);
    } else if (event is FoodSuggestionSuccess) {
      yield* _mapFoodSuggestionLoadInprocessToState();
    } else if (event is ClearCompleted) {
      //yield* _mapClearCompletedToState();
    }
  }

  Stream<CowState> _mapCowLoadedToState() async* {
    try {
      final cowModel = await this.cowRepository.getAllCow();
      yield CowLoaded(cowModel);
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapTodoAddedToState(CowAddProcess event) async* {
    try {
      final result = await this.cowRepository.addCow(cowItem: event.cowItem);
      if (result == true) {
        final cowModel = await this.cowRepository.getAllCow();
        yield CowLoaded(cowModel);
      }
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapTodoDeletedToState(CowDeleteProcess event) async* {
    try {
      final result = await this.cowRepository.deleteCow(cowId: event.id);
      if (result == true) {
        final cowModel = await this.cowRepository.getAllCow();
        yield CowLoaded(cowModel);
        yield CowDeleted("Xóa thành công!");
      }
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapFoodSuggestionLoadInprocessToState() async* {
    try {
      final foodSuggestionModel =
          await this.foodSuggestionRepository.getAllFoodSuggestion();
      yield FoodSuggestionLoaded(foodSuggestionModel);
    } catch (_) {
      yield CowError();
    }
  }

  Stream<CowState> _mapTodoUpdatedToState(CowUpdated event) async* {
    // if (state is CowLoaded) {
    //   // final CowModel updatedTodos = (state as TodosLoadSuccess).todos.map((todo) {
    //     return todo.id == event.updatedTodo.id ? event.updatedTodo : todo;
    //   }).toList();
    //   yield TodosLoadSuccess(updatedTodos);
    //   _saveTodos(updatedTodos);
    // }
  }

  Future _saveCow(CowModel cow) {
    return cowRepository.getAllCow();
  }
}
