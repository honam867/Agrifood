import 'dart:async';

import 'package:AgrifoodApp/byre/bloc/byre_cubit.dart';
import 'package:AgrifoodApp/byre/component/byre_detail.dart';
import 'package:AgrifoodApp/byre/model/breed_item.dart';
import 'package:AgrifoodApp/byre/model/breed_model.dart';
import 'package:AgrifoodApp/byre/model/byre_item.dart';
import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/widget/slidable_widget.dart';
import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/home/page/home_page_new.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:AgrifoodApp/byre/component/popup_add_byre.dart';
import 'package:rflutter_alert/rflutter_alert.dart';

class ListByres extends StatefulWidget {
  final int farmerId;
  final FarmerInfoModel farmerInfoModel;

  const ListByres({Key key, this.farmerInfoModel, this.farmerId})
      : super(key: key);
  @override
  _ListByresState createState() => _ListByresState();
}

class _ListByresState extends State<ListByres> {
  ByreRepository byreRepository = new ByreRepository();
  CowRepository cowRepository = new CowRepository();

  List<BreedItem> listBreed = List<BreedItem>();
  int breedId;
  String breedName;

  @override
  void initState() {
    super.initState();
    this.getListBreed();
  }

  void changeBreed(BuildContext context, int value) {
    setState(() {
      breedId = value;
    });
  }

  void addByreFuction(BuildContext context, ByreItem byreItem) {
    byreItem.breedId = breedId;
    byreItem.farmerId = widget.farmerId;
    final byreCubit = context.read<ByreCubit>();
    byreCubit.addByre(byreItem: byreItem);
  }

  void deleteByreFuction(BuildContext context, int byreId) {
    final byreCubit = context.read<ByreCubit>();
    byreCubit.deleteByre(byreId: byreId);
  }

  void updateByreFuction(BuildContext context, int byreId, ByreItem byreItem) {
    final byreCubit = context.read<ByreCubit>();
    byreCubit.updateByre(byreId: byreId, byreItem: byreItem);
  }

  void getListByre(BuildContext context) {
    final byreCubit = context.watch<ByreCubit>();
    byreCubit.getListByreByFarmerId();
  }

  void cliclBack() {
    Navigator.push(
        context,
        MaterialPageRoute(
            builder: (context) => BlocProvider(
                create: (context) => HomeCubit(byreRepository, cowRepository),
                child: MyHomePage(
                  farmerInfoModel: widget.farmerInfoModel,
                ))));
  }

  typeTrue(BuildContext contextHome) {
    return Alert(
        closeFunction: () => Navigator.pop(context),
        context: context,
        image: Container(height: 50, width: 50, child: Image.asset('assets/layout/farmer.png')),
        onWillPopActive: true,
        title: "Loại bò",
        buttons: [
         DialogButton(
          color: Colors.green,
          onPressed: () {
           Navigator.pop(context);
          },
          child: Text(
           "Hủy",
            style: TextStyle(
                color: Colors.white, fontSize: ScreenUtil().setSp(60)),
          ),
        )
        ],
        content: StatefulBuilder(
          builder: (BuildContext context, state) {
            return DropdownButton(
              hint: new Text("Chọn loại"),
              items: listBreed.map((item) {
                return DropdownMenuItem(
                  value: item.id,
                  child: new Text(item.name),
                );
              }).toList(),
              value: breedId,
              onChanged: (val) {
                setState(() {
                  changeBreed(contextHome, val);
                  openPopupAddByre(
                    contextHome,
                    addByreFuction: addByreFuction,
                  );
                });
              },
            );
          },
        )).show();

    //  showDialog(
    //   context: context,
    //   builder: (context) => AlertDialog(
    //     title: Text("Loại bò"),
    //     content: StatefulBuilder(
    //       builder: (BuildContext context, state) {
    //         return DropdownButton(
    //           hint: new Text("Chọn loại"),
    //           items: listBreed.map((item) {
    //             return DropdownMenuItem(
    //               value: item.id,
    //               child: new Text(item.name),
    //             );
    //           }).toList(),
    //           value: breedId,
    //           onChanged: (val) {
    //             setState(() {
    //               changeBreed(contextHome, val);
    //               openPopupAddByre(
    //                 contextHome,
    //                 addByreFuction: addByreFuction,
    //               );
    //             });
    //           },
    //         );
    //       },
    //     ),
    //   ),
    // );
  }

