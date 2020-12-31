class OkValueObject {
  //String code;
  String value;
  int statusCode;

  OkValueObject({this.value, this.statusCode});

  OkValueObject.fromJson(Map<String, dynamic> json) {
    //code = json['CODE'];
    value = json['value'];
    statusCode = json['statusCode'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    //data['CODE'] = this.code;
    data['value'] = this.value;
    data['statusCode'] = this.statusCode;

    return data;
  }
}
