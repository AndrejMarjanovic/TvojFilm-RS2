import 'package:analyzer/file_system/overlay_file_system.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

import 'tvojfilm_drawer.dart';

class MasterScreenWidget extends StatelessWidget {
  Widget? child;
  MasterScreenWidget({this.child, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      drawer: tvojFilmDrawer(),
      body: SafeArea(child: child!),
    );
  }
}
