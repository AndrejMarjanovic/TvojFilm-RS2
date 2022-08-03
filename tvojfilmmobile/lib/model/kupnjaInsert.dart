import 'dart:convert';

import 'package:tvojfilmmobile/model/Korisnici.dart';
import 'package:tvojfilmmobile/model/film.dart';

class KupnjaFilmaInsert {
  int? korisnikId;
  int? filmId;

  KupnjaFilmaInsert({this.korisnikId, this.filmId});

  factory KupnjaFilmaInsert.fromJson(Map<String, dynamic> json) {
    return KupnjaFilmaInsert(
      korisnikId: json["korisnikId"] as int?,
      filmId: json["filmId"] as int?,
    );
  }

  Map<String, dynamic> toJson() => {
        "korisnikId": korisnikId,
        "filmId": filmId,
      };
}
