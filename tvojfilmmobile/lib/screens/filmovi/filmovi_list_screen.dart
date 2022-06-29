import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:provider/provider.dart';

class FilmoviListScreen extends StatefulWidget {
  static const String routeName = "/filmovi";
  const FilmoviListScreen({Key? key}) : super(key: key);

  @override
  State<FilmoviListScreen> createState() => _FilmoviListScreenState();
}

class _FilmoviListScreenState extends State<FilmoviListScreen> {
  FilmoviProvider? _filmoviProvider = null;
  dynamic data = {};

  @override
  void initState() {
    super.initState();
    _filmoviProvider = context.read<FilmoviProvider>();

    print("called init state");
    loadData();
  }

  Future loadData() async {
    var tempData = await _filmoviProvider?.get(null);
    setState(() {
      data = tempData;
    });
  }

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return Scaffold(
      body: Center(child: Text(data!.length.toString())),
    );
  }
}