  Future<List<ByreItem>> getListByreFunction({List<ByreItem> byreItem}) async {
    List<ByreItem> listByre = [];
    List<ByreItem> result = [];
    listByre.addAll(byreItem);
    await Future.wait(byreItem.map((e) async {
      BreedItem breedItem =
          await byreRepository.getBreedNameByBreedId(breedId: e.breedId);
      e.breedName = breedItem.name;
      result.add(e);
    }));
    return result;
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<ByreCubit, ByreState>(
      listener: (context, state) {
        if (state is Result) {
          if (state.message == "Xóa thành công" ||
              state.message == "Cập nhật thành công" ||
              state.message == "Tạo thành công") {
            showToast(context: context, string: state.message);
            Navigator.pop(context);
            Navigator.pop(context);
            getListByre(context);
          } else {
            showToast(string: "Kiểm tra lại thông tin", context: context);
          }
        }
      },
      builder: (context, state) {
        if (state is ByreInitial) {
          getListByre(context);
        }
        if (state is GetListByre) {
          final ByreModel byreModel = state.byreModel;

          return FutureBuilder<List<ByreItem>>(
              future: getListByreFunction(byreItem: byreModel.byreItem),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  print(snapshot.data);
                  return WillPopScope(
                      child: SafeArea(
                        child: Scaffold(
                          backgroundColor: Colors.lightGreen[200],
                          appBar: AppBar(
                            backgroundColor: Color(0xff9CCC65),
                            title: Text('Quản lí trại'),
                            leading: IconButton(
                                icon: Icon(Icons.navigate_before),
                                onPressed: cliclBack),
                            actions: [
                              IconButton(
                                  icon: Icon(Icons.add),
                                  onPressed: () {
                                    typeTrue(context);
                                  })
                            ],
                          ),
                          body: Column(
                            children: <Widget>[
                              Expanded(
                                  child: Padding(
                                padding: EdgeInsets.only(
                                    top: ScreenUtil().setHeight(50)),
                                child: ListView.builder(
                                  itemCount: snapshot.data.length,
                                  itemBuilder:
                                      (BuildContext context, int index) {
                                    final byreItem = snapshot.data[index];
                                    return SlidableWidget(
                                      child: ChapterCard(
                                        byreItem: byreItem,
                                        farmerInfoModel: widget.farmerInfoModel,
                                      ),
                                      onDismissed: (action) =>
                                          dismissSlidableItem(
                                              context, index, action, byreItem),
                                    );
                                  },
                                ),
                              )),
                            ],
                          ),
                        ),
                      ),
                      onWillPop: () {
                        cliclBack();
                        return Future.value(true);
                      });
                } else {
                  return SafeArea(
                      child: Scaffold(
                          backgroundColor: Colors.lightGreen[200],
                          appBar: AppBar(
                            backgroundColor: Color(0xff9CCC65),
                            title: Text('Quản lí trại'),
                            leading: IconButton(
                                icon: Icon(Icons.navigate_before),
                                onPressed: cliclBack),
                            actions: [
                              IconButton(
                                  icon: Icon(Icons.add),
                                  onPressed: () {
                                    typeTrue(context);
                                  })
                            ],
                          )));
                }
              });
        }
        return SplashPage();
      },
    );
  }

  void dismissSlidableItem(BuildContext context, int index,
      SlidableAction action, ByreItem byreItem) {
    switch (action) {
      case SlidableAction.more:
        openPopupAddByre(context,
            updateByreFuction: updateByreFuction,
            byreItem: byreItem,
            update: true,
            farmerId: widget.farmerId,
            listBreedItem: listBreed);
        break;
      case SlidableAction.delete:
        openPopupDeleteByre(context,
            deleteByreFuction: deleteByreFuction, byreId: byreItem.id);
        break;
    }
  }

  void getListBreed() async {
    BreedModel breedModel = await byreRepository.getListBreeds();
    listBreed = breedModel.breedItem;
  }
}
