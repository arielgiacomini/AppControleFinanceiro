using AppControleFinanceiro.Repositories;
using System.Text;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionAdd(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
        InitializeComponent();
    }

    private void TapGestureRecognizer_ExitTapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void OnButtonSave_Clicked(object sender, EventArgs e)
    {
        var isValid = IsValidData();

        if (!isValid)
        {
            return;
        }

        _transactionRepository.Insert(MapViewToDomain());

        Navigation.PopModalAsync();

        var count = _transactionRepository.GetAll().Count;
        App.Current.MainPage.DisplayAlert("Mensagem!", $"Existem {count} registro(s) no Banco de Dados", "OK");
    }

    private Models.Transaction MapViewToDomain()
    {
        Models.Transaction transaction = new()
        {
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
            stringBuilder.AppendLine($"O campo [Valor] com a informação {result} é invalido.");
            isValid = false;
        }

        if (!isValid)
        {
            LabelError.IsVisible = true;
            LabelError.Text = stringBuilder.ToString();
        }

        return isValid;
    }
}