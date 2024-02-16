namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;

    public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit)
    {
        InitializeComponent();
        _transactionAdd = transactionAdd;
        _transactionEdit = transactionEdit;
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