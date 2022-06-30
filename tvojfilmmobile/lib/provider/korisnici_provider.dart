import '../model/korisnik.dart';
import 'base_provider.dart';

class KorisniciProvider extends BaseProvider<Korisnik> {
  KorisniciProvider() : super("Korisnici");

  @override
  Korisnik fromJson(data) {
    // TODO: implement fromJson
    return Korisnik();
  }
}
