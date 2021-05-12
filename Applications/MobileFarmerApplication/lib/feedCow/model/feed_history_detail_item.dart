class FeedHistoryDetailItem {
  int id;
  String code;
  int foodId;
  int feedHistoryId;
  int quantity;

  FeedHistoryDetailItem({this.id, this.code, this.foodId,this.feedHistoryId, this.quantity});

  FeedHistoryDetailItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    code = json['code'];
    feedHistoryId = json['feedHistoryId'];
    foodId = json['foodId'];
    quantity = json['quantity'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['code'] = this.code;
    data['feedHistoryId'] = this.feedHistoryId;
    data['foodId'] = this.foodId;
    data['quantity'] = this.quantity;
    return data;
  }
}
