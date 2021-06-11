import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/cow_page.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

void reloadCow(
    {BuildContext context,
    byreId,
    routeName,
    CowItem cowItem,
    FarmerInfoModel farmerInfoModel}) {
  if (routeName == "HomePage") {
    Navigator.pop(context);
  } else if (routeName == "DashBoard") {
    Navigator.pop(context);
    Navigator.pop(context);

    Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => CowBloc(
                cowRepository: CowRepository(),
                foodSuggestionRepository: FoodSuggestionRepository()),
            child: CowPage(
              farmerInfoModel: farmerInfoModel,
              route: routeName,
            ),
          ),
        ));
  } else if (routeName == "EditCow") {
    Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => CowBloc(
                cowRepository: CowRepository(),
                foodSuggestionRepository: FoodSuggestionRepository()),
            child: CowPage(
              farmerInfoModel: farmerInfoModel,
              route: "DashBoard",
            ),
          ),
        ));
  } else {
    Navigator.pop(context);
    Navigator.pop(context);
    Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => CowBloc(
                cowRepository: CowRepository(),
                foodSuggestionRepository: FoodSuggestionRepository()),
            child: CowPage(
              route: routeName,
              farmerInfoModel: farmerInfoModel,
              byreId: byreId,
            ),
          ),
        ));
  }
}
