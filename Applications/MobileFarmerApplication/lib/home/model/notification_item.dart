class NotificationItem {
  int id;
  String code;
  int farmerId;
  int employeeid;
  String name;
  String content;
  String address;
  bool status;
  int userId;
  String userUserName;

  bool gender;
  DateTime birthday;

  NotificationItem({
    this.id,
    this.userId,
    this.code,
    this.birthday,
    this.address,
    this.gender,
    this.farmerId,
    this.employeeid,
    this.name,
    this.content,
    this.status,
  });

  NotificationItem.fromJson(Map<String, dynamic> json) {
    id = json['Id'];
    code = json['Code'];
    address = json['Address'];
    birthday = DateTime.parse(json['Birthday']);
    farmerId = json['FarmerId'];
    userUserName = json['UserUserName'];
    gender = json['Gender'];
    employeeid = json['EmployeeId'];
    userId = json['userId'];
    name = json['Name'];
    content = json['Content'];
    status = json['Status'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['Id'] = this.id;
    data['EmployeeId'] = this.employeeid;
    data['UserUserName'] = this.userUserName;
    data['Birthday'] = this.birthday;
    data['UserId'] = this.userId;
    data['Address'] = this.address;
    data['Code'] = this.code;
    data['FarmerId'] = this.farmerId;
    data['Name'] = this.name;
    data['Content'] = this.content;
    data['Status'] = this.status;
    return data;
  }
}
