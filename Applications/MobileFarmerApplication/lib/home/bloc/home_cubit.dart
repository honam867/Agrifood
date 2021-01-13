import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
part 'home_state.dart';

class HomeCubit extends Cubit<HomeState> {
  HomeCubit() : super(HomeInitial());

  Future<void> clickMenu(Items items) async {
    emit(HomeMenu(items: items));
  }
}
