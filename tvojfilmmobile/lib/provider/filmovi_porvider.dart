import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:http/http.dart';
import 'package:flutter/cupertino.dart';
import 'package:http/io_client.dart';

class FilmoviProvider with ChangeNotifier {
  HttpClient client = new HttpClient();
  IOClient? http;
  FilmoviProvider() {
    print("called FilmoviProvider");
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Future<dynamic> get(dynamic searchObject) async {
    print("called FilmoviProvider.GET METHOD");
    var url = Uri.parse("https://10.0.2.2:7171/api/Filmovi");

    String username = "Admin";
    String password = "test";

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    var respose = await http!.get(url, headers: headers);

    if (respose.statusCode < 400) {
      var data = jsonDecode(respose.body);
      return data;
    } else {
      throw Exception("User not alloved");
    }
  }
}
