import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/provider/filmovi_porvider.dart';
import 'package:tvojfilmmobile/provider/gradovi_provider.dart';
import 'package:tvojfilmmobile/provider/komentari_provider.dart';
import 'package:tvojfilmmobile/provider/korisnici_provider.dart';
import 'package:tvojfilmmobile/provider/kupnja_insert_provider.dart';
import 'package:tvojfilmmobile/provider/kupnja_provider.dart';
import 'package:tvojfilmmobile/provider/ocjene_provider.dart';
import 'package:tvojfilmmobile/provider/recommended_provider.dart';
import 'package:tvojfilmmobile/provider/registracija_provider.dart';
import 'package:tvojfilmmobile/screens/filmovi/film_detail_screen.dart';
import 'package:tvojfilmmobile/screens/filmovi/filmovi_list_screen.dart';
import 'package:tvojfilmmobile/screens/filmovi/videoteka_screen.dart';
import 'package:tvojfilmmobile/screens/korisnik/registracija_screen.dart';
import 'package:tvojfilmmobile/screens/korisnik/uredi_korisnika_screen.dart';
import 'package:tvojfilmmobile/utils/util.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => FilmoviProvider()),
        ChangeNotifierProvider(create: (_) => KorisniciProvider()),
        ChangeNotifierProvider(create: (_) => RegistracijaProvider()),
        ChangeNotifierProvider(create: (_) => KupnjaInsertProvider()),
        ChangeNotifierProvider(create: (_) => KupnjaProvider()),
        ChangeNotifierProvider(create: (_) => RecommendedProvider()),
        ChangeNotifierProvider(create: (_) => OcjeneProvider()),
        ChangeNotifierProvider(create: (_) => GradoviProvider()),
        ChangeNotifierProvider(create: (_) => KomentariProvider())
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        theme: ThemeData(
          // Define the default brightness and colors.
          brightness: Brightness.light,
          primaryColor: Color.fromARGB(255, 21, 84, 136),

          // Define the default `TextTheme`. Use this to specify the default
          // text styling for headlines, titles, bodies of text, and more.
          textTheme: const TextTheme(
            headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
            headline6: TextStyle(fontSize: 36.0),
            bodyText2: TextStyle(fontSize: 14.0),
          ),
        ),
        home: HomePage(),
        initialRoute: '/',
        routes: {
          '/Films': (context) => FilmoviListScreen(),
          '/Details': (context) => FilmDetailsScreen(),
          '/Videoteka': (context) => VideotekaScreen(),
          '/LogOut': (context) => HomePage(),
          '/Registracija': (context) => RegistracijaScreen(),
          '/UrediProfil': (context) => UrediKorisnikaScreen(),
        },
      ),
    ));

class HomePage extends StatelessWidget {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordcontroller = TextEditingController();
  late KorisniciProvider _korisniciProvider;

  @override
  Widget build(BuildContext context) {
    _korisniciProvider = context.read<KorisniciProvider>();

    final txtRegistracija = InkWell(
      child: const Text(
        "Kreirajte ga!",
        style: TextStyle(
            fontSize: 20.0,
            fontWeight: FontWeight.w500,
            color: Color.fromARGB(255, 21, 84, 136)),
      ),
      onTap: () async {
        Navigator.of(context).pushReplacementNamed('/Registracija');
      },
    );

    return Scaffold(
      appBar: AppBar(
        title: Text("TvojFilm"),
        backgroundColor: Color.fromARGB(255, 21, 84, 136),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 300,
              decoration: BoxDecoration(
                  image: DecorationImage(
                      image: AssetImage("assets/background.png"),
                      fit: BoxFit.fill)),
              child: Stack(children: [
                Positioned(
                    left: 120,
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container()),
                Positioned(
                    right: 40,
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container()),
                Container(
                  child: Center(
                      child: Stack(
                    children: [
                      // The text border
                      Text(
                        'Login',
                        style: TextStyle(
                          fontSize: 50,
                          fontWeight: FontWeight.bold,
                          foreground: Paint()
                            ..style = PaintingStyle.stroke
                            ..strokeWidth = 3
                            ..color = Color.fromARGB(255, 34, 67, 94),
                        ),
                      ),
                      // The text inside
                      const Text(
                        'Login',
                        style: TextStyle(
                          fontSize: 50,
                          fontWeight: FontWeight.bold,
                          color: Color.fromARGB(255, 235, 235, 235),
                        ),
                      ),
                    ],
                  )),
                )
              ]),
            ),
            Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10)),
                child: Column(children: [
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _usernameController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Username",
                          hintStyle: TextStyle(color: Colors.grey[400])),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _passwordcontroller,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Pasword",
                          hintStyle: TextStyle(color: Colors.grey[400])),
                    ),
                  ),
                ]),
              ),
            ),
            SizedBox(
              height: 2,
            ),
            Container(
              height: 50,
              margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: LinearGradient(colors: [
                  Color.fromARGB(255, 21, 84, 136),
                  Color.fromARGB(255, 35, 57, 75)
                ]),
              ),
              child: InkWell(
                onTap: () async {
                  try {
                    Authorization.username = _usernameController.text;
                    Authorization.password = _passwordcontroller.text;

                    await _korisniciProvider
                        .login({'username': Authorization.username});
                    Navigator.of(context).pushReplacementNamed('/Films');
                  } catch (e) {
                    showDialog(
                        context: context,
                        builder: (BuildContext context) => AlertDialog(
                              title: Text("Error"),
                              content: Text(e.toString()),
                              actions: [
                                TextButton(
                                  child: Text("Ok"),
                                  onPressed: () => Navigator.pop(context),
                                )
                              ],
                            ));
                  }
                },
                child: Center(
                    child: Text("Login",
                        style: TextStyle(
                            color: Color.fromARGB(255, 221, 220, 226)))),
              ),
            ),
            SizedBox(
              height: 40,
            ),
            Text("Nemate račun?"),
            txtRegistracija,
            SizedBox(
              height: 40,
            ),
          ],
        ),
      ),
    );
  }
}
