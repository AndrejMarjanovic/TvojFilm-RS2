import 'dart:convert';

import 'package:tvojfilmmobile/model/Korisnici.dart';
import 'package:tvojfilmmobile/model/film.dart';

class KupnjaFilma {
  final int? kupnjaId;
  final Korisnici? korisnik;
  final Film? film;
  final DateTime? datumKupovine;

  KupnjaFilma({this.kupnjaId, this.korisnik, this.film, this.datumKupovine});

  factory KupnjaFilma.fromJson(Map<String, dynamic> json) {
    return KupnjaFilma(
      kupnjaId: json["kupnjaId"],
      korisnik: Korisnici.fromJson(json['korisnik']),
      film: Film.fromJson(json['film']),
      datumKupovine: DateTime.tryParse(json['datumKupovine']),
    );
  }

  Map<String, dynamic> toJson() => {
        "kupnjaId": kupnjaId,
        "korisnik": korisnik,
        "film": film,
        "datum": datumKupovine,
      };
}
