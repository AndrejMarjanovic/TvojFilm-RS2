import 'dart:ui';
import 'package:easy_localization/easy_localization.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';
import 'dart:io';
import 'dart:convert';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/model/komentari.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:tvojfilmmobile/provider/komentari_provider.dart';
import 'package:tvojfilmmobile/provider/recommended_provider.dart';
import 'package:tvojfilmmobile/screens/filmovi/film_detail_screen.dart';
import 'package:tvojfilmmobile/widgets/alert_dialog_widget.dart';
import 'package:tvojfilmmobile/widgets/master_screen.dart';
import 'package:youtube_player_flutter/youtube_player_flutter.dart';
import '../../utils/util.dart';

class GledajFilmScreen extends StatefulWidget {
  const GledajFilmScreen({Key? key, this.film}) : super(key: key);
  final Film? film;
  @override
  State<GledajFilmScreen> createState() => _GledajFilmScreenState(film);
}

class _GledajFilmScreenState extends State<GledajFilmScreen> {
  final Film? film;
  RecommendedProvider? _recommendedProvider = null;
  KomentariProvider? _komentariProvider = null;

  TextEditingController _commentController = TextEditingController();

  List<Film> recommended = [];
  List<Komentar> komentari = [];
  var datum = DateFormat('MMM d, yyyy' '  ' 'HH' ':' 'mm');

  late YoutubePlayerController controller;

  _GledajFilmScreenState(this.film);

  @override
  void deactivate() {
    controller.pause();
    super.deactivate();
  }

  @override
  void dispose() {
    controller.dispose();
    super.dispose();
  }

  Future loadRecommended() async {
    var Recommended = await _recommendedProvider?.get({'id': film!.filmId});
    setState(() {
      recommended = Recommended!;
    });
  }

  Future loadComments() async {
    var Komentari = await _komentariProvider?.get({'filmId': film!.filmId});
    setState(() {
      komentari = Komentari!.reversed.toList();
    });
  }

  @override
  void initState() {
    super.initState();
    _recommendedProvider = context.read<RecommendedProvider>();
    _komentariProvider = context.read<KomentariProvider>();

    var url = film!.filmLink!;
    var video = YoutubePlayer.convertUrlToId(url);
    if (video != null) {
      controller = YoutubePlayerController(
          initialVideoId: video,
          flags: const YoutubePlayerFlags(autoPlay: false));
    } else {
      const url2 = 'https://www.youtube.com/watch?v=YoHD9XEInc0';
      var videoAlt = YoutubePlayer.convertUrlToId(url2);
      controller = YoutubePlayerController(
          initialVideoId: videoAlt!,
          flags: const YoutubePlayerFlags(autoPlay: false));
    }

    loadRecommended();
    loadComments();
  }

  @override
  Widget build(BuildContext context) {
    return YoutubePlayerBuilder(
        player: YoutubePlayer(
          controller: controller,
        ),
        builder: (context, player) => Scaffold(
              backgroundColor: Colors.grey[100],
              appBar: AppBar(
                iconTheme: const IconThemeData(
                    color: Color.fromARGB(255, 235, 235, 235)),
                title: Text(film!.nazivFilma!,
                    style: const TextStyle(
                        color: Color.fromARGB(255, 235, 235, 235))),
                backgroundColor: Color.fromARGB(255, 21, 84, 136),
                centerTitle: true,
                elevation: 0.0,
              ),
              body: Column(
                children: <Widget>[
                  player,
                  Padding(
                      padding: EdgeInsets.only(left: 10.0, right: 10.0),
                      child: Align(
                          child: _buildInfo(),
                          alignment: Alignment.centerLeft)),
                  _buildPage(),
                ],
              ),
            ));
  }

