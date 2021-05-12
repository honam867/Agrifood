import 'feed_history_detail_item.dart';

class FeedHistoryDetailModel {
  List<FeedHistoryDetailItem> feedHistoryDetailItem;

  FeedHistoryDetailModel({this.feedHistoryDetailItem});

  factory FeedHistoryDetailModel.fromJson(List<dynamic> parsedJson) {
    List<FeedHistoryDetailItem> feedHistoryDetailItem = new List<FeedHistoryDetailItem>();
    feedHistoryDetailItem = parsedJson.map((i) => FeedHistoryDetailItem.fromJson(i)).toList();
    return new FeedHistoryDetailModel(
      feedHistoryDetailItem: feedHistoryDetailItem,
    );
  }
}
