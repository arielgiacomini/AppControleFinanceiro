using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionList(
        TransactionAdd transactionAdd,
        TransactionEdit transactionEdit,
        ITransactionRepository transactionRepository)
    {
        _transactionAdd = transactionAdd;
        _transactionEdit = transactionEdit;
        _transactionRepository = transactionRepository;

        InitializeComponent();

        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
    }

    private void OnButtonPlusClickedToTransactionAdd(object sender, EventArgs eventArgs)
    {
        Navigation.PushModalAsync(_transactionAdd);
    }

    private void OnButtonPlusClickedToTransactionEdit(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_transactionEdit);
    }
}