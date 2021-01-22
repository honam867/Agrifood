part of 'byre_cubit.dart';

abstract class ByreState {
  const ByreState();
}

class ByreInitial extends ByreState {
  const ByreInitial();
}

class AddByreResult extends ByreState {
  final String message;
  const AddByreResult(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is ByreError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}

class Result extends ByreState {
  final String message;
  const Result(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is ByreError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}

class ByreLoading extends ByreState {
  const ByreLoading();
}

class GetListByre extends ByreState {
  final ByreModel byreModel;
  const GetListByre(this.byreModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListByre && o.byreModel == byreModel;
  }

  @override
  int get hashCode => byreModel.hashCode;
}

class ByreLoaded extends ByreState {
  final int amonth;
  const ByreLoaded(this.amonth);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is ByreLoaded && o.amonth == amonth;
  }

  @override
  int get hashCode => amonth.hashCode;
}

class ByreError extends ByreState {
  final String message;
  const ByreError(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is ByreError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}
