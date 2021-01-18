import 'package:AgrifoodApp/cow/cow_manager/page/list_cow.dart';
import 'package:flutter/material.dart';
import '../model/data.dart';
import '../model/byre.dart';
import '../widget/slidable_widget.dart';
import '../model/utils.dart';

class ListByres extends StatefulWidget {
  @override
  _ListByresState createState() => _ListByresState();
}

class _ListByresState extends State<ListByres> {
  List<Byre> items = List.of(Data.byres);
  bool aByre = false;

  TextEditingController _nameByreController = new TextEditingController();
  TextEditingController _quantityController = new TextEditingController();

  final _formKey = GlobalKey<FormState>();

  Function(void) addByre(String quantityCows, String nameByre) {
    Byre byre = new Byre(quantityCows: quantityCows, nameByre: nameByre);
    items.add(byre);
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: Color(0xFF26A69A),
          title: Text('Quản lí chuồng'),
          leading: IconButton(
            icon: Icon(Icons.navigate_before),
            onPressed: () {
              Navigator.pop(context);
            },
          ),
          actions: [
            IconButton(
                icon: Icon(Icons.add),
                onPressed: () {
                  setState(() {
                    showDialog(
                        context: context,
                        builder: (context) {
                          return AlertDialog(
                            title: Text("Tạo chuồng bò"),
                            elevation: 100.0,
                            backgroundColor: Color(0xFFFAFAFA),
                            content: Stack(
                              overflow: Overflow.visible,
                              children: <Widget>[
                                Positioned(
                                  right: -40.0,
                                  top: -40.0,
                                  child: InkResponse(
                                    onTap: () {
                                      Navigator.of(context).pop();
                                    },
                                    child: CircleAvatar(
                                      child: Icon(Icons.close),
                                      backgroundColor: Colors.red,
                                    ),
                                  ),
                                ),
                                Form(
                                  key: _formKey,
                                  child: Column(
                                    mainAxisSize: MainAxisSize.min,
                                    children: <Widget>[
                                      Padding(
                                        padding: EdgeInsets.all(8.0),
                                        child: TextFormField(
                                          controller: _nameByreController,
                                          validator: (nameByre) {
                                            return nameByre.isNotEmpty
                                                ? null
                                                : "Vui lòng nhập tên chuồng";
                                          },
                                          onSaved: (String value) {},
                                          decoration: InputDecoration(
                                            enabledBorder: OutlineInputBorder(
                                              borderSide: BorderSide(
                                                  color: Color(0xFF26A69A)),
                                            ),
                                            focusedBorder: OutlineInputBorder(
                                                borderSide: BorderSide(
                                                    color: Color(0xFF26A69A)),
                                            ),
                                            hintText: ("Tên chuồng"),
                                          ),
                                        ),
                                      ),
                                      Padding(
                                        padding: EdgeInsets.all(8.0),
                                        child: TextFormField(
                                          controller: _quantityController,
                                          validator: (value) {
                                            return value.isNotEmpty
                                                ? null
                                                : "Vui lòng nhập số lượng bò";
                                          },
                                          decoration: InputDecoration(
                                            enabledBorder: OutlineInputBorder(
                                              borderSide: BorderSide(
                                                  color: Color(0xFF26A69A)),
                                            ),
                                            focusedBorder: OutlineInputBorder(
                                              borderSide: BorderSide(
                                                  color: Color(0xFF26A69A)),
                                            ),
                                            hintText: ("Số lượng bò hiện có"),
                                          ),
                                        ),
                                      ),
                                      Padding(
                                        padding: const EdgeInsets.all(8.0),
                                        child: RaisedButton(
                                            padding: const EdgeInsets.all(0.0),
                                            child: Container(
                                              decoration: const BoxDecoration(
                                               color: Color(0xFF26A69A)
                                              ),
                                              padding:
                                                  const EdgeInsets.symmetric(
                                                      horizontal: 30.0,
                                                      vertical: 10.0),
                                              child: const Text(
                                                "Tạo",
                                                style: TextStyle(fontSize: 20, color: Colors.white),
                                              ),
                                            ),
                                            onPressed: () {
                                              setState(() {
                                                addByre(
                                                    _quantityController.text,
                                                    _nameByreController.text);
                                                _quantityController.text = "";
                                                _nameByreController.text = "";     
                                                Navigator.pop(context);
                                              });
                                            }),
                                      )
                                    ],
                                  ),
                                ),
                              ],
                            ),
                            // shape: CircleBorder(),
                          );
                        });
                    // addByre();
                    aByre = true;
                  });
                })
          ],
        ),
        body: Column(
          children: <Widget>[
            Expanded(
              child: ListView.builder(
                itemCount: items.length,
                itemBuilder: (BuildContext context, int index) {
                  final item = items[index];
                  return SlidableWidget(
                    child: buildListTile(item),
                    onDismissed: (action) =>
                        dismissSlidableItem(context, index, action),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }

  void dismissSlidableItem(
      BuildContext context, int index, SlidableAction action) {
    setState(() {
      items.removeAt(index);
    });

    switch (action) {
      case SlidableAction.more:
        Utils.showSnackBar(context, 'Selected more');
        break;
      case SlidableAction.delete:
        Utils.showSnackBar(context, 'Byre has been deleted');
        break;
    }
  }

  Widget buildListTile(Byre item) => ListTile(
        contentPadding: EdgeInsets.symmetric(
          horizontal: 16,
          vertical: 16,
        ),
        title: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              item.nameByre ?? "",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 4),
            Text(item.quantityCows ?? ""),
            Divider(
              height: 4,
              color: Colors.black,
            )
          ],
        ),
        onTap: () => Navigator.of(context)
            .push(MaterialPageRoute(builder: (context) => ListCows())),
      );
}

// Widget popUp(
//     BuildContext context,
//     var _formkey,
//     TextEditingController _nameByreController,
//     TextEditingController _quantityController,
//     Function(void) addByre) {
//   // final TextEditingController _textEditingController = TextEditingController();
// }
