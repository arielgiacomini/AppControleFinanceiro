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
        var items = _transactionRepository.GetAll();
        CollectionViewTransactions.ItemsSource = items;

        var income = items
            .Where(transaction => transaction.Type == Models.TransactionType.Income)
            .Sum(income => income.Value);

        var expense = items
            .Where(transaction => transaction.Type == Models.TransactionType.Expenses)
            .Sum(income => income.Value);

        decimal balance = (income.Value - expense.Value);

        LabelIncome.Text = income.Value.ToString("C");
        LabelExpense.Text = expense.Value.ToString("C");
        LabelBalance.Text = balance.ToString("C");
    }

    private void OnButtonPlusClickedToTransactionAdd(object sender, EventArgs eventArgs)
    {

        var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();

        Navigation.PushModalAsync(transactionAdd);
    }

    private void TapGestureRecognizerTappedToTransactionEdit(object sender, TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        var transaction = (Models.Transaction)gesture.CommandParameter;

        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
        transactionEdit.SetTransactionToEdit(transaction);
        Navigation.PushModalAsync(transactionEdit);
    }

    private async void TapGestureRecognizerTappedToDelete(object sender, TappedEventArgs e)
    {
        await AnimationBorder((Border)sender, true);
        var result = await App
            .Current
            .MainPage
            .DisplayAlert("Exlcuir!", "Tem certeza que deseja excluir?", "Sim", "Não");

        if (result)
        {
            var transaction = (Models.Transaction)e.Parameter;

            _transactionRepository.Delete(transaction);

            Reload();
        }
        else
        {
            await AnimationBorder((Border)sender, false);
        }
    }

    private Color _borderOriginalBackgroundColor;
    private string _labelOriginalText;

    private async Task AnimationBorder(Border border, bool isDeleteAnimation)
    {
        var label = (Label)border.Content;

        if (isDeleteAnimation)
        {
            _borderOriginalBackgroundColor = border.BackgroundColor;
            _labelOriginalText = label.Text;

            await border.RotateYTo(90, 500);

            border.BackgroundColor = Colors.Red;

            label.TextColor = Colors.White;
            label.Text = "X";

            await border.RotateYTo(180, 500);
        }
        else
        {
            await border.RotateYTo(90, 500);

            border.BackgroundColor = _borderOriginalBackgroundColor;
            label.TextColor = Colors.Black;
            label.Text = _labelOriginalText;

            await border.RotateYTo(0, 500);
        }
    }
}