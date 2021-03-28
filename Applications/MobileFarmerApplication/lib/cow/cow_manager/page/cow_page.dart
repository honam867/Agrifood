import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/cow_detail.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/popup_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/widget/slidable_widget.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CowPage extends StatefulWidget {
  final String value;
  final int byreId;
  final String route;
  CowPage({this.value, this.byreId, this.route});

  @override
  _CowPageState createState() => _CowPageState();
}

class _CowPageState extends State<CowPage> {
  CowModel cowModel = new CowModel();

  void addCow(BuildContext context, CowItem cowItem) {
    BlocProvider.of<CowBloc>(context).add(CowAddProcess(cowItem));
  }

  void deleteCow(BuildContext context, int cowId) {
    BlocProvider.of<CowBloc>(context).add(CowDeleteProcess(cowId));
  }

  @override
  Widget build(BuildContext context) { 
    return BlocConsumer<CowBloc, CowState>(
      listener: (context, state) {
        if (state is AddCowDoneLoaded) {
          //getCowLoaded(context);
        }
        if (state is CowDeleted) {
          showToast(context: context, string: state.result);
          BlocProvider.of<CowBloc>(context).add(CowLoadedSucces());
          Navigator.pop(context);
        }
      },
      builder: (context, state) {
        if (state is CowLoadInprocess) {
          BlocProvider.of<CowBloc>(context).add(CowLoadedSucces());
        }
        if (state is CowLoaded) {
          cowModel = state.cowModel;
          return SafeArea(
              child: Scaffold(
            appBar: AppBar(
              backgroundColor: Color(0xff9CCC65),
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
                                routeName: "CowPage",
                              ),
                            ),
                          ));
                    })
              ],  
            ),
            body: Column(
              children: <Widget>[
                Expanded(
                    child: Padding(
                  padding: EdgeInsets.only(top: ScreenUtil().setHeight(40)),
                  child: ListView.builder(
                    // children: [CowCard(), CowCard(), CowCard()],
                    itemCount: cowModel.cowItem.length,
                    itemBuilder: (BuildContext context, int index) {
                      final cowItem = cowModel.cowItem[index];

                      return SlidableWidget(
                        child: CowCard(cowItem: cowItem),
                        onDismissed: (action) => dismissSlidableItem(
                            context, index, action, cowItem),
                      );
                    },
                  ),
                )),
              ],
            ),
          ));
        }
        return SplashPage();
      },
    );
  }

  void dismissSlidableItem(
      BuildContext context, int index, SlidableAction action, CowItem cowItem) {
    switch (action) {
      case SlidableAction.more:
        break;
      case SlidableAction.delete:
        openPopupDeleteCow(context,
            cowId: cowItem.id, deleteCowFuction: deleteCow);
        break;
    }
  }
}
