import 'package:json_annotation/json_annotation.dart';

part 'film.g.dart';

@JsonSerializable()
class Film {
  int? filmId;
  String? nazivFilma;
  String? poster;
  num? cijena;
  num? ocjena;
  String? filmLink;
  String? opis;

  Film() {}

  factory Film.fromJson(Map<String, dynamic> json) => _$FilmFromJson(json);

  /// Connect the generated [_$FilmToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$FilmToJson(this);
}
