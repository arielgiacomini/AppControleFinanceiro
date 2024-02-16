using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionList(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;

        InitializeComponent();

        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
    }

    private void OnButtonPlusClickedToTransactionAdd(object sender, EventArgs eventArgs)
    {
        var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(transactionAdd);
    }

    private void OnButtonPlusClickedToTransactionEdit(object sender, EventArgs e)
    {
        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
        Navigation.PushModalAsync(transactionEdit);
    }
}