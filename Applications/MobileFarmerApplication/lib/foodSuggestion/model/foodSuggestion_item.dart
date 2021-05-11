class FoodSuggestionItem {
  int id;
  String code;
  String name;
  String type; 


  FoodSuggestionItem({
    this.id,
    this.code,
    this.name,
    this.type
  });

  FoodSuggestionItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    code = json['code'];
    name = json['name'];
    type = json['type'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['code'] = this.code;
    data['name'] = this.name;
    data['type'] = this.type;
    return data;
  }
}
