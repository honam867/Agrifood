class SignUpFarmerModel {
  // int farmerId;
  String userName;
  String email;
  String phoneNumber;
  String passWord;

  SignUpFarmerModel({
    // this.farmerId,
    this.userName,
    this.passWord,
    this.phoneNumber,
    this.email,
  });

  SignUpFarmerModel.fromJson(Map<String, dynamic> json) {
    // farmerId = json['farmerId'];
    userName = json['userName'];
    email = json['email'];
    phoneNumber = json['phoneNumber'];
    passWord = json['passWord'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    // data['customerId'] = this.farmerId;
    data['userName'] = this.userName;
    data['email'] = this.email;
    data['phoneNumber'] = this.phoneNumber;
    data['passWord'] = this.passWord;

    return data;
  }
}
