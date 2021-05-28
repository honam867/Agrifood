class UserInfoModel {
  int id;
  String userName;
  String email;
  String phoneNumber;
  String landLine;
  String avatarURL;
  bool status;
  DateTime createdDate;
  String createdByUserName;
  DateTime updatedDate;
  String updatedByUserName;

  UserInfoModel(
      {this.id,
      this.userName,
      this.email,
      this.phoneNumber,
      this.landLine,
      this.avatarURL,
      this.status,
      this.createdDate,
      this.createdByUserName,
      this.updatedDate,
      this.updatedByUserName});

  UserInfoModel.fromJson(Map<String, dynamic> json) {
    id = json['Id'];
    userName = json['UserName'];
    email = json['Email'];
    phoneNumber = json['PhoneNumber'];
    landLine = json['LandLine'];
    avatarURL = json['AvatarURL'];
    status = json['Status'];
    createdDate = DateTime.parse(json['CreatedDate']);
    createdByUserName = json['CreatedByUserName'];
    updatedDate = DateTime.parse(json['UpdatedDate']);
    updatedByUserName = json['UpdatedByUserName'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['Id'] = this.id;
    data['UserName'] = this.userName;
    data['Email'] = this.email;
    data['PhoneNumber'] = this.phoneNumber;
    data['LandLine'] = this.landLine;
    data['AvatarURL'] = this.avatarURL;
    data['Status'] = this.status;
    data['CreatedDate'] = this.createdByUserName;
    data['CreatedByUserName'] = this.createdByUserName;
    data['UpdatedDate'] = this.updatedDate;
    data['UpdatedByUserName'] = this.updatedByUserName;
    return data;
  }
}
