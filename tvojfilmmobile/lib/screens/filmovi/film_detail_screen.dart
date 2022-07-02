import 'dart:ui';
import 'package:flutter/material.dart';
import 'dart:io';
import 'dart:convert';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/widgets/master_screen.dart';

import '../../utils/util.dart';
import '../../widgets/tvojfilm_drawer.dart';
import 'filmovi_list_screen.dart';

class FilmDetailsScreen extends StatelessWidget {
  FilmDetailsScreen({Key? key, this.film}) : super(key: key);
  final Film? film;

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        children: [
          imageFromBase64String(film!.poster!),
          Text(film!.nazivFilma!),
          Text(film!.opis!),
          Text(film!.ocjena!.toString()),
          Text(film!.cijena!.toString()),
          Text('Link ' + film!.filmLink!),
          Text(BaseProvider.korisnikID.toString()),
        ],
      ),
    );
  }
}
