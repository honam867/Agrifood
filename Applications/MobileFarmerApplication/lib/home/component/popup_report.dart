import 'package:AgrifoodApp/milkingslip/bloc/milkingslip_bloc.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';
import 'package:AgrifoodApp/milkingslip/page/milkingslipd_detail_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class PopupReport extends StatelessWidget {
  final farmerId;

  const PopupReport({Key key, this.farmerId}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Dialog(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
        elevation: 0,
        backgroundColor: Colors.transparent,
        child: BlocConsumer<MilkingSlipBloc, MilkingSlipState>(
          listener: (context, state) {
            if (state is AddMilkingSlipDoneLoaded) {
              Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => MilkingSlipDetailPage(
                            milkingSlipId: state.milkingSlipId,
                          )));
            }
          },
          builder: (context, state) {
            if (state is MilkingSlipLoading) {
              return const CircularProgressIndicator();
            }
            if (state is MilkingSlipLoaded) {
              return _buildChild(context);
            }
            return const Text('Something went wrong!');
          },
        ));
  }

  _buildChild(BuildContext context) {
    TextEditingController codeController = new TextEditingController();
    return Container(
      height: 350,
      decoration: BoxDecoration(
          color: colorApp,
          shape: BoxShape.rectangle,
          borderRadius: BorderRadius.all(Radius.circular(12))),
      child: Column(
        children: <Widget>[
          Container(
            child: Padding(
              padding: const EdgeInsets.all(12.0),
              child: Image.asset(
                'assets/layout/farmer.png',
                height: 120,
                width: 120,
              ),
            ),
            width: double.infinity,
            decoration: BoxDecoration(
                color: Colors.white,
                shape: BoxShape.rectangle,
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(12),
                    topRight: Radius.circular(12))),
          ),
          SizedBox(
            height: 24,
          ),
          Text(
            'Bạn đang vắt buổi?',
            style: TextStyle(
                fontSize: 20, color: Colors.white, fontWeight: FontWeight.bold),
          ),
          SizedBox(
            height: 8,
          ),
          Padding(
            padding: const EdgeInsets.only(right: 16, left: 16),
            child: Text(
              'Vui lòng chọn thông tin chính xác.',
              style: TextStyle(color: Colors.white),
              textAlign: TextAlign.center,
            ),
          ),
          SizedBox(
            height: 24,
          ),
          TextField(
            controller: codeController,
          ),
          Row(
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              FlatButton(
                onPressed: () {
                  MilkingSlipItem item = new MilkingSlipItem(
                    code: "NHU",
                    session: "Chiều",
                    farmerId: farmerId,
                  );
                  BlocProvider.of<MilkingSlipBloc>(context)
                      .add(MilkingSlipAddProcess(item));
                },
                child: Text('Chiều'),
                textColor: Colors.white,
              ),
              SizedBox(
                width: 8,
              ),
              RaisedButton(
                onPressed: () {
                  MilkingSlipItem item = new MilkingSlipItem(
                    code: codeController.text,
                    session: "Sáng",
                    farmerId: farmerId,
                  );
                  BlocProvider.of<MilkingSlipBloc>(context)
                      .add(MilkingSlipAddProcess(item));
                },
                child: Text('Sáng'),
                color: Colors.white,
                textColor: colorApp,
              )
            ],
          )
        ],
      ),
    );
  }
}
