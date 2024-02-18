using System.Globalization;

namespace AppControleFinanceiro.Utilities
{
    public class TransactionValueColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var transaction = (Models.Transaction)value;

            if (transaction == null)
            {
                return Colors.Black;
            }

            if (transaction.Type == Models.TransactionType.Income)
            {

                return Color.FromArgb("#FF939E5A");
            }
            else
            {
                return Colors.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}