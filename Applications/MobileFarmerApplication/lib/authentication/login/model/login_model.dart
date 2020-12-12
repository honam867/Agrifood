import 'package:json_annotation/json_annotation.dart';
part 'login_model.g.dart';

@JsonSerializable(explicitToJson: true)
class LoginModel {
  String userName;
  String passWord;
  

  LoginModel(this.userName, this.passWord,);

  factory LoginModel.fromJson(Map<String, dynamic> json) =>
      _$LoginModelFromJson(json);
  Map<String, dynamic> toJson() => _$LoginModelToJson(this);
}
