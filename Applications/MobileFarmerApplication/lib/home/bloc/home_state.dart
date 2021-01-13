part of 'home_cubit.dart';

abstract class HomeState {
  const HomeState();
}

class HomeInitial extends HomeState {
  const HomeInitial();
}

class HomeLoading extends HomeState {
  const HomeLoading();
}

class HomeMenu extends HomeState{
  final Items items;
  const HomeMenu({this.items});

  @override
  bool operator == (Object o) {
    if (identical(this, o)) return true;

    return o is HomeMenu && o.items.title == items.title;
  }

  @override
  int get hashCode => items.hashCode;

}