import 'package:AgrifoodApp/byre/model/breed_item.dart';
import 'package:AgrifoodApp/byre/model/breed_model.dart';
import 'package:AgrifoodApp/cow/cow_manager/bloc/cow_bloc.dart';
import 'package:AgrifoodApp/cow/cow_manager/model/cow_item.dart';
import 'package:AgrifoodApp/home/bloc/home_cubit.dart';
import 'package:AgrifoodApp/home/component/appdrawer.dart';
import 'package:AgrifoodApp/home/component/categorie.dart';
import 'package:AgrifoodApp/home/component/custom_clippath.dart';
import 'package:AgrifoodApp/home/component/dashboard.dart';
import 'package:AgrifoodApp/home/component/dialog_create_cow.dart';
import 'package:AgrifoodApp/home/component/floatingbar.dart';
import 'package:AgrifoodApp/home/component/notification.dart';
import 'package:AgrifoodApp/home/component/total_cow_page.dart';
import 'package:AgrifoodApp/home/model/farmer_model.dart';
import 'package:AgrifoodApp/notification/bloc/notification_cubit.dart';
import 'package:AgrifoodApp/respository/byre_repository.dart';
import 'package:AgrifoodApp/respository/cow_repository.dart';
import 'package:AgrifoodApp/respository/foodSuggestion_repository.dart';
import 'package:AgrifoodApp/respository/notification_repository.dart';
import 'package:AgrifoodApp/ui/splash_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class MyHomePage extends StatefulWidget {
  final FarmerInfoModel farmerInfoModel;

  const MyHomePage({Key key, this.farmerInfoModel}) : super(key: key);
  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  // @override
  // bool get wantKeepAlive => true;

  ScrollController controller = ScrollController();
  TabController _tabController;
  int _selectedIndex = 0;
  ByreRepository byreRepository = new ByreRepository();
  CowRepository cowRepository = new CowRepository();
  NotificationRepository notificationRepository = new NotificationRepository();
  FoodSuggestionRepository foodSuggestionRepository =
      new FoodSuggestionRepository();
  List<CowItem> responseList = new List<CowItem>();
  List<BreedItem> listBreed = List<BreedItem>();
  int breedId;
  String breedName;

  bool closeTopContainer = false;
  double topContainer = 0;
  bool dialVisible = true;

  List<Widget> itemsData = [];
  void getListBreed() async {
    BreedModel breedModel = await byreRepository.getListBreeds();
    listBreed = breedModel.breedItem;
  }

  void getPostsData() {
    List<Widget> listItems = [];
    responseList.forEach((post) {
      listItems.add(Container(
          height: 150,
          margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          decoration: BoxDecoration(
              borderRadius: BorderRadius.all(Radius.circular(20.0)),
              color: Colors.white,
              boxShadow: [
                BoxShadow(color: Colors.black.withAlpha(100), blurRadius: 10.0),
              ]),
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 20.0, vertical: 10),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: <Widget>[
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Text(
                      post.name,
                      style: const TextStyle(
                          fontSize: 28, fontWeight: FontWeight.bold),
                    ),
                    Text(
                      post.byreName,
                      style: const TextStyle(fontSize: 17, color: Colors.grey),
                    ),
                    SizedBox(
                      height: 10,
                    ),
                    Text(
                      post.gender,
                      style: const TextStyle(
                          fontSize: 25,
                          color: Colors.black,
                          fontWeight: FontWeight.bold),
                    )
                  ],
                ),
                Image.asset(
                  "assets/layout/cowmale.png}",
                  height: double.infinity,
                )
              ],
            ),
          )));
    });
    setState(() {
      itemsData = listItems;
    });
  }

  @override
  void initState() {
    super.initState();
    this.getListBreed();
    getPostsData();
    controller.addListener(() {
      double value = controller.offset / 119;
      setState(() {
        topContainer = value;
        closeTopContainer = controller.offset > 50;
      });
    });
  }

  void checkAmountByreFirst(BuildContext context) {
    final byreCubit = context.watch<HomeCubit>();
    byreCubit.checkAmountByre(widget.farmerInfoModel);
  }

  void getListCount(BuildContext context) {
    final byreCubit = context.watch<HomeCubit>();
    byreCubit.getListCow();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    final double categoryHeight = size.height / 4.2;
    return BlocConsumer<HomeCubit, HomeState>(listener: (context, state) {
      if (state is CheckByreLoaded) {
        if (state.amonth == 0) {
          showDialog(context: context, builder: (_) => DialogCreateCow());
        }
      }
    }, builder: (context, state) {
      if (state is HomeInitial) {
        checkAmountByreFirst(context);
      }
      if (state is CheckByreLoaded) {
        int byreLength = state.amonth;
        int cowLength = state.cowLength;
        return SafeArea(
          child: Scaffold(
            backgroundColor: Colors.white,
            floatingActionButton: buildSpeedDial(
                context: context, farmerId: widget.farmerInfoModel.id),
            drawer: AppDrawer(
              farmerInfoModel: widget.farmerInfoModel ??
                  FarmerInfoModel(
                      name: "", avatarURL: "", gender: false, status: false),
              contextHome: context,
            ),
            appBar: AppBar(
              elevation: 0,
              title: Text('Trang chủ'),
              backgroundColor: Color(0xff9CCC65),
              actions: <Widget>[
                IconButton(
                  icon: Icon(Icons.notifications, color: Colors.black),
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => BlocProvider(
                            create: (context) =>
                                NotificationCubit(notificationRepository),
                            child: PopupNotification(
                              
                            ),
                          ),
                        ));
                  },
                )
              ],
            ),
            body: Stack(
              children: [
                ClipPath(
                  child: Container(
                    width: ScreenUtil().screenWidth,
                    height: ScreenUtil().setHeight(1000),
                    color: Color(0xff9CCC65),
                  ),
                  clipper: CustomClipPathByHomePage(),
                ),
                Column(
                  children: [
                    Container(
                      height: categoryHeight,
                      child: CategoriesScroller(
                        byreLength: byreLength,
                        cowLength: cowLength,
                      ),
                    ),
                    BlocProvider(
                      create: (context) =>
                          HomeCubit(byreRepository, cowRepository),
                      child: Dashboard(
                        contextHome: context,
                        farmerInfoModel: widget.farmerInfoModel,
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ),
        );
      }
      return SplashPage();
    });
  }
}
