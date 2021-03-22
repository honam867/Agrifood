class MilkingSlipDetailItem {
  int id;
  int cowId;
  int milkingSlipId;
  int quantity;
  String note;

  MilkingSlipDetailItem(
      {this.id, this.cowId, this.milkingSlipId, this.quantity, this.note});

  MilkingSlipDetailItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cowId = json['cowId'];
    milkingSlipId = json['milkingSlipId'];
    quantity = json['quantity'];
    note = json['note'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cowId'] = this.cowId;
    data['milkingSlipId'] = this.milkingSlipId;
    data['quantity'] = this.quantity;
    data['note'] = this.note;
    return data;
  }
}
