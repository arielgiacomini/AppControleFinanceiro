using LiteDB;
using System.Transactions;

namespace AppControleFinanceiro.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionRepository()
        {
            var db = new LiteDatabase("Filename=C:/users/AppData/database.db;Connection=Shared");

            db.Dispose();
        }

        public List<Transaction> GetAll()
        {
            return new List<Transaction>();
        }

        public void Insert(Transaction transaction)
        {

        }

        public void Update(Transaction transaction)
        {

        }

        public void Delete(Transaction transaction)
        {

        }
    }
}