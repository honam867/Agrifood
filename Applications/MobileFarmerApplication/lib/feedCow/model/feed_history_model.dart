import 'feed_history_item.dart';

class FeedHistoryModel {
  List<FeedHistoryItem> feedHistoryItem;

  FeedHistoryModel({this.feedHistoryItem});

  factory FeedHistoryModel.fromJson(List<dynamic> parsedJson) {
    List<FeedHistoryItem> feedHistoryItem = [];
    feedHistoryItem = parsedJson.map((i) => FeedHistoryItem.fromJson(i)).toList();
    return new FeedHistoryModel(
      feedHistoryItem: feedHistoryItem,
    );
  }
}
