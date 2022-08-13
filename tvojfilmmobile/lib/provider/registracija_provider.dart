import 'package:tvojfilmmobile/provider/base_provider.dart';
import '../model/Korisnici.dart';

class RegistracijaProvider extends BaseProvider<Korisnici> {
  RegistracijaProvider() : super("Korisnici/Registracija");

  @override
  Korisnici fromJson(data) {
    return Korisnici.fromJson(data);
  }
}
