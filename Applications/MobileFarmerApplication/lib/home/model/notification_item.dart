class NotificationItem {
  int id;
  int userId;
  int farmerId;
  int employeeid;
  String code;
  String name;
  String content;
  String address;
  String userUserName;
  bool status;
  bool gender;
  DateTime birthday;

  NotificationItem({
    this.id,
    this.userId,
    this.farmerId,
    this.employeeid,
    this.code,
    this.name,
    this.address,
    this.gender,
    this.content,
    this.status,
    this.birthday,
    this.userUserName,
  });

  NotificationItem.fromJson(Map<String, dynamic> json) {
    id = json['Id'];
    userId = json['userId'];
    farmerId = json['FarmerId'];
    employeeid = json['EmployeeId'];
    code = json['Code'];
    address = json['Address'];
    userUserName = json['UserUserName'];
    gender = json['Gender'];
    name = json['Name'];
    content = json['Content'];
    status = json['Status'];
    birthday = DateTime.parse(json['Birthday']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['Id'] = this.id;
    data['UserId'] = this.userId;
    data['FarmerId'] = this.farmerId;
    data['EmployeeId'] = this.employeeid;
    data['UserUserName'] = this.userUserName;
    data['Address'] = this.address;
    data['Code'] = this.code;
    data['Name'] = this.name;
    data['Gender'] = this.gender;
    data['Content'] = this.content;
    data['Status'] = this.status;
    data['Birthday'] = this.birthday;
    return data;
  }
}
