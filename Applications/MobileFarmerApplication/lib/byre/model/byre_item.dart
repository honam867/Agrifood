class ByreItem {
  int id;
  String code;
  String name;
  int breedId;
  int quantityCow;
  int farmerId;
  String ration;

  ByreItem(
      {this.id,
      this.code,
      this.name,
      this.breedId,
      this.quantityCow,
      this.farmerId,
      this.ration});

  ByreItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    code = json['code'];
    name = json['name'];
    breedId = json['breedId'];
    quantityCow = json['quantityCow'];
    farmerId = json['farmerId'];
    ration = json['ration'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['code'] = this.code;
    data['name'] = this.name;
    data['breedId'] = this.breedId;
    data['quantityCow'] = this.quantityCow;
    data['farmerId'] = this.farmerId;
    data['ration'] = this.ration;
    return data;
  }
}
