import 'dart:convert';

import 'package:tvojfilmmobile/model/Korisnici.dart';

class Komentar {
  final int? filmKomentarId;
  final String? komentar;
  final DateTime? datumKomentara;
  final int? korisnikId;
  final Korisnici? korisnik;
  final int? filmId;

  Komentar(
      {this.filmKomentarId,
      this.komentar,
      this.korisnikId,
      this.korisnik,
      this.filmId,
      this.datumKomentara});

  factory Komentar.fromJson(Map<String, dynamic> json) {
    return Komentar(
      filmKomentarId: json["filmKomentarId"],
      komentar: json['komentar'],
      datumKomentara: DateTime.tryParse(json['datumKomentara']),
      korisnikId: json['korisnikId'],
      korisnik: Korisnici.fromJson(json['korisnik']),
      filmId: json['filmId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "filmKomentarId": filmKomentarId,
        "komentar": komentar,
        "datumKomentara": datumKomentara,
        "korisnikId": korisnikId,
        "korisnik": korisnik,
        "filmId": filmId,
      };
}
