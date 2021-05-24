import 'package:AgrifoodApp/milkingslip/bloc/milkingslip_bloc.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';
import 'package:AgrifoodApp/milkingslip/page/milkingslipd_detail_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class PopupReport extends StatelessWidget {
  final farmerId;
  final routeName;
  final DateTime currentDay;

  const PopupReport({Key key, this.farmerId, this.routeName, this.currentDay}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Dialog(
        shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(ScreenUtil().setSp(100.0))),
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
            } else if (state is GetmilkingSlipDoneLoaded) {
              Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => MilkingSlipDetailPage(
                            milkingSlipId: state.milkingSlipId,
                          )));
            } else if (state is FullReportCowState) {
              showToast(string: state.toast, context: context);
              Navigator.pop(context);
            }
          },
          builder: (context, state) {
            if (state is MilkingSlipLoading) {
              return const CircularProgressIndicator();
            }
            if (state is MilkingSlipLoaded) {
              return _buildChild(context);
            }
            return Center(
              child: CircularProgressIndicator(),
            );
          },
        ));
  }

  _buildChild(BuildContext context) {
    TextEditingController codeController = new TextEditingController();
    return Container(
      height: ScreenUtil().setHeight(1400.0),
      decoration: BoxDecoration(
          color: colorApp,
          shape: BoxShape.rectangle,
          borderRadius:
              BorderRadius.all(Radius.circular(ScreenUtil().setSp(40.0)))),
      child: Column(
        children: <Widget>[
          Container(
            child: Padding(
              padding: EdgeInsets.all(ScreenUtil().setSp(40.0)),
              child: Image.asset(
                'assets/layout/farmer.png',
                height: ScreenUtil().setHeight(400.0),
                width: ScreenUtil().setWidth(400.0),
              ),
            ),
            width: double.infinity,
            decoration: BoxDecoration(
                color: Colors.white,
                shape: BoxShape.rectangle,
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(ScreenUtil().setSp(40.0)),
                    topRight: Radius.circular(ScreenUtil().setSp(40.0)))),
          ),
          SizedBox(height: ScreenUtil().setHeight(150.0)),
          Text(
            'Bạn đang vắt buổi?',
            style: TextStyle(
                fontSize: ScreenUtil().setSp(80.0),
                color: Colors.white,
                fontWeight: FontWeight.bold),
          ),
          SizedBox(
            height: 8,
          ),
          Padding(
            padding: EdgeInsets.only(
                right: ScreenUtil().setWidth(16.0),
                left: ScreenUtil().setWidth(16.0)),
            child: Text(
              'Vui lòng chọn thông tin chính xác.',
              style: TextStyle(color: Colors.white),
              textAlign: TextAlign.center,
            ),
          ),
          SizedBox(height: ScreenUtil().setHeight(70)),
           TextField(
            enabled: false,
            controller: codeController,
          ),
          SizedBox(height: ScreenUtil().setHeight(110)),
          Row(
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              FlatButton(
                onPressed: () {
                  MilkingSlipItem item = new MilkingSlipItem(
                    session: "Chiều",
                    farmerId: farmerId,
                  );
                  BlocProvider.of<MilkingSlipBloc>(context)
                      .add(MilkingSlipAddProcess(item, routeName == "History" ? currentDay : DateTime.now()));
                },
                child: Text('Chiều'),
                textColor: Colors.white,
              ),
              SizedBox(width: ScreenUtil().setWidth(100.0)),
              RaisedButton(
                onPressed: () {
                  MilkingSlipItem item = new MilkingSlipItem(
                    code: codeController.text,
                    session: "Sáng",
                    farmerId: farmerId,
                  );
                  BlocProvider.of<MilkingSlipBloc>(context)
                      .add(MilkingSlipAddProcess(item, routeName == "History" ? currentDay : DateTime.now()));
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
