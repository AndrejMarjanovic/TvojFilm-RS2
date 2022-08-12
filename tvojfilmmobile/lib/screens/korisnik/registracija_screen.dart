import 'package:easy_localization/easy_localization.dart';
import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/model/grad.dart';
import 'package:tvojfilmmobile/provider/gradovi_provider.dart';
import 'package:tvojfilmmobile/provider/korisnici_provider.dart';
import 'package:tvojfilmmobile/utils/util.dart';
import 'package:tvojfilmmobile/widgets/text_imput.dart';
import '../../widgets/alert_dialog_widget.dart';

class RegistracijaScreen extends StatefulWidget {
  const RegistracijaScreen({Key? key}) : super(key: key);

  @override
  _RegistracijaScreenState createState() => _RegistracijaScreenState();
}

class _RegistracijaScreenState extends State<RegistracijaScreen> {
  late KorisniciProvider _korisniciProvider;

  final TextEditingController _imeController = TextEditingController();
  final TextEditingController _prezimeController = TextEditingController();
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _telefonController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController dtpDatumRodjenjaController =
      TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _passwordConfirmationController =
      TextEditingController();
  FocusNode focusNode = FocusNode();

  DateTime _odabraniDatumRodjenja = DateTime.now();

  dynamic response;

  final _formKey = GlobalKey<FormState>();
  final _obavezno = "Obavezno polje!";

  bool _isObscure = true;
  bool _isObscureConfirmation = true;

  @override
  void initState() {
    _korisniciProvider = context.read<KorisniciProvider>();
    setState(() {});
    super.initState();
  }

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

  @override
  Widget build(BuildContext context) {
    final txtFirstName =
        TextInputWidget(label: "Ime", controller: _imeController);
    final txtLastName =
        TextInputWidget(label: "Prezime", controller: _prezimeController);

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

    final txtUsername =
        TextInputWidget(label: "Username", controller: _usernameController);

    final txtPassword = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Password " + _obavezno;
        } else if (value != null && value.isNotEmpty) {
          if (value.length < 4) {
            return "Lozinka mora sadržavati barem 4 karaktera!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordController,
      obscureText: _isObscure,
      style: const TextStyle(color: Colors.black),
      decoration: InputDecoration(
          suffixIcon: IconButton(
              icon: Icon(
                _isObscure ? Icons.visibility : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _isObscure = !_isObscure;
                });
              }),
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
        if (value == null || value.isEmpty) {
          return "Potvrdite lozinku " + _obavezno;
        } else if (value != null && value.isNotEmpty) {
          if (value != _passwordController.text) {
            return "Lozinka i potvrda lozinke moraju se poklapati!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordConfirmationController,
      obscureText: _isObscureConfirmation,
      style: const TextStyle(color: Colors.black),
      decoration: InputDecoration(
          suffixIcon: IconButton(
              icon: Icon(
                _isObscureConfirmation
                    ? Icons.visibility
                    : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _isObscureConfirmation = !_isObscureConfirmation;
                });
              }),
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

    final btnRegister = InkWell(
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
          "Registracija",
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
            "gradId": 1,
            "ulogaId": 2,
          };
          if (_passwordController.text !=
              _passwordConfirmationController.text) {
            showDialog(
                context: context,
                builder: (BuildContext context) => AlertDialogWidget(
                      title: "Warning",
                      message: "Lozinka i potvrda lozinke se ne poklapaju!",
                      context: context,
                    ));
          } else {
            try {
              await _korisniciProvider.insert(register);
              await showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Success",
                        message: "Successfully created profile!",
                        context: dialogContex,
                      ));
              Authorization.username = _usernameController.text;
              Authorization.password = _passwordController.text;

              await _korisniciProvider
                  .login({'username': Authorization.username});
              Navigator.of(context).pushReplacementNamed('/Films');
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

    final txtTitle = Text("Kreirajte račun",
        style: TextStyle(
            fontSize: 26,
            fontWeight: FontWeight.bold,
            color: Color.fromARGB(255, 21, 84, 136)));

    return Scaffold(
        body: Center(
      child: Container(
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.width,
        padding: const EdgeInsets.only(left: 16, right: 16),
        child: ListView(children: [
          Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const SizedBox(height: 20.0),
                Form(
                  key: _formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const SizedBox(
                          height: 10,
                        ),
                        txtTitle,
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
                        txtPassword,
                        const SizedBox(height: 16),
                        txtPasswordConfirmation,
                        const SizedBox(height: 20),
                        btnRegister,
                        const SizedBox(height: 20),
                      ]),
                ),
              ]),
        ]),
      ),
    ));
  }
}
