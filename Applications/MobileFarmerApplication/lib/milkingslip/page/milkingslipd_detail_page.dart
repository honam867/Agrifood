import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/milkingslip/bloc/milkingslip_bloc.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';
import 'package:AgrifoodApp/milkingslip/component/select_drop_list.dart';
import 'package:AgrifoodApp/milkingslip/model/drop_list_model.dart';

class MilkingSlipDetailPage extends StatefulWidget {
  final String value;
  final int milkingSlipId;
  MilkingSlipDetailPage({this.value, this.milkingSlipId});

  @override
  _MilkingSlipDetailPageState createState() => _MilkingSlipDetailPageState();
}

class _MilkingSlipDetailPageState extends State<MilkingSlipDetailPage> {
  List<BlocProvider<MilkingSlipBloc>> listReport =
      new List<BlocProvider<MilkingSlipBloc>>();
  TextEditingController nameController = TextEditingController();

  void addItemToList({CowModel cowModel, int mikingSlipId}) {
    setState(() {
      listReport.insert(
        0,
        BlocProvider(
            create: (BuildContext context) =>
                MilkingSlipBloc()..add(OnPressAddItemMilkingSlipEvent()),
            child: MilkingSlipDetailCard(
              milkingSlipId: widget.milkingSlipId,
            )),
      );
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
              },
            ),
            actions: [
              IconButton(
                  icon: Icon(Icons.add),
                  onPressed: () {
                    // BlocProvider.of<MilkingSlipBloc>(context, listen: true)
                    //   ..add(OnPressAddItemMilkingSlipEvent());
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

class MilkingSlipDetailCard extends StatefulWidget {
  final int milkingSlipId;

  const MilkingSlipDetailCard({Key key, this.milkingSlipId}) : super(key: key);
  @override
  _MilkingSlipDetailCardState createState() => _MilkingSlipDetailCardState();
}

class _MilkingSlipDetailCardState extends State<MilkingSlipDetailCard> {
  TextEditingController nameController = TextEditingController();
  TextEditingController noteController = TextEditingController();
  TextEditingController quantiTyController = TextEditingController();
  int cowId;
  bool sended = false, minimze = false;
  String status = "Đang tải", cowName = "";

  // DropListModel dropListModel = DropListModel([
  //   OptionItem(id: "1", title: "Option 1"),
  //   OptionItem(id: "2", title: "Option 2")
  // ]);
  CowItem optionItemSelected = CowItem(id: null, name: "Chọn bò");

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<MilkingSlipBloc, MilkingSlipState>(
        builder: (context, state) {
      if (state is MilkingSlipLoading) {
        return Card(
            child: Center(
          child: CircularProgressIndicator(),
        ));
      }
      // if (state is CreateMilkingSlipDetailDone) {
      //   return Card(
      //       child: Center(
      //     child: CircularProgressIndicator(),
      //   ));
      // }
      if (state is OnPressAddItemMilkingSlipState) {
        DropListModel dropListModel = DropListModel(state.cowModel.cowItem);
        return Stack(
          children: [
            minimze == false
                ? Card(
                    child: Column(
                      children: [
                        Padding(
                            padding: EdgeInsets.all(5),
                            child: Row(
                              crossAxisAlignment: CrossAxisAlignment.center,
                              children: [
                                Text(
                                  "Số lượng:",
                                  style: TextStyles.labelTextStyle,
                                ),
                                SizedBox(
                                  width: 10,
                                ),
                                Container(
                                  height: 50,
                                  width:
                                      MediaQuery.of(context).size.width - 150,
                                  child: TextField(
                                    controller: quantiTyController,
                                    keyboardType: TextInputType.phone,
                                  ),
                                )
                              ],
                            )),
                        Padding(
                          padding: EdgeInsets.only(
                              top: 5, bottom: 5, left: 10, right: 10),
                          child: Container(
                            width: MediaQuery.of(context).size.width,
                            child: SelectDropList(
                              this.optionItemSelected,
                              dropListModel,
                              (optionItem) {
                                optionItemSelected = optionItem;
                                setState(() {
                                  cowId = int.parse(optionItem.id.toString());
                                  cowName = optionItem.name;
                                  print(cowId);
                                });
                              },
                            ),
                          ),
                        ),
                        Padding(
                            padding: EdgeInsets.all(5),
                            child: Row(
                              crossAxisAlignment: CrossAxisAlignment.center,
                              children: [
                                Text(
                                  "Ghi chú:",
                                  style: TextStyles.labelTextStyle,
                                ),
                                SizedBox(
                                  width: 10,
                                ),
                                Container(
                                  height: 50,
                                  width:
                                      MediaQuery.of(context).size.width - 150,
                                  child: TextField(
                                    controller: noteController,
                                    keyboardType: TextInputType.multiline,
                                  ),
                                )
                              ],
                            )),
                        Divider(),
                        Row(
                          crossAxisAlignment: CrossAxisAlignment.center,
                          mainAxisAlignment: MainAxisAlignment.spaceAround,
                          children: [
                            FlatButton(
                                onPressed: () {},
                                child: Row(
                                  crossAxisAlignment: CrossAxisAlignment.center,
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    Icon(
                                      Icons.delete,
                                      color: Colors.redAccent,
                                    ),
                                    Text(
                                      "Xóa",
                                      style: TextStyle(color: Colors.redAccent),
                                    )
                                  ],
                                )),
                            FlatButton(
                                onPressed: sended == false
                                    ? () {
                                        setState(() {
                                          //sended = true;
                                          MilkingSlipDetailItem
                                              milkingSlipDetailItem =
                                              new MilkingSlipDetailItem(
                                                  cowId: cowId,
                                                  milkingSlipId:
                                                      widget.milkingSlipId,
                                                  note: noteController.text,
                                                  quantity: int.parse(
                                                      quantiTyController.text));
                                          print(milkingSlipDetailItem);
                                          BlocProvider.of<MilkingSlipBloc>(
                                              context)
                                            ..add(CreateMilkingSlipDetail(
                                                milkingSlipDetailItem));
                                        });
                                      }
                                    : null,
                                child: Row(
                                  crossAxisAlignment: CrossAxisAlignment.center,
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    Icon(
                                      Icons.send,
                                      color: sended == false
                                          ? Colors.yellowAccent
                                          : Colors.grey,
                                    ),
                                    Text(
                                      "Gửi",
                                      style: TextStyle(
                                          color: sended == false
                                              ? Colors.yellowAccent
                                              : Colors.grey),
                                    )
                                  ],
                                )),
                          ],
                        )
                      ],
                    ),
                  )
                : Card(
                    child: Padding(
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          children: [
                            Text(
                              cowName,
                              style: TextStyles.labelTextStyle,
                            ),
                            Text(
                              quantiTyController.text ?? "0",
                              style: TextStyles.linkStyle,
                            )
                          ],
                        ),
                        Text(
                          noteController.text ?? "Không có",
                          style: TextStyles.linkStyle,
                        )
                      ],
                    ),
                    padding: EdgeInsets.all(10),
                  )),
            Positioned(
              right: 0.0,
              child: GestureDetector(
                onTap: () {
                  setState(() {
                    minimze = !minimze;
                  });
                },
                child: Align(
                  alignment: Alignment.bottomCenter,
                  child: CircleAvatar(
                      radius: 14.0,
                      backgroundColor: Colors.white,
                      child: Center(
                        child: Icon(Icons.minimize_rounded, color: Colors.red),
                      )),
                ),
              ),
            ),
          ],
        );
      }
      return Card(
        child: Center(child: Text(status)),
      );
    }, listener: (context, state) {
      if (state is CreateMilkingSlipDetailDone) {
        status = "Đã gửi";
        sended = true;
        minimze = !minimze;
        showToast(context: context, string: status);
        BlocProvider.of<MilkingSlipBloc>(context)
          ..add(OnPressAddItemMilkingSlipEvent());
      }
    });
  }
}
