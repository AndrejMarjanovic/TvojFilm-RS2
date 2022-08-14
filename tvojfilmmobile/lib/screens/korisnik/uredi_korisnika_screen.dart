import 'package:easy_localization/easy_localization.dart';
import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/model/Korisnici.dart';
import 'package:tvojfilmmobile/model/grad.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/gradovi_provider.dart';
import 'package:tvojfilmmobile/provider/korisnici_provider.dart';
import 'package:tvojfilmmobile/widgets/text_imput.dart';
import 'package:tvojfilmmobile/widgets/tvojfilm_drawer.dart';
import '../../widgets/alert_dialog_widget.dart';

class UrediKorisnikaScreen extends StatefulWidget {
  static const String routeName = "/user-information";
  const UrediKorisnikaScreen({Key? key}) : super(key: key);

  @override
  State<UrediKorisnikaScreen> createState() => _UrediKorisnikaScreenState();
}

class _UrediKorisnikaScreenState extends State<UrediKorisnikaScreen> {
  late KorisniciProvider _korisnikProvider;
  GradoviProvider? _gradoviProvider = null;
  Korisnici korisnik = Korisnici();
  List<Grad> gradovi = [];

  int? selectedValue;

  @override
  void initState() {
    _korisnikProvider = context.read<KorisniciProvider>();
    _gradoviProvider = context.read<GradoviProvider>();
    WidgetsBinding.instance.addPostFrameCallback((_) async {
      await ucitajKorisnickePodatke();
      loadGradovi();
      setState(() {});
    });
    super.initState();
  }

  Future loadGradovi() async {
    var Gradovi = await _gradoviProvider?.get();
    setState(() {
      gradovi = Gradovi!;
    });
  }

