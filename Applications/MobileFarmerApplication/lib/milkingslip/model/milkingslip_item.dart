class MilkingSlipItem {
  String code;
  String createdDate;
  int farmerId;
  String session;

  MilkingSlipItem({this.code, this.createdDate, this.farmerId, this.session});

  MilkingSlipItem.fromJson(Map<String, dynamic> json) {
    code = json['code'];
    createdDate = json['CreatedDate'];
    farmerId = json['FarmerId'];
    session = json['session'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['code'] = this.code;
    data['CreatedDate'] = this.createdDate;
    data['FarmerId'] = this.farmerId;
    data['session'] = this.session;
    return data;
  }
}