using LiteDB;

namespace AppControleFinanceiro.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;
        private readonly string collectionName = "transactions";

        public TransactionRepository()
        {
            _database = new LiteDatabase("Filename=C:/users/AppData/database.db;Connection=Shared");
        }

        public List<Models.Transaction> GetAll()
        {
            return _database
                .GetCollection<Models.Transaction>(collectionName)
                .Query()
                .OrderByDescending(transaction => transaction.Date)
                .ToList();
        }

        public void Insert(Models.Transaction transaction)
        {
            var collection = _database.GetCollection<Models.Transaction>(collectionName);
            collection.Insert(transaction);
            collection.EnsureIndex(insert => insert.Date);
        }

        public void Update(Models.Transaction transaction)
        {
            var collection = _database.GetCollection<Models.Transaction>(collectionName);
            collection.Update(transaction);
        }

        public void Delete(Models.Transaction transaction)
        {
            var collection = _database.GetCollection<Models.Transaction>(collectionName);
            collection.Delete(transaction.Id);
        }
    }
}