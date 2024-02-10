namespace AppControleFinanceiro.Repositories
{
    public interface ITransactionRepository
    {
        void Delete(Models.Transaction transaction);
        List<Models.Transaction> GetAll();
        void Insert(Models.Transaction transaction);
        void Update(Models.Transaction transaction);
    }
}