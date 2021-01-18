import 'package:AgrifoodApp/cow/cow_manager/component/form_create_cow.dart';
import 'package:AgrifoodApp/cow/cow_manager/component/form_detail_cow.dart';
import 'package:flutter/material.dart';


class ListCows extends StatefulWidget {
  final String value;
  ListCows({this.value});

  @override
  _ListCowsState createState() => _ListCowsState();
}

class _ListCowsState extends State<ListCows> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
          child: Scaffold(
          appBar: AppBar(
            backgroundColor: Color(0xFF26A69A),
            title: Text('Quản lí bò'),
            leading: IconButton(
              icon: Icon(Icons.navigate_before),
              onPressed: () {
                Navigator.pop(context);
              },
            ),
            actions: [
               IconButton(icon: Icon(Icons.add), onPressed: (){
                 Navigator.of(context).push(MaterialPageRoute(
                      builder: (context)=> FormCreateCow()));
               })
            ],
          ),
          body: Container(
              child: Container(
                  child: ListView.separated(
            itemCount: 1,
            separatorBuilder: (BuildContext context, int index) => Divider(),
            itemBuilder: (BuildContext context, int index) {
              return ListTile(
                  title: Row(
                children: [
                  Padding(
                    padding: EdgeInsets.only(left: 10, right: 50),
                  ),
                  SizedBox(
                    width: 40,
                  ),
                  InkWell(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Text("Tên con bò"),
                        Text("Cần nặng con bò"),
                        Text("Chú thích")
                      ],
                      
                    ),
                    onTap: () =>    Navigator.of(context).push(MaterialPageRoute(
                      builder: (context)=> FormDetailCow())),
                  )
                ],
              ));
            },
          )))),
    );
  }
}
