import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/utils/util.dart';

class FilmoviListScreen extends StatefulWidget {
  static const String routeName = "/Filmovi";
  const FilmoviListScreen({Key? key}) : super(key: key);

  @override
  State<FilmoviListScreen> createState() => _FilmoviListScreenState();
}

class _FilmoviListScreenState extends State<FilmoviListScreen> {
  FilmoviProvider? _filmoviProvider = null;
  List<Film> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _filmoviProvider = context.read<FilmoviProvider>();

    print("called init state");
    loadData();
  }

  Future loadData() async {
    var tempData = await _filmoviProvider?.get(null);
    setState(() {
      data = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          child: Container(
            child: Column(
              children: [
                _buildHeader(),
                _buildFilmoviSearch(),
                Container(
                  height: 500,
                  child: GridView(
                    gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2,
                        childAspectRatio: 3 / 3,
                        crossAxisSpacing: 20,
                        mainAxisSpacing: 30),
                    scrollDirection: Axis.vertical,
                    children: _buildFilmCardList(),
                  ),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text(
        "Dostupni filmovi",
        style: TextStyle(
            color: Color.fromARGB(255, 21, 84, 136),
            fontSize: 30,
            fontWeight: FontWeight.bold),
      ),
    );
  }

  Widget _buildFilmoviSearch() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tempData =
                    await _filmoviProvider?.get({'nazivFilma': value});
                setState(() {
                  data = tempData!;
                });
              },
              onChanged: (value) async {
                var tempData =
                    await _filmoviProvider?.get({'nazivFilma': value});
                setState(() {
                  data = tempData!;
                });
              },
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: Icon(Icons.search),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide:
                          BorderSide(color: Color.fromARGB(255, 21, 84, 136)))),
            ),
          ),
        ),
      ],
    );
  }

  List<Widget> _buildFilmCardList() {
    if (data.length == 0) {
      return [Text("Loading....")];
    }

    List<Widget> list = data
        .map((x) => Container(
              child: Column(
                children: [
                  Container(
                    height: 150,
                    child: imageFromBase64String(x.poster!),
                  ),
                  Text(x.nazivFilma ?? ""),
                  Text(formatNumber(x.cijena) + ("  KM")),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
