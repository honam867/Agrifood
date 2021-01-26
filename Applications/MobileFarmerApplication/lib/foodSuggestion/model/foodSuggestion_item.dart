class FoodSuggestionItem {
  int id;
  String code;
  String content;

  FoodSuggestionItem({
    this.id,
    this.code,
    this.content,
  });

  FoodSuggestionItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    code = json['code'];
    content = json['content'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['code'] = this.code;
    data['content'] = this.content;
    return data;
  }
}
