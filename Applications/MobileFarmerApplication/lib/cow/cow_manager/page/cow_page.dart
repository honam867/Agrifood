import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_cubit.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/cow_detail.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CowPage extends StatefulWidget {
  final String value;
  CowPage({this.value});

  @override
  _CowPageState createState() => _CowPageState();
}

class _CowPageState extends State<CowPage> {
  CowModel cowModel = new CowModel();

  void getCowLoaded(BuildContext context) {
    final byreCubit = context.watch<CowCubit>();
    byreCubit.getListCow();
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<CowCubit, CowState>(
      listener: (context, state) {},
      builder: (context, state) {
        if (state is CowInitial) {
          getCowLoaded(context);
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
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => FormCreateCow()));
                    })
              ],
            ),
            body: Column(
              children: <Widget>[
                Expanded(
                    child: Padding(
                  padding: EdgeInsets.only(top: ScreenUtil().setHeight(35)),
                  child: ListView.builder(
                    // children: [CowCard(), CowCard(), CowCard()],
                    itemCount: cowModel.cowItem.length,
                    itemBuilder: (BuildContext context, int index) {
                      final cowItem = cowModel.cowItem[index];
                      return CowCard(cowItem: cowItem);
                      // return SlidableWidget(
                      //   child: CowCard(c: cowItem),
                      //   onDismissed: (action) => dismissSlidableItem(
                      //       context, index, action, byreItem),
                      // );
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
}
