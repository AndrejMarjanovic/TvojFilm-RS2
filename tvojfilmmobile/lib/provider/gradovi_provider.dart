import 'package:tvojfilmmobile/model/grad.dart';
import 'package:tvojfilmmobile/provider/base_provider.dart';

class GradoviProvider extends BaseProvider<Grad> {
  GradoviProvider() : super("Gradovi");

  @override
  Grad fromJson(data) {
    return Grad.fromJson(data);
  }
}
