class SignUpModel {
  int customerId;
  String name;
  String userName;
  String password;
  String email;
  int phoneNumber;
  String lastName;
  int otherContact;
  bool sex;
  String remarks;
  String avatarURL;

  SignUpModel(
      {
      this.name,
      this.userName,
      this.password,
      this.phoneNumber,
      this.lastName,
      this.sex,
      this.otherContact,
      this.remarks,
      this.avatarURL});

  SignUpModel.fromJson(Map<String, dynamic> json) {
    customerId = json['CustomerId'];
    name = json['Name'];
    userName = json['UserName'];
    password = json['Password'];
    phoneNumber = json['PhoneNumber'];
    lastName = json['LastName'];
    email = json['Email'];
    otherContact = json['OtherContact'];
    sex = json['Sex'];
    remarks = json['Remarks'];
    avatarURL = json['AvatarURL'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['CustomerId'] = this.customerId;
    data['Name'] = this.name;
    data['UserName'] = this.userName;
    data['Password'] = this.password;
    data['PhoneNumber'] = this.phoneNumber;
    data['LastName'] = this.lastName;
     data['Email'] = this.email;
    data['OtherContact'] = this.lastName;
    data['Sex'] = this.sex;
    data['Remarks'] = this.remarks;
    data['AvatarURL'] = this.avatarURL;
    return data;
  }
}
