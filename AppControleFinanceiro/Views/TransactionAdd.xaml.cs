using AppControleFinanceiro.Validations;
using AppControleFinanceiro.ViewModels;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionViewModel _transactionViewModel;

    public TransactionAdd(ITransactionViewModel transactionViewModel)
    {
        _transactionViewModel = transactionViewModel;
    }

    public TransactionAdd()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_ExitTapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void OnButtonSave_Clicked(object sender, EventArgs e)
    {
        TransactionAddValidations.IsValidData(new Models.Transaction());
    }
}