import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/milkingslip/bloc/milkingslip_bloc.dart';
import 'package:AgrifoodApp/milkingslip/component/select_drop_list_cow.dart';
import 'package:AgrifoodApp/milkingslip/model/drop_list_model_cow.dart';
import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

typedef DeleteFuction = void Function();

class MilkingSlipDetailCard extends StatefulWidget {
  final int milkingSlipId;
  final DeleteFuction deleteFunction;

  MilkingSlipDetailCard({Key key, this.milkingSlipId, this.deleteFunction})
      : super(key: key);
  @override
  _MilkingSlipDetailCardState createState() => _MilkingSlipDetailCardState();
}

class _MilkingSlipDetailCardState extends State<MilkingSlipDetailCard> {
  TextEditingController nameController = TextEditingController();
  TextEditingController noteController = TextEditingController();
  TextEditingController quantiTyController = TextEditingController();
  int cowId;
  bool sended = false,
      minimze = false,
      _validate = false,
      isClosed = false,
      isEdited = false;
  String status = "Đang tải", cowName = "";
  CowItem optionItemSelected = CowItem(id: null, name: "Chọn bò");
  int milkingSlipDetailId;

  void closed() {
    setState(() {
      isClosed = true;
    });
    print("CLick");
  }

  void deleteItem() {
    widget.deleteFunction();
  }

