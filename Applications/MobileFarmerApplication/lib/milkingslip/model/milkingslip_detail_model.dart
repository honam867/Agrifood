import 'package:AgrifoodApp/milkingslip/model/milkingslip_detail_item.dart';

class MilkingSlipDetailModel {
  List<MilkingSlipDetailItem> milkingSlipDetaiItem;

  MilkingSlipDetailModel({this.milkingSlipDetaiItem});

  factory MilkingSlipDetailModel.fromJson(List<dynamic> parsedJson) {
    List<MilkingSlipDetailItem> milkingSlipDetaiItem =
        new List<MilkingSlipDetailItem>();
    milkingSlipDetaiItem =
        parsedJson.map((i) => MilkingSlipDetailItem.fromJson(i)).toList();
    return new MilkingSlipDetailModel(
      milkingSlipDetaiItem: milkingSlipDetaiItem,
    );
  }
}
