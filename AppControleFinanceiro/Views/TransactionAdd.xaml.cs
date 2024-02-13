using AppControleFinanceiro.Validations;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
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