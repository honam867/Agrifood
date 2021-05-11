import 'package:AgrifoodApp/core/storage.dart';
import 'package:AgrifoodApp/home/component/popup_report.dart';
import 'package:AgrifoodApp/milkingslip/bloc/milkingslip_bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

class FloatingButtonMiking extends StatefulWidget {
  @override
  _FloatingButtonMikingState createState() => _FloatingButtonMikingState();
}

class _FloatingButtonMikingState extends State<FloatingButtonMiking> {
  int farmerId;

  @override
  void initState() {
    super.initState();
    getFarmerId();
  }

  void getFarmerId() async {
    farmerId = int.parse(await Storage.getString('farmerId'));
  }

  @override
  Widget build(BuildContext context) {
    return FloatingActionButton.extended(
        label: const Text('Tạo'),
        icon: const Icon(Icons.add),
        onPressed: () {
          showDialog(
            context: context,
            builder:(context) =>  BlocProvider<MilkingSlipBloc>(
              create: (_) => MilkingSlipBloc()..add(MilkingSlipLoadedSucces()),
              child: PopupReport(
                farmerId: farmerId,
              ),
            ),
          );
        });
  }
}
