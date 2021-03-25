import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/cow_page.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_neumorphic/flutter_neumorphic.dart';

void reloadCow({BuildContext context, byreId, routeName}) {
  if (routeName == "HomePage") {
    Navigator.pop(context);
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
              byreId: byreId,
            ),
          ),
        ));
  }
}
