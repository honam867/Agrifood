class CowItem {
  int id;
  int byreId;
  String byreName;
  int motherId;
  String motherName;
  int fatherId;
  String fatherName;
  String name;
  String qrCode;
  String code;
  DateTime birthday;
  int ageNumber;
  String status;
  String gender;
  DateTime weaningDate;
  int foodSuggestionId;
  String foodSuggestionItem;

  CowItem(
      {this.id,
      this.byreId,
      this.motherId,
      this.byreName,
      this.status,
      this.fatherId,
      this.name,
      this.qrCode,
      this.code,
      this.birthday,
      this.ageNumber,
      this.gender,
      this.weaningDate,
      this.fatherName,
      this.motherName,
      this.foodSuggestionId,
      this.foodSuggestionItem});

  CowItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    byreId = json['byreId'];
    byreName = json['byreName'];
    motherId = json['motherId'];
    fatherId = json['fatherId'];
    fatherName = json['fatherName'];
    status = json['status'];
    motherName = json['motherName'];
    name = json['name'];
    qrCode = json['qrCode'];
    code = json['code'];
    birthday = DateTime.tryParse(json['birthday']);
    ageNumber = json['ageNumber'];
    gender = json['gender'];
    weaningDate = DateTime.tryParse(json['weaningDate']);
    foodSuggestionId = json['foodSuggestionId'];
    foodSuggestionItem = json['foodSuggestionItem'];
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
    data['fatherName'] = this.fatherName;
    data['status'] = this.status;
    data['motherName'] = this.motherName;
    data['birthday'] = this.birthday.toIso8601String();
    data['ageNumber'] = this.ageNumber;
    data['gender'] = this.gender;
    data['weaningDate'] = this.weaningDate.toIso8601String();
    data['foodSuggestionId'] = this.foodSuggestionId;
    data['foodSuggestionItem'] = this.foodSuggestionItem;
    return data;
  }
}
