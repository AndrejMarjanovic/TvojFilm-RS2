import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:http/http.dart';
import 'package:flutter/foundation.dart';
import 'package:http/io_client.dart';

class FilmoviProvider extends BaseProvider<Film> {
  FilmoviProvider() : super("Filmovi");

  @override
  Film fromJson(data) {
    // TODO: implement fromJson
    return Film.fromJson(data);
  }
}
