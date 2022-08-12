import 'package:tvojfilmmobile/model/ocjena.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';

class OcjeneProvider extends BaseProvider<Ocjena> {
  OcjeneProvider() : super("FilmoviOcjene");

  @override
  Ocjena fromJson(data) {
    return Ocjena.fromJson(data);
  }
}
