class CowItem {
  int id;
  int cowId;
  int motherId;
  int fatherId;
  String name;
  String qrCode;
  String code;
  DateTime birthday;
  int ageNumber;
  String gender;
  DateTime weaningDate;
  int foodSuggestionId;

  CowItem(
      {this.id,
      this.cowId,
      this.motherId,
      this.fatherId,
      this.name,
      this.qrCode,
      this.code,
      this.birthday,
      this.ageNumber,
      this.gender,
      this.weaningDate,
      this.foodSuggestionId});

  CowItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cowId = json['cowId'];
    motherId = json['motherId'];
    fatherId = json['fatherId'];
    name = json['name'];
    qrCode = json['qrCode'];
    code = json['code'];
    birthday = DateTime.parse(json['birthday']);
    ageNumber = json['ageNumber'];
    gender = json['gender'];
    weaningDate = DateTime.parse(json['weaningDate']);
    foodSuggestionId = json['foodSuggestionId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cowId'] = this.cowId;
    data['motherId'] = this.motherId;
    data['fatherId'] = this.fatherId;
    data['name'] = this.name;
    data['qrCode'] = this.qrCode;
    data['code'] = this.code;
    data['birthday'] = this.birthday;
    data['ageNumber'] = this.ageNumber;
    data['gender'] = this.gender;
    data['weaningDate'] = this.weaningDate;
    data['foodSuggestionId'] = this.foodSuggestionId;
    return data;
  }
}
