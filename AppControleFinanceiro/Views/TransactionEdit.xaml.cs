namespace AppControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_ExitTapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}