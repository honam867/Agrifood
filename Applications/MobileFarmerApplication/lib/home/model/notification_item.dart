class NotificationItem {
  int id;
  String code;
  int farmerId;
  int employeeId;
  String name;
  String farmerName;
  String content;
  String address;
  int status;
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
    this.employeeId,
    this.name,
    this.content,
    this.status,
  });

  NotificationItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    code = json['code'];
    address = json['address'];
    birthday = json['birthday'];
    farmerId = json['farmerId'];
    farmerName = json['farmerName'];
    employeeId = json['EmployeeId'];
    userId = json['userId'];
    name = json['name'];
    content = json['content'];
    status = json['status'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['Id'] = this.id;
    data['EmployeeId'] = this.employeeId;
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