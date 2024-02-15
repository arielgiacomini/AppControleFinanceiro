using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.ViewModels
{
    public interface ITransactionViewModel
    {
        IList<Transaction> GetTransactions();
    }
}