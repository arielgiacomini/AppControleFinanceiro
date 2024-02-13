using AppControleFinanceiro.ViewModels;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    public TransactionList()
    {
        InitializeComponent();
        BindingContext = new TransactionViewModel();
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