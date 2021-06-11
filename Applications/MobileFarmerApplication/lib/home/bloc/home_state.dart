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

class CheckByreLoaded extends HomeState {
  final int amonth;
  final int cowLength;
  const CheckByreLoaded(this.amonth, this.cowLength);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is CheckByreLoaded && o.amonth == amonth;
  }

  @override
  int get hashCode => amonth.hashCode;
}

class GetListCowLoaded extends HomeState {
  final CowModel cowModel;
  const GetListCowLoaded(this.cowModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListCowLoaded && o.cowModel == cowModel;
  }

  @override
  int get hashCode => cowModel.hashCode;
}

class CheckFarmer extends HomeState {
  final String message;
  const CheckFarmer(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is CheckFarmer && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}

class HomeMenu extends HomeState {
  final Items items;
  const HomeMenu({this.items});

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is HomeMenu && o.items.title == items.title;
  }

  @override
  int get hashCode => items.hashCode;
}

class ResultHome extends HomeState {
  final String message;
  const ResultHome(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is NotiError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}

class NotiError extends HomeState {
  final String message;
  const NotiError(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is NotiError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}
