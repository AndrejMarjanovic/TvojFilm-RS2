import 'package:tvojfilmmobile/model/film.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/screens/filmovi/filmovi_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

//import '../screens/cart/cart_screen.dart';

class tvojFilmDrawer extends StatelessWidget {
  tvojFilmDrawer({Key? key}) : super(key: key);
  // CartProvider? _cartProvider;
  @override
  Widget build(BuildContext context) {
    //_cartProvider = context.watch<CartProvider>();
    print("called build drawer");
    return Drawer(
      backgroundColor: Color.fromARGB(255, 21, 84, 136),
      child: ListView(
        children: [
          ListTile(
            title: Text('HOME',
                style: TextStyle(color: Color.fromARGB(255, 212, 215, 221))),
            onTap: () {
              Navigator.of(context).pushReplacementNamed('/Films');
            },
          ),
          ListTile(
            title: Text('Moja videoteka',
                style: TextStyle(color: Color.fromARGB(255, 212, 215, 221))),
            onTap: () {
              Navigator.of(context).pushReplacementNamed('/Videoteka');
            },
          ),
          ListTile(
            title: Text('Odjava',
                style: TextStyle(color: Color.fromARGB(255, 69, 151, 218))),
            onTap: () {
              Navigator.of(context).pushReplacementNamed('/LogOut');
            },
          ),
        ],
      ),
    );
  }
}