  Future<Korisnici> ucitajKorisnickePodatke() async {
    var Data = await _korisnikProvider.getById(BaseProvider.korisnikID!);
    return Data;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        iconTheme:
            const IconThemeData(color: Color.fromARGB(255, 235, 235, 235)),
        title: Text("Moj račun",
            style: const TextStyle(color: Color.fromARGB(255, 235, 235, 235))),
        backgroundColor: Color.fromARGB(255, 21, 84, 136),
        centerTitle: true,
        elevation: 0.0,
      ),
      drawer: tvojFilmDrawer(),
      backgroundColor: Colors.white,
      body: body(),
    );
  }

  Widget body() {
    const _obavezno = "Obavezno polje!";
    final _formKey = GlobalKey<FormState>();

    TextEditingController _imeController = TextEditingController();
    TextEditingController _prezimeController = TextEditingController();
    TextEditingController _usernameController = TextEditingController();
    TextEditingController _telefonController = TextEditingController();
    TextEditingController _emailController = TextEditingController();
    TextEditingController dtpDatumRodjenjaController = TextEditingController();
    TextEditingController _passwordController = TextEditingController();
    TextEditingController _passwordConfirmationController =
        TextEditingController();

    DateTime _odabraniDatumRodjenja = DateTime.now();

    final txtFirstName =
        TextInputWidget(label: "Ime", controller: _imeController);
    final txtLastName =
        TextInputWidget(label: "Prezime", controller: _prezimeController);
    final txtUsername =
        TextInputWidget(label: "Username", controller: _usernameController);

    Future<void> _selectDate(BuildContext context) async {
      final DateTime? picked = await showDatePicker(
          context: context,
          initialDate: _odabraniDatumRodjenja,
          firstDate: DateTime(1900, 1),
          lastDate: DateTime.now());

      if (picked != null && picked != _odabraniDatumRodjenja) {
        setState(() {
          _odabraniDatumRodjenja = picked;
          dtpDatumRodjenjaController.text =
              "${_odabraniDatumRodjenja.toLocal()}".split(' ')[0];
        });
      }
    }

    List<DropdownMenuItem> _GradoviDropDownList() {
      if (gradovi.length == 0) {
        return [];
      }
      List<DropdownMenuItem> list = gradovi
          .map((x) => DropdownMenuItem(
                child: Text(x.naziv!, style: TextStyle(color: Colors.black)),
                value: x.gradId,
              ))
          .toList();
      return list;
    }

    final dtpDatumRodjenja = InkWell(
      child: IgnorePointer(
        child: TextFormField(
          validator: (value) {
            return value == null || value.isEmpty ? _obavezno : null;
          },
          controller: dtpDatumRodjenjaController,
          obscureText: false,
          style: TextStyle(color: Colors.black),
          decoration: InputDecoration(
              labelText: "Datum rođenja",
              labelStyle: const TextStyle(
                  fontSize: 16, color: Color.fromARGB(255, 32, 32, 32)),
              enabledBorder: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(10),
                  borderSide:
                      BorderSide(color: Color.fromARGB(255, 35, 57, 75))),
              focusedBorder: OutlineInputBorder(
                borderRadius: BorderRadius.circular(10),
                borderSide:
                    const BorderSide(color: Color.fromARGB(255, 21, 84, 136)),
              )),
        ),
      ),
      onTap: () {
        _selectDate(context);
      },
    );

    final txtPhoneNumber = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Broj telefona " + _obavezno;
        } else if (value != null && value.isNotEmpty) {
          if (!value.startsWith(RegExp(r'^[0-9]{3}[0-9]{3}[0-9]{3}$'))) {
            return "Unesite broj od 9 znamenki!";
          }
        } else {
          return null;
        }
      },
      controller: _telefonController,
      style: const TextStyle(color: Colors.black),
      decoration: InputDecoration(
          labelText: "Broj telefona",
          labelStyle: const TextStyle(
              fontSize: 16, color: Color.fromARGB(255, 32, 32, 32)),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Color.fromARGB(255, 35, 57, 75))),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 21, 84, 136)),
          )),
    );

    final txtEmail = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Email " + _obavezno;
        } else if (!EmailValidator.validate(value)) {
          return "Unesite email u valjanom formatu!";
        } else {
          return null;
        }
      },
      controller: _emailController,
      style: const TextStyle(color: Colors.black),
      decoration: InputDecoration(
          labelText: "Email",
          labelStyle: const TextStyle(
              fontSize: 16, color: Color.fromARGB(255, 32, 32, 32)),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Color.fromARGB(255, 35, 57, 75))),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 21, 84, 136)),
          )),
    );

    final txtPassword = TextFormField(
      validator: (value) {
        if (value != null && value.isNotEmpty) {
          if (value.length < 4) {
            return "Lozinka mora sadržavati barem 4 karaktera!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordController,
      obscureText: true,
      style: const TextStyle(color: Colors.black),
      decoration: InputDecoration(
          labelText: "Lozinka",
          labelStyle: const TextStyle(
              fontSize: 16, color: Color.fromARGB(255, 32, 32, 32)),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Color.fromARGB(255, 35, 57, 75))),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 21, 84, 136)),
          )),
    );

    final txtPasswordConfirmation = TextFormField(
      validator: (value) {
        if (value != null && value.isNotEmpty) {
          if (value != _passwordController.text) {
            return "Lozinka i potvrda lozinke moraju se poklapati!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordConfirmationController,
      obscureText: true,
      style: const TextStyle(color: Colors.black),
      decoration: InputDecoration(
          labelText: "Potvrda lozinke",
          labelStyle: const TextStyle(
              fontSize: 16, color: Color.fromARGB(255, 32, 32, 32)),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Color.fromARGB(255, 35, 57, 75))),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 21, 84, 136)),
          )),
    );

    final btnSpremi = InkWell(
      child: Container(
        height: 50,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(10),
            gradient: const LinearGradient(colors: [
              Color.fromARGB(255, 21, 84, 136),
              Color.fromARGB(255, 35, 57, 75)
            ])),
        child: const Center(
            child: Text(
          "Spremi promjene",
          style: TextStyle(
              fontSize: 20, fontWeight: FontWeight.bold, color: Colors.white),
        )),
      ),
      onTap: () async {
        if (_formKey.currentState!.validate()) {
          Map register = {
            "ime": _imeController.text,
            "prezime": _prezimeController.text,
            "email": _emailController.text,
            "telefon": _telefonController.text,
            "datumRodjenja": DateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")
                .format(_odabraniDatumRodjenja),
            "username": _usernameController.text,
            "password": _passwordController.text,
            "passwordConfirm": _passwordConfirmationController.text,
            "ulogaId": korisnik.ulogaId,
            "gradId": selectedValue,
          };
          if (_passwordController.text !=
              _passwordConfirmationController.text) {
            showDialog(
                context: context,
                builder: (BuildContext context) => AlertDialogWidget(
                      title: "Upozorenje",
                      message: "Lozinka i potvrda lozinke se ne poklapaju!",
                      context: context,
                    ));
          } else {
            try {
              await _korisnikProvider.update(
                  BaseProvider.korisnikID!, register);
              await showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Uspjeh!",
                        message: "Uspješno ste ažurirali podatke!",
                        context: dialogContex,
                      ));
            } catch (e) {
              showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Error",
                        message: "An error occured!",
                        context: dialogContex,
                      ));
            }
          }
        }
      },
    );

    const txtSubtitle = Text("Uredi korisničke podatke.",
        style: TextStyle(
          fontSize: 20,
          color: Color.fromARGB(255, 35, 57, 75),
        ));

    return FutureBuilder(
        future: ucitajKorisnickePodatke(),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text("Loading..."));
          } else if (snapshot.hasError) {
            return const Center(child: Text("An error occured!"));
          } else if (snapshot.data is Korisnici) {
            korisnik = snapshot.data;
            _imeController.text = korisnik.ime!;
            _prezimeController.text = korisnik.prezime!;
            _emailController.text = korisnik.email!;
            _odabraniDatumRodjenja = korisnik.datumRodjenja!;
            dtpDatumRodjenjaController.text =
                korisnik.datumRodjenja!.toString();
            _usernameController.text = korisnik.username!;
            _telefonController.text = korisnik.telefon!;
            selectedValue = korisnik.gradId;

            return Center(
                child: Container(
              height: MediaQuery.of(context).size.height,
              width: MediaQuery.of(context).size.width,
              padding: const EdgeInsets.only(left: 16, right: 16),
              child: ListView(
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Form(
                        key: _formKey,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        child: Column(
                          children: [
                            const SizedBox(
                              height: 6,
                            ),
                            txtSubtitle,
                            const SizedBox(
                              height: 25,
                            ),
                            txtFirstName,
                            const SizedBox(height: 16),
                            txtLastName,
                            const SizedBox(height: 16),
                            txtUsername,
                            const SizedBox(height: 16),
                            txtPhoneNumber,
                            const SizedBox(height: 16),
                            txtEmail,
                            const SizedBox(height: 16),
                            dtpDatumRodjenja,
                            const SizedBox(height: 16),
                            DropdownButtonFormField(
                              items: _GradoviDropDownList(),
                              value: selectedValue,
                              decoration: InputDecoration(
                                  labelText: "Grad",
                                  labelStyle: const TextStyle(
                                      fontSize: 16,
                                      color: Color.fromARGB(255, 32, 32, 32)),
                                  enabledBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(10),
                                      borderSide: BorderSide(
                                          color:
                                              Color.fromARGB(255, 35, 57, 75))),
                                  focusedBorder: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(10),
                                    borderSide: const BorderSide(
                                        color:
                                            Color.fromARGB(255, 21, 84, 136)),
                                  )),
                              onChanged: (dynamic newValue) {
                                selectedValue = newValue;
                              },
                            ),
                            const SizedBox(height: 16),
                            txtPassword,
                            const SizedBox(height: 16),
                            txtPasswordConfirmation,
                            const SizedBox(height: 20),
                            btnSpremi,
                            const SizedBox(
                              height: 20,
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ));
          }
          return const Center(child: Text("Error"));
        });
  }
}
