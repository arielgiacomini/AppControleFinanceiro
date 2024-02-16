using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    /*
     * Publisher - Subriscribers ->
     * TransactionAdd -> Publisher > Cadastro (Mensagem > Transaction)
     * OK - Subscribers -> TransactionList (Receba o Transaction). 
    */

    private readonly ITransactionRepository _transactionRepository;

    public TransactionList(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;

        InitializeComponent();

        Reload();

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            Reload();
        });
    }

    private void Reload()
    {
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