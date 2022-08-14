import 'package:tvojfilmmobile/model/prijedlog.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';

class PrijedlogProvider extends BaseProvider<Prijedlog> {
  PrijedlogProvider() : super("PrijedloziFilmova");

  @override
  Prijedlog fromJson(data) {
    return Prijedlog.fromJson(data);
  }
}
