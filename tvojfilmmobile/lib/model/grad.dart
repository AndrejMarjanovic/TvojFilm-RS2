import 'dart:convert';

class Grad {
  final int? gradId;
  final String? naziv;

  Grad({
    this.gradId,
    this.naziv,
  });

  factory Grad.fromJson(Map<String, dynamic> json) {
    return Grad(
      gradId: json["gradId"],
      naziv: json['naziv'],
    );
  }

  Map<String, dynamic> toJson() => {
        "gradId": gradId,
        "naziv": naziv,
      };
}
