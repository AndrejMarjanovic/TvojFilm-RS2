import 'dart:convert';
import 'dart:core';
import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_credit_card/flutter_credit_card.dart';
import 'package:flutter_paypal/flutter_paypal.dart';
import 'package:provider/provider.dart';
import 'package:tvojfilmmobile/model/kupnja.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';
import 'package:tvojfilmmobile/provider/kupnja_provider.dart';
import 'package:tvojfilmmobile/screens/filmovi/videoteka_screen.dart';
import '../../model/film.dart';
import '../../model/kupnjaInsert.dart';
import '../../provider/kupnja_insert_provider.dart';
import '../../widgets/alert_dialog_widget.dart';

class KupnjaFilmaScreen extends StatefulWidget {
  const KupnjaFilmaScreen({Key? key, this.film}) : super(key: key);
  final Film? film;
  @override
  State<KupnjaFilmaScreen> createState() => _KupnjaFilmaState(film);
}

class _KupnjaFilmaState extends State<KupnjaFilmaScreen> {
  late KupnjaInsertProvider _kupnjaInsertProvider;
  KupnjaFilmaInsert request = KupnjaFilmaInsert();
  Film? film;
  List<KupnjaFilma> data = [];
  KupnjaProvider? _kupnjaProvider = null;

  TextStyle style = const TextStyle(fontSize: 18.0);

  String brojKartice = "";
  String datumIsteka = "";
  String vlasnik = "";
  String cvvKod = "";
  bool isCvvFocused = false;

  _KupnjaFilmaState(this.film);
  final GlobalKey<FormState> formKey = GlobalKey<FormState>();

  @override
  void initState() {
    _kupnjaProvider = context.read<KupnjaProvider>();
    checkIfBought();
    super.initState();
  }

  Future checkIfBought() async {
    var tempData = await _kupnjaProvider
        ?.get({'korisnikId': BaseProvider.korisnikID, 'filmId': film!.filmId!});
    setState(() {
      data = tempData!;
    });
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _kupnjaInsertProvider = context.watch<KupnjaInsertProvider>();
  }

