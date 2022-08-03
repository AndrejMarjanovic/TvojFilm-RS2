import 'dart:convert';

class Zanr {
  final int? zanrId;
  final String? naziv;

  Zanr({
    this.zanrId,
    this.naziv,
  });

  factory Zanr.fromJson(Map<String, dynamic> json) {
    return Zanr(
      zanrId: json["glumacId"],
      naziv: json['naziv'],
    );
  }

  Map<String, dynamic> toJson() => {
        "zanrId": zanrId,
        "naziv": naziv,
      };
}
