import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/model/kupnja.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:http/http.dart';
import 'package:flutter/foundation.dart';
import 'package:http/io_client.dart';

import '../model/glumac.dart';

class KupnjaProvider extends BaseProvider<KupnjaFilma> {
  KupnjaProvider() : super("KupnjaFilmova");

  @override
  KupnjaFilma fromJson(data) {
    // TODO: implement fromJson
    return KupnjaFilma();
  }
}
