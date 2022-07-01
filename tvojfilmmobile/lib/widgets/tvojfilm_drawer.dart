import 'package:tvojfilmmobile/model/film.dart';
//import 'package:tvojfilmmobile/providers/cart_provider.dart';
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
      child: ListView(
        children: [
          ListTile(
            title: Text('Home'),
            onTap: () {
              Navigator.popAndPushNamed(context, FilmoviListScreen.routeName);
            },
          ),
          ListTile(
            title: Text('Moja videoteka'),
            onTap: () {},
          ),
        ],
      ),
    );
  }
}
