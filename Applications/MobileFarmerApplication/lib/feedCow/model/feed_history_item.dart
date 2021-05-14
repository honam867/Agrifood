class FeedHistoryItem {
  int id;
  String code;
  int cowId;
  DateTime createdDate;

  FeedHistoryItem({this.id, this.code, this.cowId, this.createdDate});

  FeedHistoryItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    code = json['code'];
    cowId = json['cowId'];
    createdDate = DateTime.parse(json['createdDate']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['code'] = this.code;
    data['cowId'] = this.cowId;
    data['createdDate'] = this.createdDate;
    return data;
  }
}
