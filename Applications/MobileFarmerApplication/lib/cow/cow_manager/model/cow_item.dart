class CowItem {
  int id;
  int byreId;
  String byreName;
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
      this.byreId,
      this.motherId,
      this.byreName,
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
    byreId = json['byreId'];
    byreName = json['byreName'];
    motherId = json['motherId'];
    fatherId = json['fatherId'];
    name = json['name'];
    qrCode = json['qrCode'];
    code = json['code'];
    birthday = DateTime.tryParse(json['birthday']);
    ageNumber = json['ageNumber'];
    gender = json['gender'];
    weaningDate = DateTime.tryParse(json['weaningDate']);
    foodSuggestionId = json['foodSuggestionId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['byreId'] = this.byreId;
    data['motherId'] = this.motherId;
    data['byreName'] = this.byreName;
    data['fatherId'] = this.fatherId;
    data['name'] = this.name;
    data['qrCode'] = this.qrCode;
    data['code'] = this.code;
    data['birthday'] = this.birthday.toIso8601String();
    data['ageNumber'] = this.ageNumber;
    data['gender'] = this.gender;
    data['weaningDate'] = this.weaningDate.toIso8601String();
    data['foodSuggestionId'] = this.foodSuggestionId;
    return data;
  }
}
