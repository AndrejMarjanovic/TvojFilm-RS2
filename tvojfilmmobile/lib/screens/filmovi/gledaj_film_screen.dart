import 'dart:ui';
import 'package:easy_localization/easy_localization.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'dart:io';
import 'dart:convert';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:tvojfilmmobile/provider/recommended_provider.dart';
import 'package:tvojfilmmobile/screens/filmovi/film_detail_screen.dart';
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
  List<Film> recommended = [];

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

  Future loadData() async {
    var Data = await _recommendedProvider?.get({'id': film!.filmId});
    setState(() {
      recommended = Data!;
    });
  }

  @override
  void initState() {
    super.initState();
    _recommendedProvider = context.read<RecommendedProvider>();

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

    loadData();
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
            body: SafeArea(
              child: Column(children: [
                player,
                const SizedBox(
                  height: 10,
                ),
                SingleChildScrollView(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Padding(
                          padding: EdgeInsets.only(left: 10.0, right: 10.0),
                          child: Align(
                              child: _buildInfo(),
                              alignment: Alignment.centerLeft)),
                      const SizedBox(
                        height: 2,
                      ),
                      Container(
                        height: 180,
                        child: GridView(
                          gridDelegate:
                              SliverGridDelegateWithFixedCrossAxisCount(
                                  crossAxisCount: 1,
                                  childAspectRatio: 4 / 3,
                                  crossAxisSpacing: 10,
                                  mainAxisSpacing: 10),
                          scrollDirection: Axis.horizontal,
                          children: _buildFilmCardList(),
                        ),
                      )
                    ],
                  ),
                ),
              ]),
            )));
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
        Text("Možda će vam se svidjeti:",
            style: TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 18,
                color: Color.fromARGB(255, 34, 67, 94))),
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
}
