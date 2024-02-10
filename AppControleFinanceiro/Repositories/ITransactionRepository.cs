using System.Transactions;

namespace AppControleFinanceiro.Repositories
{
    public interface ITransactionRepository
    {
        void Delete(Transaction transaction);
        List<Transaction> GetAll();
        void Insert(Transaction transaction);
        void Update(Transaction transaction);
    }
}