  @override
  Widget build(BuildContext context) {
    return !isClosed
        ? BlocConsumer<MilkingSlipBloc, MilkingSlipState>(
            builder: (context, state) {
            if (state is MilkingSlipLoading) {
              return Card(
                  child: Center(
                child: CircularProgressIndicator(),
              ));
            }
            if (state is OnPressAddItemMilkingSlipState) {
              DropListModel dropListModel =
                  DropListModel(state.cowModel.cowItem);
              return Stack(
                children: [
                  minimze == false
                      ? Card(
                          child: Column(
                            children: [
                              sended == false
                                  ? Padding(
                                      padding: EdgeInsets.only(
                                          top: ScreenUtil().setHeight(20.0),
                                          bottom: ScreenUtil().setHeight(10.0),
                                          left: ScreenUtil().setHeight(20.0),
                                          right: ScreenUtil().setHeight(20.0)),
                                      child: Container(
                                        width:
                                            MediaQuery.of(context).size.width,
                                        child: SelectDropList(
                                          this.optionItemSelected,
                                          dropListModel,
                                          (optionItem) {
                                            optionItemSelected = optionItem;
                                            setState(() {
                                              cowId = int.parse(
                                                  optionItem.id.toString());
                                              cowName = optionItem.name;
                                              print(cowId);
                                            });
                                          },
                                        ),
                                      ),
                                    )
                                  : Padding(
                                      padding: EdgeInsets.all(ScreenUtil().setHeight(10.0)),
                                      child: Row(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.center,
                                        children: [
                                          Text(
                                            "Bò:",
                                            style: TextStyles.labelTextStyle,
                                          ),
                                          SizedBox(
                                            width: ScreenUtil().setWidth(20.0)
                                          ),
                                          RichText(
                                              text: TextSpan(
                                            text: cowName,
                                            style: DefaultTextStyle.of(context)
                                                .style,
                                          ))
                                        ],
                                      )),
                              Padding(
                                  padding: EdgeInsets.all(ScreenUtil().setWidth(20.0)),
                                  child: Row(
                                    crossAxisAlignment:
                                        CrossAxisAlignment.center,
                                    children: [
                                      Text(
                                        "Số lượng:",
                                        style: TextStyles.labelTextStyle,
                                      ),
                                      SizedBox(
                                        width: ScreenUtil().setWidth(10.0),
                                      ),
                                      Container(
                                        height: ScreenUtil().setWidth(120.0),
                                        width:
                                            MediaQuery.of(context).size.width -
                                                ScreenUtil().setWidth(600.0),
                                        child: TextField(
                                          decoration: InputDecoration(
                                            errorText: _validate == true
                                                ? 'Không được bỏ trống'
                                                : null,
                                          ),
                                          enabled:
                                              sended == true ? false : true,
                                          controller: quantiTyController,
                                          keyboardType: TextInputType.phone,
                                        ),
                                      ),
                                      //ew Spacer(),
                                      RichText(
                                          text: TextSpan(
                                        text: " ml",
                                        style:
                                            DefaultTextStyle.of(context).style,
                                      ))
                                    ],
                                  )),
                              Padding(
                                  padding: EdgeInsets.all(ScreenUtil().setWidth(20.0)),
                                  child: Row(
                                    crossAxisAlignment:
                                        CrossAxisAlignment.center,
                                    children: [
                                      Text(
                                        "Ghi chú:",
                                        style: TextStyles.labelTextStyle,
                                      ),
                                      SizedBox(
                                        width: ScreenUtil().setWidth(10.0),
                                      ),
                                      Container(
                                        height: ScreenUtil().setWidth(140.0),
                                        width:
                                            MediaQuery.of(context).size.width -
                                                ScreenUtil().setWidth(480.0),
                                        child: TextField(
                                          controller: noteController,
                                          enabled:
                                              sended == true ? false : true,
                                          keyboardType: TextInputType.multiline,
                                        ),
                                      )
                                    ],
                                  )),
                              Divider(),
                              Row(
                                crossAxisAlignment: CrossAxisAlignment.center,
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceAround,
                                children: [
                                  FlatButton(
                                      onPressed: () {
                                        deleteItem();
                                      },
                                      child: Row(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.center,
                                        mainAxisAlignment:
                                            MainAxisAlignment.center,
                                        children: [
                                          Icon(
                                            Icons.delete,
                                            color: Colors.redAccent,
                                          ),
                                          Text(
                                            "Xóa",
                                            style: TextStyle(
                                                color: Colors.redAccent),
                                          )
                                        ],
                                      )),
                                  FlatButton(
                                      onPressed: sended == false
                                          ? () {
                                              setState(() {
                                                quantiTyController.text.isEmpty
                                                    ? _validate = true
                                                    : _validate = false;
                                                if (isEdited == true) {
                                                  MilkingSlipDetailItem
                                                      milkingSlipDetailItem =
                                                      new MilkingSlipDetailItem(
                                                          id:
                                                              milkingSlipDetailId,
                                                          cowId: cowId,
                                                          milkingSlipId: widget
                                                              .milkingSlipId,
                                                          note: noteController
                                                              .text,
                                                          quantity: int.parse(
                                                              quantiTyController
                                                                  .text));
                                                  BlocProvider.of<
                                                      MilkingSlipBloc>(context)
                                                    ..add((MilkingSlipDetailUpdated(
                                                        milkingSlipDetailItem)));
                                                } else {
                                                  if (_validate == false) {
                                                    MilkingSlipDetailItem
                                                        milkingSlipDetailItem =
                                                        new MilkingSlipDetailItem(
                                                            cowId: cowId,
                                                            milkingSlipId: widget
                                                                .milkingSlipId,
                                                            note: noteController
                                                                .text,
                                                            quantity: int.parse(
                                                                quantiTyController
                                                                    .text));
                                                    print(
                                                        milkingSlipDetailItem);
                                                    BlocProvider.of<
                                                            MilkingSlipBloc>(
                                                        context)
                                                      ..add(CreateMilkingSlipDetail(
                                                          milkingSlipDetailItem));
                                                  }
                                                }
                                              });
                                            }
                                          : () {
                                              setState(() {
                                                isEdited = true;
                                                sended = false;
                                              });
                                            },
                                      child: Row(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.center,
                                        mainAxisAlignment:
                                            MainAxisAlignment.center,
                                        children: [
                                          Icon(
                                            isEdited == true ? Icons.edit : Icons.send,
                                            color: sended == false
                                                ? Colors.yellowAccent
                                                : Colors.grey,
                                          ),
                                          Text(
                                            isEdited == true ? "Chỉnh sửa" : "Gửi",
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
                          child: Row(
                            children: [
                              Padding(
                                padding: EdgeInsets.only(
                                    top: ScreenUtil().setSp(5),
                                    right: ScreenUtil().setWidth(25)),
                                child: ClipRRect(
                                  borderRadius: BorderRadius.only(
                                    topLeft: Radius.circular(15.0),
                                    topRight: Radius.circular(15.0),
                                    bottomLeft: Radius.circular(15.0),
                                    bottomRight: Radius.circular(15.0),
                                  ),
                                  child: Image.asset('assets/crud/research.png',
                                      width: ScreenUtil().setWidth(150),
                                      height: ScreenUtil().setHeight(150),
                                      fit: BoxFit.fill),
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(
                                    left: ScreenUtil().setWidth(30.0), 
                                    top: ScreenUtil().setWidth(15.0), 
                                    bottom: ScreenUtil().setWidth(15.0)),
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      cowName,
                                      style: TextStyles.labelTextStyle,
                                    ),
                                    Text(
                                      "${quantiTyController.text} ml" ?? "0",
                                      style: TextStyles.detailStyle,
                                    )
                                  ],
                                ),
                              ),
                              new Spacer(),
                              Padding(
                                padding: EdgeInsets.only(right: ScreenUtil().setWidth(30.0)),
                                child: RaisedButton(
                                  color: Colors.green[100],
                                  shape: RoundedRectangleBorder(
                                      borderRadius: BorderRadius.circular(20)),
                                  onPressed: () {
                                    setState(() {
                                      minimze = !minimze;
                                    });
                                  },
                                  child: Text(sended == true
                                      ? "Chi tiết"
                                      : "Chỉnh sửa"),
                                ),
                              )
                            ],
                          ),
                          padding: EdgeInsets.all(ScreenUtil().setWidth(30.0)),
                        )),
                  minimze == false
                      ? Positioned(
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
                                    child: Icon(Icons.highlight_off_rounded,
                                        color: Colors.red),
                                  )),
                            ),
                          ),
                        )
                      : Container(),
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
              isEdited = true;
              minimze = !minimze;
              milkingSlipDetailId = state.milkingdetailId;
              showToast(context: context, string: status);
              BlocProvider.of<MilkingSlipBloc>(context)
                ..add(OnPressAddItemMilkingSlipEvent(widget.milkingSlipId));
            } else if (state is UpdateMilkingSlipDetailDone) {
              status = "Đã sửa";
              sended = true;
              isEdited = false;
              minimze = !minimze;
              BlocProvider.of<MilkingSlipBloc>(context)
                ..add(OnPressAddItemMilkingSlipEvent(widget.milkingSlipId));
            }
          })
        : Container(
            height: 0,
            width: 0,
          );
  }
}
