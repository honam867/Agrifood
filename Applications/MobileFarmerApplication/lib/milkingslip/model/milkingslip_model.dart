import 'package:AgrifoodApp/milkingslip/model/milkingslip_item.dart';

class MilkingSlipModel {
  List<MilkingSlipItem> milkingSlipItem;

  MilkingSlipModel({this.milkingSlipItem});

  factory MilkingSlipModel.fromJson(List<dynamic> parsedJson) {
    List<MilkingSlipItem> milkingSlipItem = new List<MilkingSlipItem>();
    milkingSlipItem =
        parsedJson.map((i) => MilkingSlipItem.fromJson(i)).toList();
    return new MilkingSlipModel(
      milkingSlipItem: milkingSlipItem,
    );
  }
}
