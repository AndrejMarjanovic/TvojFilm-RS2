import 'package:json_annotation/json_annotation.dart';
import 'package:tvojfilmmobile/model/redatelj.dart';

import 'glumac.dart';
import 'zanr.dart';

part 'film.g.dart';

@JsonSerializable()
class Film {
  int? filmId;
  String? nazivFilma;
  String? poster;
  double? cijena;
  double? ocjena;
  String? filmLink;
  String? opis;
  Redatelj? redatelj;
  Glumac? glumac;
  Zanr? zanr;
  DateTime? godina;

  Film() {}

  factory Film.fromJson(Map<String, dynamic> json) => _$FilmFromJson(json);

  /// Connect the generated [_$FilmToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$FilmToJson(this);
}
