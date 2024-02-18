using System.Globalization;

namespace AppControleFinanceiro.Utilities
{
    public class TransactionNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string transactionName = (string)value;

            if (string.IsNullOrWhiteSpace(transactionName))
            {
                return string.Empty;
            }

            return transactionName.ToUpper()[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}