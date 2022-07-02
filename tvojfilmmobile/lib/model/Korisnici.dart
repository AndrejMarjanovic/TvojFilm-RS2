import 'dart:convert';

class Korisnici {
  final int? korisnikId;
  final String? ime;
  final String? prezime;
  final String? username;

  Korisnici({
    this.korisnikId,
    this.ime,
    this.prezime,
    this.username,
  });

  factory Korisnici.fromJson(Map<String, dynamic> json) {
    return Korisnici(
      korisnikId: json["korisnikId"],
      ime: json['ime'],
      prezime: json['prezime'],
      username: json['username'],
    );
  }

  Map<String, dynamic> toJson() => {
        "korisnikId": korisnikId,
        "ime": ime,
        "prezime": prezime,
        "username": username,
      };
}
