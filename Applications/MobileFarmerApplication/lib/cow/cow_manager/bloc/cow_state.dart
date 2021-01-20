part of 'cow_cubit.dart';


abstract class CowState {
  const CowState();
}

class CowInitial extends CowState {
  const CowInitial();
}

class Result extends CowState {
  final String message;
  const Result(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is CowError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}

class CowLoading extends CowState {
  const CowLoading();
}

class GetListCow extends CowState {
  final CowModel cowModel;
  const GetListCow(this.cowModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is GetListCow && o.cowModel == cowModel;
  }

  @override
  int get hashCode => cowModel.hashCode;
}

class CowLoaded extends CowState {
  final CowModel cowModel;
  const CowLoaded(this.cowModel);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is CowLoaded && o.cowModel == cowModel;
  }

  @override
  int get hashCode => cowModel.hashCode;
}

class CowError extends CowState {
  final String message;
  const CowError(this.message);

  @override
  bool operator ==(Object o) {
    if (identical(this, o)) return true;

    return o is CowError && o.message == message;
  }

  @override
  int get hashCode => message.hashCode;
}
