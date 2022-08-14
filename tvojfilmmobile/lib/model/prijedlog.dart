import 'dart:convert';

class Prijedlog {
  final String? prijedlogIme;
  final String? opis;
  final int? korisnikId;

  Prijedlog({this.prijedlogIme, this.opis, this.korisnikId});

  factory Prijedlog.fromJson(Map<String, dynamic> json) {
    return Prijedlog(
      prijedlogIme: json["prijedlogIme"],
      opis: json['opis'],
      korisnikId: json['korisnikId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "prijedlogIme": prijedlogIme,
        "opis": opis,
        "korisnikId": korisnikId,
      };
}
