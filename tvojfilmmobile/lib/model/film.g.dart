// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'film.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Film _$FilmFromJson(Map<String, dynamic> json) => Film()
  ..filmId = json['filmId'] as int?
  ..nazivFilma = json['nazivFilma'] as String?
  ..cijena = (json['cijena'] as num?)?.toDouble()
  ..ocjena = (json['ocjena'] as num?)?.toDouble()
  ..opis = json['opis'] as String?
  ..filmLink = json['filmLink'] as String?
  ..poster = json['poster'] as String?
  ..redatelj = Redatelj.fromJson(json['redatelj'])
  ..glumac = Glumac.fromJson(json['glumac'])
  ..zanr = Zanr.fromJson(json['zanr'])
  ..godina = DateTime.tryParse(json['godina']);

Map<String, dynamic> _$FilmToJson(Film instance) => <String, dynamic>{
      'filmId': instance.filmId,
      'nazivFilma': instance.nazivFilma,
      'poster': instance.poster,
      'cijena': instance.cijena,
      'ocjena': instance.ocjena,
      'filmLink': instance.filmLink,
      'opis': instance.opis,
      'redatelj': instance.redatelj,
      'glumac': instance.glumac,
      'zanr': instance.zanr,
      'godina': instance.godina
    };
