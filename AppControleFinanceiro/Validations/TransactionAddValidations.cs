namespace AppControleFinanceiro.Validations
{
    public static class TransactionAddValidations
    {
        public static bool IsValidData(Models.Transaction transaction)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(transaction.Name))
            {
                valid = false;
            }

            return valid;
        }
    }
}