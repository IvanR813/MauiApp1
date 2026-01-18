using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public class CanteenViewModel : BaseViewModel
    {
        private string _amount;
        private readonly IWalletService _walletService;
        private readonly ITransactionService _transactionService;

        public CanteenViewModel()
        {
            _walletService = AppState.WalletService;       // globalni wallet
            _transactionService = AppState.TransactionService;

            PayCommand = new Command(OnPay, CanPay);

            PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(Amount))
                    PayCommand.ChangeCanExecute();
            };
        }

        public string Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public Command PayCommand { get; }

        private bool CanPay()
        {
            return !string.IsNullOrWhiteSpace(Amount) &&
                   decimal.TryParse(Amount, out var amount) &&
                   amount > 0 &&
                   !IsBusy;
        }

        private async void OnPay()
        {
            if (!decimal.TryParse(Amount, out var amount) || amount <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid amount", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                var success = _walletService.Pay(amount);

                if (!success)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Insufficient balance", "OK");
                    return;
                }

                // dodaj transakciju
                _transactionService.AddTransaction(new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = -amount,
                    Date = DateTime.Now,
                    Description = "Canteen payment"
                });

                Amount = string.Empty;

                // osveži HomeViewModel saldo
                if (Application.Current.MainPage is Shell shell &&
                    shell.CurrentPage.BindingContext is HomeViewModel homeVm)
                {
                    homeVm.RefreshBalance();
                }

                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully paid {amount:F2} RSD for canteen", "OK");

                await Shell.Current.GoToAsync("//HomeView");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
