import 'package:AgrifoodApp/byre/model/byre_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/build_birthday.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/build_gender_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/build_text_form.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/dropdown_mother_father_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/reloadCow.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/page/list_cow.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_model.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:AgrifoodApp/ui/utils/color.dart';
import 'package:AgrifoodApp/ui/utils/show_toast.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class FormCreateCow extends StatefulWidget {
  final BuildContext contextCowPage;
  final String routeName;

  FormCreateCow({Key key, this.contextCowPage, this.routeName})
      : super(key: key);
  @override
  State<StatefulWidget> createState() {
    return FormCreateCowState();
  }
}

class FormCreateCowState extends State<FormCreateCow> {
  String _namecow, gender = "Đực";
  DateTime _birthday;
  int selectedRadio = 1, foodSuggestionId, cowFatherId, cowMotherId, byreId;
  FoodSuggestionModel foodSuggestionModelName;
  CowModel cowModelName;
  CowModel cowModel = new CowModel();
  FoodSuggestionModel foodSuggestionModel = new FoodSuggestionModel();
  ByreModel byreModel = new ByreModel();

  TextEditingController _nameController = new TextEditingController();
  TextEditingController _codeController = new TextEditingController();

  void changeValue({title, value}) {
    setState(() {
      if (title == "Thức ăn") {
        foodSuggestionId = value;
      } else if (title == "Chuồng") {
        byreId = value;
      } else {
        if (title == "Bò cha") {
          cowFatherId = value;
        } else {
          cowMotherId = value;
        }
      }
    });
  }

  changDateTime({DateTime dateTime}) {
    setState(() {
      _birthday = dateTime;
    });
  }

  setSelectedRadio({int val, String title}) {
    setState(() {
      selectedRadio = val;
      gender = val == 1 ? "Đực" : "Cái";
    });
  }

  setTextValue({String value, String title}) {
    setState(() {
      if (title == "Mã bò") {
        _codeController.text = value;
      } else {
        _nameController.text = value;
      }
    });
  }

  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    return BlocConsumer<CowBloc, CowState>(
      listener: (context, state) {
        if (state is CowLoaded) {
          showToast(context: context, string: "Tạo thành công ");
          reloadCow(
              context: context, byreId: byreId, routeName: widget.routeName);
        }
      },
      builder: (context, state) {
        if (state is CowLoadInprocess) {
          BlocProvider.of<CowBloc>(context).add(FoodSuggestionSuccess());
        }
        if (state is FoodSuggestionLoaded) {
          foodSuggestionModel = state.foodSuggestionModel;
          byreModel = state.byreModel;
          cowModel = state.cowModel;

          return SafeArea(
            child: Scaffold(
              appBar: AppBar(
                backgroundColor: colorApp,
                title: Text('Tạo bò'),
              ),
              body: Container(
                margin: EdgeInsets.all(24),
                child: SingleChildScrollView(
                  key: _formKey,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: <Widget>[
                      buildTextForm(
                          validatorText: "Vui lòng không bỏ trống",
                          hint: "Tên bò",
                          nameController: _nameController,
                          width: width,
                          setTextFuction: setTextValue),
                      Row(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          buildTextForm(
                              validatorText: "Vui lòng không bỏ trống",
                              hint: "Mã bò",
                              codeController: _codeController,
                              width: width,
                              setTextFuction: setTextValue),
                          buildIdFather(
                              title: "Thức ăn",
                              foodSuggestionModel: this.foodSuggestionModel,
                              foodSuggestionId: foodSuggestionId,
                              changeValueFuction: changeValue),
                          buildIdFather(
                              title: "Chuồng",
                              byreModel: this.byreModel,
                              byreId: byreId,
                              changeValueFuction: changeValue),
                        ],
                      ),
                      cowModel.cowItem.length > 0
                          ? Row(
                              crossAxisAlignment: CrossAxisAlignment.center,
                              mainAxisAlignment: MainAxisAlignment.spaceAround,
                              children: [
                                buildIdFather(
                                    title: "Bò cha",
                                    cowFatherId: cowFatherId,
                                    cowModel: cowModel,
                                    changeValueFuction: changeValue),
                                buildIdFather(
                                    title: "Bò mẹ",
                                    cowModel: cowModel,
                                    changeValueFuction: changeValue,
                                    cowMotherId: cowMotherId)
                              ],
                            )
                          : Container(),
                      BuildBirth(
                        selectDateFunction: changDateTime,
                      ),
                      buildGender(
                          selectedRadio: selectedRadio,
                          selectRadioFunction: setSelectedRadio),
                      SizedBox(height: 10.0),
                      Padding(
                        padding: EdgeInsets.only(
                          top: 20.0,
                        ),
                        child: RaisedButton(
                          padding: const EdgeInsets.all(0.0),
                          child: Container(
                            decoration: const BoxDecoration(
                              color: Color(0xFF26A69A),
                            ),
                            padding: const EdgeInsets.symmetric(
                                horizontal: 30.0, vertical: 10.0),
                            child: const Text(
                              "Tạo bò",
                              style:
                                  TextStyle(fontSize: 20, color: Colors.white),
                            ),
                          ),
                          onPressed: () {
                            CowItem cowItem = new CowItem(
                                gender: gender,
                                byreId: byreId,
                                code: _codeController.text,
                                birthday:
                                    DateTime.parse(_birthday.toIso8601String()),
                                weaningDate:
                                    DateTime.parse(_birthday.toIso8601String()),
                                name: _nameController.text,
                                fatherId: cowFatherId,
                                ageNumber: 1,
                                motherId: cowMotherId,
                                foodSuggestionId: foodSuggestionId);
                            setState(() {
                              BlocProvider.of<CowBloc>(context)
                                  .add(CowAddProcess(cowItem));
                            });
                          },
                        ),
                      )
                    ],
                  ),
                ),
              ),
            ),
          );
        }
        return SplashPage();
      },
    );
  }
}
