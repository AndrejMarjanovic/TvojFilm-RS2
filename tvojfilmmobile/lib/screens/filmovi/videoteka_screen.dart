import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/model/kupnja.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/provider/korisnici_provider.dart';
import 'package:tvojfilmmobile/utils/util.dart';
import '../../provider/kupnja_provider.dart';
import '../../widgets/tvojfilm_drawer.dart';
import 'film_detail_screen.dart';
import 'gledaj_film_screen.dart';

class VideotekaScreen extends StatefulWidget {
  const VideotekaScreen({Key? key}) : super(key: key);

  @override
  State<VideotekaScreen> createState() => _VideotekaScreenState();
}

class _VideotekaScreenState extends State<VideotekaScreen> {
  KupnjaProvider? _kupnjaProvider = null;

  List<KupnjaFilma> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _kupnjaProvider = context.read<KupnjaProvider>();
    loadData();
  }

  Future loadData() async {
    var tempData =
        await _kupnjaProvider?.get({'korisnikId': BaseProvider.korisnikID});
    setState(() {
      data = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.grey[100],
        appBar: AppBar(
          iconTheme:
              const IconThemeData(color: Color.fromARGB(255, 235, 235, 235)),
          title: Text("Moji filmovi",
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
                                  GledajFilmScreen(film: x.film!)));
                    },
                    child: Container(
                      height: 150,
                      child: imageFromBase64String(x.film!.poster!),
                    ),
                  ),
                  const SizedBox(
                    height: 3,
                  ),
                  Text(
                    x.film!.nazivFilma ?? "",
                    style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Color.fromARGB(255, 34, 67, 94)),
                  ),
                  Text(
                    "GLEDAJ",
                    style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Color.fromARGB(255, 41, 125, 194)),
                  ),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();
    return list;
  }
}
