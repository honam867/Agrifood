import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/foodSuggestion/bloc/foodSuggestion_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/popup_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/reloadCow.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/feedCow/page/feedCow_page.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/format.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:AgrifoodApp/ui/utils/text_style.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/screen_util.dart';

class FormDetailCow extends StatefulWidget {
  final CowItem cowItem;
  final FoodSuggestionItem foodSuggestionItem;
  const FormDetailCow({Key key, this.cowItem, this.foodSuggestionItem})
      : super(key: key);
  @override
  _FormDetailCowState createState() => _FormDetailCowState();
}

class _FormDetailCowState extends State<FormDetailCow> {
  int index = 0;
  void deleteCow(BuildContext context, int cowId) {
    BlocProvider.of<CowBloc>(context).add(CowDeleteProcess(cowId));
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<CowBloc, CowState>(builder: (context, state) {
      if (state is CowLoadInprocess) {
        BlocProvider.of<CowBloc>(context).add(GetCowByCowId(cowItem: widget.cowItem));
      }
      if (state is GetCowFatherMotherName) {
        return SafeArea(
          child: Scaffold(
            bottomNavigationBar: BottomNavigationBar(
              //backgroundColor: Color(0xff9CCC65),
              selectedItemColor: Colors.redAccent,
              onTap: (int index) {
                setState(() {
                  if (index == 0) {
                    openPopupDeleteCow(context,
                        cowId: widget.cowItem.id, deleteCowFuction: deleteCow);
                  } else if (index == 2) {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => BlocProvider(
                                  create: (context) => FoodSuggestionBloc(
                                      foodSuggestionRepository:
                                          FoodSuggestionRepository()),
                                  child: FeedCow(
                                      contextfoodPage: context,
                                      cowId: widget.cowItem.id,
                                      routefoodName: "FeedCow",
                                      foodSuggestionItem:
                                          widget.foodSuggestionItem),
                                )));
                  } else {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => BlocProvider(
                            create: (context) => CowBloc(
                                cowRepository: CowRepository(),
                                foodSuggestionRepository:
                                    FoodSuggestionRepository()),
                            child: FormCreateCow(
                                contextCowPage: context,
                                routeName: "EditCow",
                                cowItem: widget.cowItem),
                          ),
                        ));
                  }
                });
              },
              currentIndex: index, // this will be set when a new tab is tapped
              items: [
                BottomNavigationBarItem(
                  icon: new Icon(Icons.delete, color: Colors.red),
                  label: "Xóa",
                  backgroundColor: Colors.red,
                  //activeIcon: new Text("Xóa")
                ),
                BottomNavigationBarItem(
                  icon: Icon(Icons.edit),
                  label: "Chỉnh sửa",
                ),
                BottomNavigationBarItem(
                  icon: Icon(Icons.food_bank),
                  label: "Cho ăn",
                ),
              ],
            ),
            appBar: AppBar(
              backgroundColor: colorApp,
              title: Text('Chi tiết bò'),
              leading: IconButton(
                icon: Icon(Icons.navigate_before),
                onPressed: () {
                  Navigator.pop(context);
                },
              ),
            ),
            body: Container(
              color: Colors.lightGreen[50],
              width: double.infinity,
              height: double.infinity,
              child: Column(
                children: <Widget>[
                  Expanded(
                    child: Container(
                      child: ListTile(
                        title: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            builItem(
                                title: "Tên bò: ", string: widget.cowItem.name),
                            Divider(
                              height: 20,
                              thickness: 1,
                              color: Colors.grey,
                            ),
                            builItem(
                                title: "Bò cha: ",
                                string: widget.cowItem.fatherName),
                            Divider(
                              height: 20,
                              thickness: 1,
                              color: Colors.grey,
                            ),
                            builItem(
                                title: "Bò mẹ: ",
                                string: widget.cowItem.motherName),
                            Divider(
                              height: 20,
                              thickness: 1,
                              color: Colors.grey,
                            ),
                            builItem(
                                title: "Chuồng: ",
                                string: widget.cowItem.byreName ?? ""),
                            Divider(
                              height: 20,
                              thickness: 1,
                              color: Colors.grey,
                            ),
                            builItem(
                                title: "Mã bò: ", string: widget.cowItem.code),
                            Divider(
                              height: 20,
                              thickness: 1,
                              color: Colors.grey,
                            ),
                            // builItem(
                            //     title: "thức ăn: ",
                            //     string: widget.cowItem.foodSuggestionId.toString()),
                            // Divider(
                            //   height: 20,
                            //   thickness: 1,
                            //   color: Colors.grey,
                            // ),
                            builItem(
                                title: "Ngày cai sữa: ",
                                string: Formator.convertDatatimeToString(
                                    widget.cowItem.weaningDate ??
                                        DateTime.now())),
                          ],
                        ),
                      ),
                      // decoration: BoxDecoration(
                      //   color: Colors.green[100],
                      //   borderRadius: BorderRadius.only(
                      //     topLeft: Radius.circular(20),
                      //     topRight: Radius.circular(20),
                      //     bottomLeft: Radius.circular(75),
                      //     bottomRight: Radius.circular(75),
                      // )),
                    ),
                  )
                ],
              ),
            ),
          ),
        );
      }
      return Container(
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.width,
        color: Colors.white,
          child: Center(
        child: CircularProgressIndicator(),
      ));
    }, listener: (context, state) {
      if (state is CowDeleted) {
        showToast(context: context, string: state.result);
        reloadCow(context: context, routeName: "HomePage");
        //BlocProvider.of<CowBloc>(context).add(CowLoadedSucces());
        Navigator.pop(context);
      }
    });
  }
}

Widget builItem({title, string}) {
  return Row(
    crossAxisAlignment: CrossAxisAlignment.center,
    mainAxisAlignment: MainAxisAlignment.spaceBetween,
    children: [
      Padding(
        padding: EdgeInsets.only(top: ScreenUtil().setHeight(60)),
        child: Text(title, style: TextStyles.labelTextStyle),
      ),
      Padding(
        padding: EdgeInsets.only(top: ScreenUtil().setHeight(60)),
        child: Text(string, style: TextStyles.detailTextCow),
      ),
    ],
  );
}
