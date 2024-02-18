using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;
using System.Text;

namespace AppControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;
    private Models.Transaction _transaction;

    public TransactionEdit(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
        InitializeComponent();
    }

    private void TapGestureRecognizerTappedClose(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    public void SetTransactionToEdit(Models.Transaction transaction)
    {
        _transaction = transaction;

        if (transaction.Type == Models.TransactionType.Income)
        {
            RadioIncome.IsChecked = true;
        }
        else
        {
            RadioExpense.IsChecked = true;
        }

        EntryName.Text = transaction.Name;
        DatePickerDate.Date = transaction.Date.Value.Date;
        EntryValue.Text = transaction.Value.Value.ToString();
    }

    private Models.Transaction MapViewToDomain()
    {
        Models.Transaction transaction = new()
        {
            Id = _transaction.Id,
            Name = EntryName.Text
        };

        bool valueValid = decimal.TryParse(EntryValue.Text, out decimal value);

        if (valueValid)
        {
            transaction.Value = value;
        }

        transaction.Date = DatePickerDate.Date;
        transaction.Type = RadioIncome.IsChecked ? Models.TransactionType.Income : Models.TransactionType.Expenses;

        return transaction;
    }

    private bool IsValidData()
    {
        bool isValid = true;
        StringBuilder stringBuilder = new();

        if (string.IsNullOrWhiteSpace(EntryName.Text))
        {
            stringBuilder.AppendLine("O campo [Nome] deve ser preenchido!");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            stringBuilder.AppendLine("O campo [Valor] deve ser preenchido!");
            isValid = false;
        }

        if (!string.IsNullOrEmpty(EntryValue.Text) && !decimal.TryParse(EntryValue.Text, out decimal result))
        {
            stringBuilder.AppendLine($"O campo [Valor] com a informação [{EntryValue.Text}] é invalido.");
            isValid = false;
        }

        if (!isValid)
        {
            LabelError.IsVisible = true;
            LabelError.Text = stringBuilder.ToString();
        }

        return isValid;
    }

    private void OnButtonUpdate_Clicked(object sender, EventArgs e)
    {
        var isValid = IsValidData();

        if (!isValid)
        {
            return;
        }

        _transactionRepository.Update(MapViewToDomain());

        Navigation.PopModalAsync();

        WeakReferenceMessenger.Default.Send<string>(string.Empty);
    }
}