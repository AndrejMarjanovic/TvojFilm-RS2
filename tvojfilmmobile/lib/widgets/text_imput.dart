import 'package:flutter/material.dart';

Widget TextInputWidget(
    {required String label, required TextEditingController controller}) {
  const mandatoryField = "Oavezno polje!";

  return TextFormField(
    validator: (value) {
      return value == null || value.isEmpty
          ? label + " " + mandatoryField
          : null;
    },
    style: TextStyle(color: Colors.black),
    controller: controller,
    decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(
            fontSize: 16, color: Color.fromARGB(255, 32, 32, 32)),
        enabledBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide: BorderSide(color: Color.fromARGB(255, 35, 57, 75))),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(10),
          borderSide: const BorderSide(color: Color.fromARGB(255, 21, 84, 136)),
        )),
  );
}
