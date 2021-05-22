class FarmerInfoModel {
  int id;
  String name;
  String code;
  String fullName;
  String email;
  String phoneNumber;
  String avatarURL;
  String address;
  bool status;
  int userId;
  String userUserName;
  bool gender;
  DateTime birthday;


  FarmerInfoModel({
    this.id,
    this.userId,
    this.name,
    this.code,
    this.birthday,
    this.address,
    this.gender,
    this.fullName,
    this.email,
    this.userUserName,
    this.phoneNumber,
    this.avatarURL,
    this.status,
  });

  FarmerInfoModel.fromJson(Map<String, dynamic> json) {
    id = json['Id'];
    name = json['Name'];
    code = json['Code'];
    address = json['Address'];
    birthday = DateTime.parse(json['Birthday']);
    fullName = json['FullName'];
    userUserName = json['UserUserName'];
    gender = json['Gender'];
    email = json['Email'];
    userId = json['userId'];
    phoneNumber = json['PhoneNumber'];
    avatarURL = json['AvatarURL'];
    status = json['Status'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['Id'] = this.id;
    data['Name'] = this.name;
    data['Email'] = this.email;
    data['UserUserName'] = this.userUserName;
    data['Birthday'] = this.birthday;
    data['UserId'] = this.userId;
    data['Address'] = this.address;
    data['Code'] = this.code;
    data['Fullname'] = this.fullName;
    data['PhoneNumber'] = this.phoneNumber;
    data['AvatarURL'] = this.avatarURL;
    data['Status'] = this.status;
    return data;
  }
}
