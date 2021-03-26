import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_detail_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/cow_page.dart';
import 'package:AgrifoodApp/home/component/categorie.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class TotalCowPage extends StatefulWidget {
  final size;
  final closeTopContainer;
  final categoryHeight;
  final topContainer;
  final cowLength;
  final controller;

  const TotalCowPage(
      {Key key,
      this.size,
      this.closeTopContainer,
      this.categoryHeight,
      this.topContainer,
      this.cowLength,
      this.controller})
      : super(key: key);
  @override
  _TotalCowPageState createState() => _TotalCowPageState();
}

class _TotalCowPageState extends State<TotalCowPage> {
  List<Widget> itemsData = [];
  List<CowItem> responseList = new List<CowItem>();
  Widget item(CowItem cowItem) {
    return Container(
        height: 150,
        margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
        decoration: BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(20.0)),
            color: Colors.white,
            boxShadow: [
              BoxShadow(color: Colors.black.withAlpha(100), blurRadius: 10.0),
            ]),
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20.0, vertical: 10),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: <Widget>[
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text(
                    cowItem.name,
                    style: const TextStyle(
                        fontSize: 28, fontWeight: FontWeight.bold),
                  ),
                  Text(
                    cowItem.byreName,
                    style: const TextStyle(fontSize: 17, color: Colors.grey),
                  ),
                  SizedBox(
                    height: 10,
                  ),
                  Text(
                    cowItem.gender,
                    style: const TextStyle(
                        fontSize: 25,
                        color: Colors.black,
                        fontWeight: FontWeight.bold),
                  )
                ],
              ),
              Image.asset(
                "assets/layout/cow.png",
                height: double.infinity,
              )
            ],
          ),
        ));
  }

  @override
  Widget build(BuildContext context) {
    //  final CategoriesScroller categoriesScroller = CategoriesScroller();
    return BlocBuilder<CowBloc, CowState>(
      builder: (context, state) {
        if (state is CowLoadInprocess) {
          BlocProvider.of<CowBloc>(context).add(CowLoadedSucces());
        }
        if (state is CowLoaded) {
          responseList = state.cowModel.cowItem.reversed.toList();
          return Container(
              height: widget.size.height,
              child: Column(children: <Widget>[
                const SizedBox(
                  height: 10,
                ),
                AnimatedOpacity(
                  duration: const Duration(milliseconds: 200),
                  opacity: widget.closeTopContainer ? 0 : 1,
                  child: AnimatedContainer(
                      duration: const Duration(milliseconds: 200),
                      width: widget.size.width,
                      alignment: Alignment.topCenter,
                      height:
                          widget.closeTopContainer ? 0 : widget.categoryHeight,
                      child: CategoriesScroller(
                        byreLength: 1,
                        cowLength: responseList.length,
                      )),
                ),
                Expanded(
                    child: ListView.builder(
                        controller: widget.controller,
                        itemCount: responseList.length,
                        physics: BouncingScrollPhysics(),
                        itemBuilder: (context, index) {
                          double scale = 1.0;
                          if (widget.topContainer > 0.5) {
                            scale = index + 0.5 - widget.topContainer;
                            if (scale < 0) {
                              scale = 0;
                            } else if (scale > 1) {
                              scale = 1;
                            }
                          }
                          return Opacity(
                            opacity: scale,
                            child: Transform(
                                transform: Matrix4.identity()
                                  ..scale(scale, scale),
                                alignment: Alignment.bottomCenter,
                                child: InkWell(
                                  onTap: () {
                                    Navigator.push(
                                        context,
                                        MaterialPageRoute(
                                          builder: (context) => BlocProvider(
                                            create: (context) => CowBloc(
                                                cowRepository: CowRepository(),
                                                foodSuggestionRepository:
                                                    FoodSuggestionRepository()),
                                            child: FormDetailCow(
                                              cowItem: responseList[index],
                                            ),
                                          ),
                                        ));
                                  },
                                  child: Align(
                                      heightFactor: 0.7,
                                      alignment: Alignment.topCenter,
                                      child: item(responseList[index])),
                                )),
                          );
                        }))
              ]));
        }
        return SplashPage();
      },
    );
  }
}