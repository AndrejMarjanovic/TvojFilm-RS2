import 'dart:ui';
import 'package:analyzer/file_system/overlay_file_system.dart';
import 'package:easy_localization/easy_localization.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'dart:io';
import 'dart:convert';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:tvojfilmmobile/provider/glumci_provider.dart';
import 'package:tvojfilmmobile/screens/placanje/kupnja_filma.dart';
import 'package:tvojfilmmobile/widgets/master_screen.dart';

import '../../model/glumac.dart';
import '../../utils/util.dart';
import '../../widgets/tvojfilm_drawer.dart';
import 'filmovi_list_screen.dart';

class FilmDetailsScreen extends StatefulWidget {
  const FilmDetailsScreen({Key? key, this.film}) : super(key: key);
  final Film? film;
  @override
  State<FilmDetailsScreen> createState() => _FilmDetailsScreenState(film);
}

class _FilmDetailsScreenState extends State<FilmDetailsScreen> {
  FilmoviProvider? _filmProvider = null;
  final Film? film;

  var formatter = NumberFormat('###.0#');
  var godina = DateFormat('yyyy');

  _FilmDetailsScreenState(this.film);

  @override
  void initState() {
    _filmProvider = context.read<FilmoviProvider>();

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.grey[100],
        appBar: AppBar(
          iconTheme:
              const IconThemeData(color: Color.fromARGB(255, 235, 235, 235)),
          title: Text(film!.nazivFilma!,
              style:
                  const TextStyle(color: Color.fromARGB(255, 235, 235, 235))),
          backgroundColor: Color.fromARGB(255, 21, 84, 136),
          centerTitle: true,
          elevation: 0.0,
        ),
        body: SafeArea(
          child: SingleChildScrollView(
              child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(
                  padding: const EdgeInsets.only(top: 5),
                  child: Center(child: imageFromBase64String(film!.poster!))),
              const SizedBox(
                height: 10,
              ),
              Center(child: _buildFilmInformation()),
              const SizedBox(
                height: 10,
              ),
              _buildFilmDescriptionContainer(),
              const SizedBox(
                height: 10,
              ),
              Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const SizedBox(width: 15.0),
                    Expanded(
                      child: Container(
                        height: 50,
                        margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          gradient: LinearGradient(colors: [
                            Color.fromARGB(255, 21, 84, 136),
                            Color.fromARGB(255, 35, 57, 75)
                          ]),
                        ),
                        child: InkWell(
                          onTap: () {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) =>
                                        KupnjaFilmaScreen(film: film)));
                          },
                          child: Center(
                              child: Text("Kupi",
                                  style: TextStyle(
                                      color: Color.fromARGB(255, 221, 220, 226),
                                      fontWeight: FontWeight.bold))),
                        ),
                      ),
                    ),
                  ]),
              const SizedBox(
                height: 16,
              ),
            ],
          )),
        ));
  }

  Column _buildFilmInformation() {
    return Column(
      children: [
        const SizedBox(
          height: 6,
        ),
        const SizedBox(
          height: 6,
        ),
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
        Text(
          "Cijena: ${formatter.format(film!.cijena!)} KM",
          style: const TextStyle(
              fontSize: 18,
              fontWeight: FontWeight.bold,
              color: Color.fromARGB(255, 34, 67, 94)),
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
        Text("Žanr: ${film!.zanr!.naziv!}",
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

  Container _buildFilmDescriptionContainer() {
    return Container(
      padding: const EdgeInsets.only(left: 7, right: 7, bottom: 10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            "Kratki opis:",
            style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
                color: Color.fromARGB(255, 34, 67, 94)),
            textAlign: TextAlign.left,
          ),
          Text(
            film!.opis!,
            style: const TextStyle(fontSize: 16),
            textAlign: TextAlign.center,
          ),
        ],
      ),
    );
  }
}