  Expanded _buildPage() {
    return Expanded(
        child: SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text("Možda vam se svidi:",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 18,
                  color: Color.fromARGB(255, 34, 67, 94))),
          const SizedBox(
            height: 6,
          ),
          const SizedBox(
            height: 2,
          ),
          Container(
              height: 180,
              child: GridView(
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 1,
                    childAspectRatio: 4 / 3,
                    crossAxisSpacing: 10,
                    mainAxisSpacing: 10),
                scrollDirection: Axis.horizontal,
                children: _buildFilmCardList(),
              )),
          const SizedBox(
            height: 6,
          ),
          _buildComment(),
          const SizedBox(
            height: 6,
          ),
          Align(
              child: Text("Komentari:",
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 18,
                      color: Color.fromARGB(255, 34, 67, 94))),
              alignment: Alignment.centerLeft),
          const SizedBox(
            height: 6,
          ),
          Container(
            height: 200,
            child: GridView(
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 1,
                  childAspectRatio: 4 / 1,
                  crossAxisSpacing: 10,
                  mainAxisSpacing: 10),
              scrollDirection: Axis.vertical,
              children: _buildCommentList(),
            ),
          ),
        ],
      ),
    ));
  }

  Column _buildInfo() {
    return Column(
      children: [
        Text(film!.nazivFilma!,
            textAlign: TextAlign.left,
            style: const TextStyle(
              fontSize: 22,
              fontWeight: FontWeight.bold,
              color: Color.fromARGB(255, 34, 67, 94),
            )),
        const SizedBox(
          height: 6,
        ),
      ],
    );
  }

  List<Widget> _buildFilmCardList() {
    if (recommended.length == 0) {
      return [Text("Loading....")];
    }

    List<Widget> list = recommended
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
                        fontSize: 12,
                        color: Color.fromARGB(255, 34, 67, 94)),
                  ),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();
    return list;
  }

  List<Widget> _buildCommentList() {
    if (komentari.length == 0) {
      return [Text("Za sada nema komentara na ovaj film...")];
    }

    List<Widget> list = komentari
        .map((x) => Container(
              color: Color.fromARGB(255, 219, 219, 219),
              child: Column(
                children: [
                  Align(
                      child: Text(x.korisnik!.username!,
                          style: const TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 16,
                              color: Color.fromARGB(255, 34, 67, 94))),
                      alignment: Alignment.centerLeft),
                  const SizedBox(
                    height: 3,
                  ),
                  Align(
                      child: Text(x.komentar!,
                          style: const TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 14,
                              color: Color.fromARGB(255, 12, 14, 15))),
                      alignment: Alignment.centerLeft),
                  const SizedBox(
                    height: 3,
                  ),
                  Align(
                      child: Text(datum.format(x.datumKomentara!),
                          style: const TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 10,
                              color: Color.fromARGB(255, 73, 73, 73))),
                      alignment: Alignment.centerLeft),
                  const SizedBox(
                    height: 3,
                  ),
                ],
              ),
              width: MediaQuery.of(context).size.width,
            ))
        .cast<Widget>()
        .toList();
    return list;
  }

  Widget _buildComment() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _commentController,
              inputFormatters: [LengthLimitingTextInputFormatter(200)],
              onSubmitted: (value) async {
                Map comment = {
                  "komentar": value.toString(),
                  "korisnikId": BaseProvider.korisnikID,
                  "filmId": film!.filmId,
                };

                try {
                  await _komentariProvider!.insert(comment);
                  var tempData =
                      await _komentariProvider?.get({'filmId': film!.filmId});
                  setState(() {
                    _commentController.clear();
                    komentari = tempData!.reversed.toList();
                  });
                } catch (e) {
                  showDialog(
                      context: context,
                      builder: (BuildContext dialogContex) => AlertDialogWidget(
                            title: "Error",
                            message: "An error occured!",
                            context: dialogContex,
                          ));
                }
              },
              decoration: InputDecoration(
                  hintText: "Komentiraj",
                  suffixIcon: Icon(Icons.comment),
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
}
