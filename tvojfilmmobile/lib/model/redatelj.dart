import 'dart:convert';

class Redatelj {
  final int? redateljId;
  final String? ime;
  final String? prezime;

  Redatelj({
    this.redateljId,
    this.ime,
    this.prezime,
  });

  factory Redatelj.fromJson(Map<String, dynamic> json) {
    return Redatelj(
      redateljId: json["redateljId"],
      ime: json['ime'],
      prezime: json['prezime'],
    );
  }

  Map<String, dynamic> toJson() => {
        "redateljId": redateljId,
        "ime": ime,
        "prezime": prezime,
      };
}
