class FoodItem {
  int id;
  String name;
  String type;
  int provinceid;

  FoodItem({this.id, this.name, this.type, this.provinceid});

  FoodItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    name = json['name'];
    type = json['type'];
    provinceid = json['provinceid'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['name'] = this.name;
    data['type'] = this.type;
    data['provinceid'] = this.provinceid;
    return data;
  }
}
