import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/model/komentari.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:http/http.dart';
import 'package:flutter/foundation.dart';
import 'package:http/io_client.dart';

class KomentariProvider extends BaseProvider<Komentar> {
  KomentariProvider() : super("FilmoviKomentari");

  @override
  Komentar fromJson(data) {
    // TODO: implement fromJson
    return Komentar.fromJson(data);
  }
}