  Future<void> _showDialog(String text, [dismissable = true]) async {
    return showDialog<void>(
      barrierDismissible: dismissable,
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: Text(text),
          actions: <Widget>[
            TextButton(
              child: const Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[100],
      appBar: AppBar(
        iconTheme:
            const IconThemeData(color: Color.fromARGB(255, 235, 235, 235)),
        title: Text(widget.film!.nazivFilma!,
            style: const TextStyle(color: Color.fromARGB(255, 235, 235, 235))),
        backgroundColor: Color.fromARGB(255, 21, 84, 136),
        centerTitle: true,
        elevation: 0.0,
      ),
      body: Center(
        child: Container(
          color: Colors.white,
          child: Padding(
            padding: const EdgeInsets.all(36.0),
            child: body(),
          ),
        ),
      ),
    );
  }

  Widget body() {
    final btnDalje = Container(
      height: 50,
      margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(10),
        gradient: LinearGradient(colors: [
          Color.fromARGB(255, 21, 84, 136),
          Color.fromARGB(255, 35, 57, 75)
        ]),
      ),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          setState(() {
            checkIfBought();
          });
          if (data.length == 0) {
            if (formKey.currentState!.validate()) {
              Map order = {
                "korisnikId": BaseProvider.korisnikID,
                "filmId": film!.filmId,
              };

              try {
                await _kupnjaInsertProvider.insert(order);
                setState(() {});
                await _showDialog(
                    "Uspješno izvršeno! Film je dodan u vašu videoteku.",
                    false);

                Navigator.of(context).pushAndRemoveUntil(
                  MaterialPageRoute(
                    builder: (BuildContext context) => const VideotekaScreen(),
                  ),
                  (route) => false,
                );
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
          } else {
            showDialog(
                context: context,
                builder: (BuildContext dialogContex) => AlertDialogWidget(
                      title: "Error",
                      message: "Film je već u vašoj videoteci!",
                      context: dialogContex,
                    ));
          }
        },
        child: Text("Potvrdi",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    final btnPayPal = Container(
      height: 50,
      margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
      child: TextButton(
          onPressed: () => {
                setState(() {
                  checkIfBought();
                }),
                if (data.length == 0)
                  {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (BuildContext context) => UsePaypal(
                            sandboxMode: true,
                            clientId:
                                "AVZxBsCAbVK7-DfVIr-JU4zFBU29HUd5wUsALpc24X8h_cx0bsuDjEgre4eicMxOGUYY4vRygo5dt0o-",
                            secretKey:
                                "EHsIbxes84HqoHABcGZk2Bsas5TVi0XmHBWOe9yuD37yj2lsd6I1uLLAcAOnlqA2jreW5hujoNKZQQvg",
                            returnURL: "https://samplesite.com/return",
                            cancelURL: "https://samplesite.com/cancel",
                            transactions: [
                              {
                                "amount": {
                                  "total": '${film!.cijena}',
                                  "currency": "USD",
                                  "details": {
                                    "subtotal": '${film!.cijena}',
                                    "shipping": '0',
                                    "shipping_discount": 0
                                  }
                                },
                                "description":
                                    "The payment transaction description.",
                                // "payment_options": {
                                //   "allowed_payment_method":
                                //       "INSTANT_FUNDING_SOURCE"
                                // },
                                "item_list": {
                                  "items": [
                                    {
                                      "name": "Film",
                                      "quantity": 1,
                                      "price": '${film!.cijena}',
                                      "currency": "USD"
                                    }
                                  ],

                                  // shipping address is not required though
                                  "shipping_address": {
                                    "recipient_name": "TvojFilm",
                                    "line1": "Travis County",
                                    "line2": "",
                                    "city": "Austin",
                                    "country_code": "US",
                                    "postal_code": "73301",
                                    "phone": "+00000000",
                                    "state": "Texas"
                                  },
                                }
                              }
                            ],
                            note: "Contact us for any questions on your order.",
                            onSuccess: (Map params) async {
                              Map order = {
                                "korisnikId": BaseProvider.korisnikID,
                                "filmId": film!.filmId,
                              };

                              try {
                                await _kupnjaInsertProvider.insert(order);
                                setState(() {});
                                await _showDialog(
                                    "Uspješno izvršeno! Film je dodan u vašu videoteku.",
                                    false);
                              } catch (e) {
                                showDialog(
                                    context: context,
                                    builder: (BuildContext dialogContex) =>
                                        AlertDialogWidget(
                                          title: "Error",
                                          message: "An error occured!",
                                          context: dialogContex,
                                        ));
                              }
                            },
                            onError: (error) {
                              print("onError: $error");
                            },
                            onCancel: (params) {
                              print('cancelled: $params');
                            }),
                      ),
                    )
                  }
                else
                  {
                    showDialog(
                        context: context,
                        builder: (BuildContext dialogContex) =>
                            AlertDialogWidget(
                              title: "Error",
                              message: "Film je već u vašoj videoteci!",
                              context: dialogContex,
                            ))
                  }
              },
          child: const Text("PayPal",
              style: TextStyle(
                  color: Color.fromARGB(255, 35, 96, 187),
                  decoration: TextDecoration.underline,
                  fontStyle: FontStyle.italic))),
    );

    void onCreditCardModelChange(CreditCardModel? creditCardModel) {
      setState(() {
        brojKartice = creditCardModel!.cardNumber;
        datumIsteka = creditCardModel.expiryDate;
        vlasnik = creditCardModel.cardHolderName;
        cvvKod = creditCardModel.cvvCode;
        isCvvFocused = creditCardModel.isCvvFocused;
      });
    }

    return Column(children: [
      Expanded(
        child: ListView(children: [
          const SizedBox(height: 15.0),
          Row(
            children: [
              Expanded(
                child: CreditCardWidget(
                  cardBgColor: const Color.fromARGB(255, 21, 84, 136),
                  cardNumber: brojKartice,
                  showBackView: isCvvFocused,
                  cvvCode: cvvKod,
                  cardHolderName: vlasnik,
                  expiryDate: datumIsteka,
                  onCreditCardWidgetChange: (ccb) {},
                ),
              ),
            ],
          ),
          Row(
            children: [
              Expanded(
                child: CreditCardForm(
                  formKey: formKey,
                  themeColor: Color(0xff01A0C7),
                  onCreditCardModelChange: onCreditCardModelChange,
                  cvvCode: cvvKod,
                  cvvValidationMessage: "Unesite validan CVV",
                  cardHolderName: vlasnik,
                  cardNumber: brojKartice,
                  numberValidationMessage: "Unesite validan broj kartice",
                  expiryDate: datumIsteka,
                  dateValidationMessage: "Unesite validan datum",
                  isHolderNameVisible: false,
                  cardNumberDecoration: InputDecoration(
                    labelText: 'Broj kartice',
                    hintText: 'XXXX XXXX XXXX XXXX',
                    contentPadding:
                        const EdgeInsets.fromLTRB(10.0, 5.0, 10.0, 5.0),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                  ),
                  expiryDateDecoration: InputDecoration(
                    labelText: 'Datum isteka',
                    hintText: 'MM/GG',
                    contentPadding:
                        const EdgeInsets.fromLTRB(10.0, 5.0, 10.0, 5.0),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                  ),
                  cvvCodeDecoration: InputDecoration(
                    labelText: 'CVV',
                    hintText: 'XXXX',
                    contentPadding:
                        const EdgeInsets.fromLTRB(10.0, 5.0, 10.0, 5.0),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ]),
      ),
      const SizedBox(height: 15.0),
      Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const SizedBox(width: 15.0),
            Expanded(child: btnDalje),
          ]),
      Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const SizedBox(width: 15.0),
            Expanded(child: btnPayPal),
          ]),
    ]);
  }
}
