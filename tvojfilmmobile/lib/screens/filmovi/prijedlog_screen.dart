import 'package:easy_localization/easy_localization.dart';
import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/prijedlog_provider.dart';
import 'package:tvojfilmmobile/utils/util.dart';
import 'package:tvojfilmmobile/widgets/text_imput.dart';
import 'package:tvojfilmmobile/widgets/tvojfilm_drawer.dart';
import '../../widgets/alert_dialog_widget.dart';

class PrijedlogScreen extends StatefulWidget {
  const PrijedlogScreen({Key? key}) : super(key: key);

  @override
  _PrijedlogScreenState createState() => _PrijedlogScreenState();
}

class _PrijedlogScreenState extends State<PrijedlogScreen> {
  late PrijedlogProvider _prijedlogProvider;

  final TextEditingController _imeController = TextEditingController();
  final TextEditingController _opisController = TextEditingController();

  FocusNode focusNode = FocusNode();

  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    _prijedlogProvider = context.read<PrijedlogProvider>();
    setState(() {});
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final txtImeFilma =
        TextInputWidget(label: "Ime filma", controller: _imeController);
    final txtOpis = TextInputWidget(label: "Opis", controller: _opisController);

    final btnPredlozi = InkWell(
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
            "Pošalji prijedlog",
            style: TextStyle(
                fontSize: 20, fontWeight: FontWeight.bold, color: Colors.white),
          )),
        ),
        onTap: () async {
          if (_formKey.currentState!.validate()) {
            Map prijedlog = {
              "prijedlogIme": _imeController.text,
              "opis": _opisController.text,
              "korisnikId": BaseProvider.korisnikID,
            };
            try {
              await _prijedlogProvider.insert(prijedlog);
              await showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Hvala!",
                        message:
                            "Vaš prijedlog filma bit će uzet u razmatranje!",
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
        });

    final txtTitle = Text("Predložite film za našu ponudu.",
        style: TextStyle(
            fontSize: 26,
            fontWeight: FontWeight.bold,
            color: Color.fromARGB(255, 21, 84, 136)));

    return Scaffold(
        appBar: AppBar(
          iconTheme:
              const IconThemeData(color: Color.fromARGB(255, 235, 235, 235)),
          title: Text("Vaš prijedlog",
              style:
                  const TextStyle(color: Color.fromARGB(255, 235, 235, 235))),
          backgroundColor: Color.fromARGB(255, 21, 84, 136),
          centerTitle: true,
          elevation: 0.0,
        ),
        drawer: tvojFilmDrawer(),
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
                            txtImeFilma,
                            const SizedBox(height: 16),
                            txtOpis,
                            const SizedBox(height: 16),
                            btnPredlozi,
                            const SizedBox(height: 20),
                          ]),
                    ),
                  ]),
            ]),
          ),
        ));
  }
}
