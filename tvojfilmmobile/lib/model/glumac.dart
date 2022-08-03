import 'dart:convert';

class Glumac {
  final int? glumacId;
  final String? ime;
  final String? prezime;

  Glumac({
    this.glumacId,
    this.ime,
    this.prezime,
  });

  factory Glumac.fromJson(Map<String, dynamic> json) {
    return Glumac(
      glumacId: json["glumacId"],
      ime: json['ime'],
      prezime: json['prezime'],
    );
  }

  Map<String, dynamic> toJson() => {
        "glumacId": glumacId,
        "ime": ime,
        "prezime": prezime,
      };
}
