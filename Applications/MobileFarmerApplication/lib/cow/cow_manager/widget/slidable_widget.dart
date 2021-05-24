import 'package:flutter/material.dart';
import 'package:flutter_slidable/flutter_slidable.dart';

enum SlidableAction {more, delete}

class SlidableWidget extends StatelessWidget {
  final Widget child;
  final Function(SlidableAction action) onDismissed;

  const SlidableWidget ({
    @required this.child,
    @required this.onDismissed,
    Key key,
  }) : super(key: key);
  
  @override
  Widget build(BuildContext context) => Slidable(
    child: child, 
    actionPane: SlidableDrawerActionPane(),
    secondaryActions: <Widget>[
      IconSlideAction(
        caption: 'Thêm',
        color: Colors.blueGrey,
        icon: Icons.more_horiz,
        onTap: () => onDismissed(SlidableAction.more),
      ),
      IconSlideAction(
        caption: 'Xóa',
        color: Colors.redAccent,
        icon: Icons.delete,
        onTap: () => onDismissed(SlidableAction.delete),
      ),
    ],
    );
}