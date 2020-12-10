import 'package:intl/intl.dart';

class Formator {
  static String convertDatatimeToString(DateTime source) {
    DateFormat dateFormat = DateFormat("dd/MM/yyyy");
    return dateFormat.format(source);
  }

  static String convertCurrencyToString(double source) {
    final formatCurrency = new NumberFormat("#,##0", "en_US");
    if (source == null) {
      return formatCurrency.format(0);
    }
    return formatCurrency.format(source);
  }
  
}
