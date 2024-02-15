using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.ViewModels
{
    public class TransactionViewModel : ITransactionViewModel
    {
        private readonly ITransactionRepository _transactionRepository;

        public Transaction Transaction { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public TransactionViewModel(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;

            Transaction = new Transaction
            {
                Id = 1,
                Type = TransactionType.Income,
                Name = "Salário",
                Date = DateTime.Now,
                Value = 3600.00m
            };
        }

        public IList<Transaction> GetTransactions()
        {
            Transactions = _transactionRepository.GetAll();

            return Transactions;
        }
    }
}