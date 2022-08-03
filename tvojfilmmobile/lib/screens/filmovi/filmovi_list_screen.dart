import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/provider/korisnici_provider.dart';
import 'package:tvojfilmmobile/utils/util.dart';
import 'package:tvojfilmmobile/widgets/master_screen.dart';
import 'package:tvojfilmmobile/screens/filmovi/filmovi_list_screen.dart';

import '../../model/Korisnici.dart';
import '../../widgets/tvojfilm_drawer.dart';
import 'film_detail_screen.dart';

class FilmoviListScreen extends StatefulWidget {
  // static const String routeName = "/Filmovi";
  const FilmoviListScreen({Key? key}) : super(key: key);

  @override
  State<FilmoviListScreen> createState() => _FilmoviListScreenState();
}

class _FilmoviListScreenState extends State<FilmoviListScreen> {
  FilmoviProvider? _filmoviProvider = null;
  KorisniciProvider? _korisniciProvider = null;
  List<Film> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _filmoviProvider = context.read<FilmoviProvider>();
    _korisniciProvider = context.read<KorisniciProvider>();
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
        backgroundColor: Colors.grey[100],
        appBar: AppBar(
          iconTheme:
              const IconThemeData(color: Color.fromARGB(255, 235, 235, 235)),
          title: Text("Dostupni filmovi",
              style:
                  const TextStyle(color: Color.fromARGB(255, 235, 235, 235))),
          backgroundColor: Color.fromARGB(255, 21, 84, 136),
          centerTitle: true,
          elevation: 0.0,
        ),
        drawer: tvojFilmDrawer(),
        body: SafeArea(
          child: SingleChildScrollView(
            child: Container(
              padding: EdgeInsets.only(left: 8, right: 8),
              child: Column(
                children: [
                  const SizedBox(
                    height: 6,
                  ),
                  _buildFilmoviSearch(),
                  const SizedBox(
                    height: 6,
                  ),
                  Container(
                    height: MediaQuery.of(context).size.height -
                        MediaQuery.of(context).size.height / 3,
                    //height: 550,
                    child: GridView(
                      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                          crossAxisCount: 2,
                          childAspectRatio: 3 / 3,
                          crossAxisSpacing: 10,
                          mainAxisSpacing: 10),
                      scrollDirection: Axis.vertical,
                      children: _buildFilmCardList(),
                    ),
                  )
                ],
              ),
            ),
          ),
        ));
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
                  InkWell(
                    onTap: () {
                      Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) =>
                                  FilmDetailsScreen(film: x)));
                    },
                    child: Container(
                      height: 150,
                      child: imageFromBase64String(x.poster!),
                    ),
                  ),
                  const SizedBox(
                    height: 3,
                  ),
                  Text(
                    x.nazivFilma ?? "",
                    style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Color.fromARGB(255, 34, 67, 94)),
                  ),
                  Text(formatNumber(x.cijena) + ("  KM")),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();
    return list;
  }
}
