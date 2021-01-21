import 'package:AgrifoodApp/cow/cow_manager/component/cow_detail.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_detail_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/widget/slidable_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CowsPage extends StatefulWidget {
  final String value;
  CowsPage({this.value});

  @override
  _CowsPageState createState() => _CowsPageState();
}

class _CowsPageState extends State<CowsPage> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
          appBar: AppBar(
            backgroundColor: Color(0xFF26A69A),
            title: Text('Quản lí bò'),
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
                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (context) => FormCreateCow()));
                  })
            ],
          ),
          body: SafeArea(
            child: Scaffold(
              appBar: AppBar(
                backgroundColor: Color(0xFF26A69A),
                title: Text('Quản lí bò'),
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
                        // openPopupAddByre(context,
                        //     addByreFuction: addByreFuction,
                        //     listBreedItem: listBreed,
                        //     changeBreedFuction: changeBreed,
                        //     breedId: breedId);
                      })
                ],
              ),
              body: Column(
                children: <Widget>[
                  Expanded(
                      child: Padding(
                    padding: EdgeInsets.only(top: ScreenUtil().setHeight(35)),
                    child: ListView(
                      children: [CowCard(), CowCard(), CowCard()],
                      //itemCount: byreModel.byreItem.length,
                      // itemBuilder: (BuildContext context, int index) {
                      //   //final byreItem = byreModel.byreItem[index];
                      //   return SlidableWidget(
                      //     child: CowCard(byreItem: byreItem),
                      //     onDismissed: (action) => dismissSlidableItem(
                      //         context, index, action, byreItem),
                      //   );
                      // },
                    ),
                  )),
                ],
              ),
            ),
          )),
    );
  }
}