class SignUpPersonModel {
  int customerId;
  String userName;
  String email;
  int phoneNumber;
  String passWord;

  SignUpPersonModel({
    this.customerId,
    this.userName,
    this.passWord,
    this.phoneNumber,
    this.email,
  });

  SignUpPersonModel.fromJson(Map<String, dynamic> json) {
    customerId = json['customerId'];
    userName = json['userName'];
    email = json['email'];
    phoneNumber = json['phoneNumber'];
    passWord = json['passWord'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['customerId'] = this.customerId;
    data['userName'] = this.userName;
    data['email'] = this.email;
    data['phoneNumber'] = this.phoneNumber;
    data['passWord'] = this.passWord;

    return data;
  }
}
