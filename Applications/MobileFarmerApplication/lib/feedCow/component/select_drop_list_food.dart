import 'package:flutter/material.dart';
import 'package:AgrifoodApp/foodSuggestion/model/foodSuggestion_item.dart';
import 'package:AgrifoodApp/feedcow/model/drop_model_food.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class SelectDropListFood extends StatefulWidget {
  final FoodSuggestionItem itemFoodSelected;
  final DropListFoodModel dropListFoodModel;
  final Function(FoodSuggestionItem optionItem) onOptionSelected;

  SelectDropListFood(this.itemFoodSelected, this.dropListFoodModel, this.onOptionSelected);

  @override
  _SelectDropListFoodState createState() =>
      _SelectDropListFoodState(itemFoodSelected, dropListFoodModel);
}

class _SelectDropListFoodState extends State<SelectDropListFood>
    with SingleTickerProviderStateMixin {
  FoodSuggestionItem optionItemSelected;
  final DropListFoodModel dropListFoodModel;

  AnimationController expandController;
  Animation<double> animation;

  bool isShow = false;

  _SelectDropListFoodState(this.optionItemSelected, this.dropListFoodModel);

  @override
  void initState() {
    super.initState();
    expandController =
        AnimationController(vsync: this, duration: Duration(milliseconds: 350));
    animation = CurvedAnimation(
      parent: expandController,
      curve: Curves.fastOutSlowIn,
    );
    _runExpandCheck();
  }

  void _runExpandCheck() {
    if (isShow) {
      expandController.forward();
    } else {
      expandController.reverse();
    }
  }

  @override
  void dispose() {
    expandController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: <Widget>[
          Container(
            padding: EdgeInsets.symmetric(
              horizontal: ScreenUtil().setWidth(60.0),
              vertical: ScreenUtil().setHeight(60.0)),
            decoration: new BoxDecoration(
              borderRadius: BorderRadius.circular(0.0),
              color: Colors.orange[300],
              boxShadow: [
                BoxShadow(
                    blurRadius: ScreenUtil().setSp(0.0), color: Colors.black26, offset: Offset(0, 2))
              ],
            ),
            child: new Row(
              mainAxisSize: MainAxisSize.max,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: <Widget>[
                Icon(
                  Icons.card_travel,
                  color: Colors.black
                ),
                SizedBox(
                  width: ScreenUtil().setWidth(30)
                ),
                Expanded(
                    child: GestureDetector(
                  onTap: () {
                    this.isShow = !this.isShow;
                    _runExpandCheck();
                    setState(() {});
                  },
                  child: Text(
                    optionItemSelected.name,
                    style: TextStyle(color: Colors.black, fontSize: ScreenUtil().setWidth(50)),
                  ),
                )),
                Align(
                  alignment: Alignment(1, 0),
                  child: Icon(
                    isShow ? Icons.arrow_drop_down : Icons.arrow_right,
                    color: Colors.black,
                    size: ScreenUtil().setSp(100),
                  ),
                ),
              ],
            ),
          ),
          SizeTransition(
              axisAlignment: 1.0,
              sizeFactor: animation,
              child: Container(
                  margin: const EdgeInsets.only(bottom: 10),
                  padding: const EdgeInsets.only(bottom: 10),
                  decoration: new BoxDecoration(
                    borderRadius: BorderRadius.only(
                        bottomLeft: Radius.circular(10),
                        bottomRight: Radius.circular(80)),
                    color: Colors.white,
                    boxShadow: [
                      BoxShadow(
                          blurRadius: 4,
                          color: Colors.black26,
                          offset: Offset(0, 4))
                    ],
                  ),
                  child: _buildDropListOptions(
                      dropListFoodModel.listFoodOptionItems, context))),
//          Divider(color: Colors.grey.shade300, height: 1,)
        ],
      ),
    );
  }

  Column _buildDropListOptions(List<FoodSuggestionItem> items, BuildContext context) {
    return Column(
      children: items.map((item) => _buildSubMenu(item, context)).toList(),
    );
  }

  Widget _buildSubMenu(FoodSuggestionItem item, BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(left: 26.0, top: 5, bottom: 5),
      child: GestureDetector(
        child: Row(
          children: <Widget>[
            Expanded(
              flex: 1,
              child: Container(
                padding: const EdgeInsets.only(top: 20),
                decoration: BoxDecoration(
                  border: Border(
                      top: BorderSide(color: Colors.grey[200], width: 1)),
                ),
                child: Text(item.name,
                    style: TextStyle(
                        color: Colors.black,
                        fontWeight: FontWeight.w400,
                        fontSize: 14),
                    maxLines: 3,
                    textAlign: TextAlign.start,
                    overflow: TextOverflow.ellipsis),
              ),
            ),
          ],
        ),
        onTap: () {
          this.optionItemSelected = item;
          isShow = false;
          expandController.reverse();
          widget.onOptionSelected(item);
        },
      ),
    );
  }
}
