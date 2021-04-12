import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/milkingslip/bloc/milkingslip_bloc.dart';
import 'package:AgrifoodApp/milkingslip/component/milkingslip_detail_card.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

class MilkingSlipDetailPage extends StatefulWidget {
  final String value;
  final int milkingSlipId;
  MilkingSlipDetailPage({this.value, this.milkingSlipId});

  @override
  _MilkingSlipDetailPageState createState() => _MilkingSlipDetailPageState();
}

class _MilkingSlipDetailPageState extends State<MilkingSlipDetailPage> {
  List<BlocProvider<MilkingSlipBloc>> listReport = new List<BlocProvider<MilkingSlipBloc>>();
  TextEditingController nameController = TextEditingController();

  void addItemToList({CowModel cowModel, int mikingSlipId}) {
    setState(() {
      listReport.insert(
        0,
        BlocProvider(
            create: (BuildContext context) =>
                MilkingSlipBloc()..add(OnPressAddItemMilkingSlipEvent(widget.milkingSlipId)),
            child: MilkingSlipDetailCard(
              milkingSlipId: widget.milkingSlipId,
              deleteFunction: deleteItemToList,
            )),
      );
    });
  }

  void deleteItemToList() {
    setState(() {
      listReport.removeAt(0);
    });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
          appBar: AppBar(
            backgroundColor: colorApp,
            title: Text('Tạo báo cáo'),
            leading: IconButton(
              icon: Icon(Icons.navigate_before),
              onPressed: () {
                Navigator.pop(context);
                Navigator.pop(context);
              },
            ),
            actions: [
              IconButton(
                  icon: Icon(Icons.add),
                  onPressed: () {
                    addItemToList();
                  })
            ],
          ),
          body: Column(
            children: <Widget>[
              Expanded(
                  child: Padding(
                padding: EdgeInsets.only(top: ScreenUtil().setHeight(35)),
                child: ListView.builder(
                  itemBuilder: (context, index) {
                    final items = listReport[index];
                    return ListTile(
                      title: items,
                    );
                  },
                  itemCount: listReport.length,
                ),
              )),
            ],
          )),
    );
  }
}
