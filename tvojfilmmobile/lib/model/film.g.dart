// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'film.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Film _$FilmFromJson(Map<String, dynamic> json) => Film()
  ..filmId = json['filmId'] as int?
  ..nazivFilma = json['nazivFilma'] as String?
  ..cijena = json['cijena'] as num?
  ..ocjena = json['ocjena'] as num?
  ..poster = json['poster'] as String?;

Map<String, dynamic> _$FilmToJson(Film instance) => <String, dynamic>{
      'filmId': instance.filmId,
      'nazivFilma': instance.nazivFilma,
      'poster': instance.poster,
      'cijena': instance.cijena,
      'ocjena': instance.ocjena,
    };
