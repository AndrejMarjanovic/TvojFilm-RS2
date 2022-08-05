import 'dart:ui';
import 'package:easy_localization/easy_localization.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'dart:io';
import 'dart:convert';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
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

  late YoutubePlayerController controller;

  var formatter = NumberFormat('###.0#');
  var godina = DateFormat('yyyy');

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

  @override
  void initState() {
    super.initState();
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
              child: SingleChildScrollView(
                  child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  player,
                  const SizedBox(
                    height: 10,
                  ),
                  Container(child: _buildFilmInformation()),
                  const SizedBox(
                    height: 10,
                  ),
                ],
              )),
            )));
  }

  Column _buildFilmInformation() {
    return Column(
      children: [
        Text(
          film!.nazivFilma!,
          style: const TextStyle(
              fontSize: 22,
              fontWeight: FontWeight.bold,
              color: Color.fromARGB(255, 34, 67, 94)),
        ),
        const SizedBox(
          height: 6,
        ),
        const SizedBox(
          height: 6,
        ),
        Text("Redatelj: ${film!.redatelj!.ime!} ${film!.redatelj!.prezime!}",
            style: const TextStyle(fontSize: 16)),
        const SizedBox(
          height: 6,
        ),
        Text("Glavna uloga: ${film!.glumac!.ime!} ${film!.glumac!.prezime!}",
            style: const TextStyle(fontSize: 16)),
        const SizedBox(
          height: 6,
        ),
        Text("Godina: ${godina.format(film!.godina!)}.",
            style: const TextStyle(fontSize: 16)),
        const SizedBox(
          height: 6,
        ),
        Text("Ocjena: ${formatter.format(film!.ocjena!)}",
            style: const TextStyle(fontSize: 16)),
        const SizedBox(
          height: 6,
        )
      ],
    );
  }
}
