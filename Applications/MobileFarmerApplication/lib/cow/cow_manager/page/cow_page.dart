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
  final int farmerId;
  final String route;
  CowPage({this.value, this.byreId, this.route, this.farmerId});

  @override
  _CowPageState createState() => _CowPageState();
}

class _CowPageState extends State<CowPage> {
  List<CowItem> cowModel = [];

  List<CowItem> list = [];
  TextEditingController _searchQueryController = TextEditingController();
  bool _isSearching = false;
  String searchQuery = "Search query";

  void addCow(BuildContext context, CowItem cowItem) {
    BlocProvider.of<CowBloc>(context).add(CowAddProcess(cowItem));
  }

  void deleteCow(BuildContext context, int cowId) {
    BlocProvider.of<CowBloc>(context).add(CowDeleteProcess(cowId));
  }

  onSearchTextChanged(String text) async {
    List<CowItem> _searchResult = [];
    list.clear();
    if (text.isEmpty) {
      setState(() {});
      return;
    }

    cowModel.forEach((cowItem) {
      if (cowItem.name.toLowerCase().contains(text.toLowerCase())) {
        _searchResult.add(cowItem);
      }
    });

    setState(() {
      list.addAll(_searchResult);
    });
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
          if (widget.route == "ByrePage") {
            BlocProvider.of<CowBloc>(context)
                .add(GetCowByByreId(widget.byreId));
          } else if (widget.route == "DashBoard") {
            BlocProvider.of<CowBloc>(context).add(GetCowByFarmerId());
          } else {
            BlocProvider.of<CowBloc>(context).add(CowLoadedSucces());
          }
        }
        if (state is CowLoaded) {
          cowModel = state.cowModel.cowItem;
          if(_isSearching == false) list.addAll(cowModel);
          return SafeArea(
              child: Scaffold(
            backgroundColor: Colors.lightGreen[200],
            appBar: AppBar(
              backgroundColor: Color(0xff9CCC65),
              title: _isSearching == false
                  ? Text('Quản lí bò')
                  : _buildSearchField(),
              leading: _isSearching == false
                  ? IconButton(
                      icon: Icon(Icons.navigate_before),
                      onPressed: () {
                        Navigator.pop(context);
                      },
                    )
                  : Container(),
              actions: [
                IconButton(
                    icon: Icon(_isSearching == false ? Icons.search : Icons.close),
                    onPressed: () {
                      setState(() {
                        _isSearching = !_isSearching;
                      });
                    }),
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
            body: Container(
              color: Colors.lightGreen[200],
              child: Column(
                children: <Widget>[
                  Expanded(
                      child: Padding(
                    padding: EdgeInsets.only(top: ScreenUtil().setHeight(40)),
                    child: ListView.builder(
                      itemCount: list.length,
                      itemBuilder: (BuildContext context, int index) {
                        final cowItem = list[index];

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
            ),
          ));
        }
        return SplashPage();
      },
    );
  }

  Widget _buildSearchField() {
    return TextField(
        controller: _searchQueryController,
        autofocus: true,
        decoration: InputDecoration(
          hintText: "Search Data...",
          border: InputBorder.none,
          hintStyle: TextStyle(color: Colors.white30),
        ),
        style: TextStyle(color: Colors.white, fontSize: 16.0),
        onChanged: (query) => onSearchTextChanged(query));
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
