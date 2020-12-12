class ChangePassModel {
  String oldPassword;
  String newPassword;
  String reNewPassword;

  ChangePassModel({this.oldPassword, this.newPassword, this.reNewPassword});

  ChangePassModel.fromJson(Map<String, dynamic> json) {
    oldPassword = json['oldPassword'];
    newPassword = json['newPassword'];
    reNewPassword = json['reNewPassword'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['oldPassword'] = this.oldPassword;
    data['newPassword'] = this.newPassword;
    data['reNewPassword'] = this.reNewPassword;
    return data;
  }
}
