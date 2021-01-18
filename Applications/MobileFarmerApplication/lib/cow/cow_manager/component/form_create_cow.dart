import 'package:AgrifoodApp/cow/cow_manager/page/list_cow.dart';
import 'package:flutter/material.dart';


class FormCreateCow extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return FormCreateCowState();
  }
}

class FormCreateCowState extends State<FormCreateCow> {
  String _namecow;
  String _idfather;
  String _idmother;
  String _birthday;
  //bool _genderMale = false;
  //bool _genderFemale = false;
  String _breed;
  int selectedRadio;

  @override
  void initState(){
    super.initState();
    selectedRadio = 0;
  }

  setSelectedRadio(int val){
    setState(() {
      selectedRadio = val;
    });
  }

  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  
  Widget _buildName() {
    return Padding(
      padding: EdgeInsets.only(
        top: 20.0,
      ),
      child: TextFormField(
        decoration: InputDecoration(
            enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              // borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            focusedBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              // borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            hintText: "Tên bò"),
        maxLength: 10,
        validator: (String value) {
          if (value.isEmpty) {
            return 'Tên bò là bắt buộc';
          }
        },
        onSaved: (String value) {
          _namecow = value;
        },
      ),
    );
  }

  Widget _buildIdFather() {
    return Padding(
      padding: EdgeInsets.only(
        top: 20.0,
      ),
      child: TextFormField(
        decoration: InputDecoration(
            enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              // borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            focusedBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              //borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            hintText: "ID bò cha"),
        maxLength: 10,
        validator: (String value) {
          if (value.isEmpty) {
            return 'ID bò cha là bắt buộc';
          }
        },
        onSaved: (String value) {
          _idfather = value;
        },
      ),
    );
  }

  Widget _buildIdMother() {
    return Padding(
      padding: EdgeInsets.only(
        top: 20.0,
      ),
      child: TextFormField(
        decoration: InputDecoration(
            enabledBorder: OutlineInputBorder(
            borderSide: BorderSide(color: Color(0xFF26A69A)),
              // borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            focusedBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              //borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            hintText: "ID bò mẹ"),
        maxLength: 10,
        validator: (String value) {
          if (value.isEmpty) {
            return 'ID bò mẹ là bắt buộc';
          }
        },
        onSaved: (String value) {
          _idmother = value;
        },
      ),
    );
  }

  Widget _buildBirthday() {
     return Padding(
      padding: EdgeInsets.only(
        top: 20.0,
      ),
      child: TextFormField(
        decoration: InputDecoration(
            contentPadding: const EdgeInsets.all(20.0),
            enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              // borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            focusedBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              //borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            hintText: "Năm sinh"),
        keyboardType: TextInputType.datetime,
        validator: (String value) {
          if (value.isEmpty) {
            return 'Năm sinh là bắt buộc';
          }
          return null;
        },
        onSaved: (String value) {
          _birthday = value;
        },
      ),
    );
  }

  Widget _buildGender(){
    return Padding(
      padding: EdgeInsets.only(
        top: 20.0,
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.end,
        children: <Widget>[
          ButtonBar(
            alignment: MainAxisAlignment.spaceAround,
            children: [
              Radio(
                value: 1, 
                groupValue: selectedRadio,
                activeColor: Color(0xFF26A69A), 
                onChanged: (val){
                  setSelectedRadio(val);
                  print("Radio $val");
                },
              ),
              Radio(
                value: 2, 
                groupValue: selectedRadio,
                activeColor: Color(0xFF26A69A),  
                onChanged: (val){
                  setSelectedRadio(val);
                  print("Radio $val");
                },
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildBreed() {
    return Padding(
      padding: EdgeInsets.only(
        top: 20.0,
      ),
      child: TextFormField(
        decoration: InputDecoration(
            enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              // borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            focusedBorder: OutlineInputBorder(
              borderSide: BorderSide(color: Color(0xFF26A69A)),
              //borderRadius: BorderRadius.all(Radius.circular(30)),
            ),
            hintText: "Giống"),
        validator: (String value) {
          if (value.isEmpty) {
            return 'Giống là bắt buộc';
          }
        },
        onSaved: (String value) {
          _breed = value;
        },
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: Color(0xFF26A69A),
          title: Text('Tạo bò'),
          actions: <Widget>[
            IconButton(
                icon: Icon(Icons.navigate_next),
                onPressed: () {
                  Navigator.push(context,
                      MaterialPageRoute(builder: (context) => ListCows()));
                }),
          ],
        ),
        body: Container(
          margin: EdgeInsets.all(24),
          child: SingleChildScrollView(
              key: _formKey,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  _buildName(),
                  _buildIdFather(),
                  _buildIdMother(),
                  _buildBreed(),
                  _buildBirthday(),
                  _buildGender(),
                  SizedBox(height: 10.0),
                  Padding(
                    padding: EdgeInsets.only(
                      top: 20.0,
                    ),
                    child: RaisedButton(
                      padding: const EdgeInsets.all(0.0),
                      child: Container(
                        decoration: const BoxDecoration(
                         color: Color(0xFF26A69A),
                        ),
                        padding: const EdgeInsets.symmetric(horizontal: 30.0, vertical: 10.0),
                        child: const Text(
                          "Tạo bò",
                          style: TextStyle(fontSize: 20, color: Colors.white),
                        ),
                      ),
                      onPressed: () {
                        if (!_formKey.currentState.validate()) {
                         _formKey.currentState.save();
                        }
                          
                        
                        // setState(() {
                        //   Navigator.of(context).push(MaterialPageRoute(
                        //     builder: (context) => ListCows(value: _namecow),
                        //   ));
                        // });
                        print(_namecow);
                        print(_idfather);
                        print(_idmother);
                        //print(_genderMale);
                        print(_breed);
                        print(_birthday);
                      },
                    ),
                  )
                ],
              ),
            ),
        ),
      ),
    );
  }
}
