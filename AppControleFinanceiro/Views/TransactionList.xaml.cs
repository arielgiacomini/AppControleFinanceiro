using AppControleFinanceiro.ViewModels;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionViewModel _transactionViewModel;

    public TransactionList()
    {
        InitializeComponent();
    }

    public TransactionList(ITransactionViewModel transactionViewModel)
    {
        _transactionViewModel = transactionViewModel;
        BindingContext = _transactionViewModel.GetTransactions();
    }

    private void OnButtonPlusClickedToTransactionAdd(object sender, EventArgs eventArgs)
    {
        Navigation.PushModalAsync(new TransactionAdd());
    }

    private void OnButtonPlusClickedToTransactionEdit(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransactionEdit());
    }
}