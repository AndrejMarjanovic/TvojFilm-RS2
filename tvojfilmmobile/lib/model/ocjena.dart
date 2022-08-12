import 'dart:convert';

class Ocjena {
  final int? filmOcjenaId;
  final double? ocjena;
  final int? korisnikId;
  final int? filmId;

  Ocjena({this.ocjena, this.korisnikId, this.filmId, this.filmOcjenaId});

  factory Ocjena.fromJson(Map<String, dynamic> json) {
    return Ocjena(
      filmOcjenaId: json['filmOcjenaId'],
      ocjena: (json['ocjena'] as num?)?.toDouble(),
      korisnikId: json['korisnikId'],
      filmId: json['filmId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "filmOcjenaId": filmOcjenaId,
        "ocjena": ocjena,
        "korisnikId": korisnikId,
        "filmId": filmId,
      };
}
