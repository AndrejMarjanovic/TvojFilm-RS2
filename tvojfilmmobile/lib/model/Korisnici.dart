import 'dart:convert';

class Korisnici {
  final int? korisnikId;
  final String? ime;
  final String? prezime;
  final String? username;
  final String? email;
  final String? telefon;
  final DateTime? datumRodjenja;
  final int? gradId;
  final int? ulogaId;

  Korisnici({
    this.korisnikId,
    this.ime,
    this.prezime,
    this.username,
    this.email,
    this.telefon,
    this.datumRodjenja,
    this.gradId,
    this.ulogaId,
  });

  factory Korisnici.fromJson(Map<String, dynamic> json) {
    return Korisnici(
      korisnikId: json["korisnikId"],
      ime: json['ime'],
      prezime: json['prezime'],
      username: json['username'],
      email: json['email'],
      telefon: json['telefon'],
      datumRodjenja: DateTime.tryParse(json['datumRodjenja']),
      gradId: json['gradId'],
      ulogaId: json['ulogaId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "korisnikId": korisnikId,
        "ime": ime,
        "prezime": prezime,
        "username": username,
        "email": email,
        "telefon": telefon,
        "datumRodjenja": datumRodjenja,
        "gradId": gradId,
        "ulogaId": ulogaId,
      };
}
