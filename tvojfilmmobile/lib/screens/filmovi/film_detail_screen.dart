import 'package:flutter/cupertino.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:tvojfilmmobile/widgets/master_screen.dart';

class FilmDetailsScreen extends StatefulWidget {
  static const String routeName = "/Filmovi";
  String id;
  FilmDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<FilmDetailsScreen> createState() => _FilmDetailsScreenState();
}

class _FilmDetailsScreenState extends State<FilmDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(
        child: Text(this.widget.id.toString()),
      ),
    );
  }
}
