using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public class TopUpViewModel : BaseViewModel
    {
        private string _amount;
        private readonly IWalletService _walletService;
        private readonly ITransactionService _transactionService;

        public TopUpViewModel()
        {
            _walletService = new MockWalletService();
            _transactionService = new MockTransactionService();
            TopUpCommand = new Command(OnTopUp, CanTopUp);
            
            PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(Amount))
                {
                    TopUpCommand.ChangeCanExecute();
                }
            };
        }

        public string Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public Command TopUpCommand { get; }

        private bool CanTopUp()
        {
            return !string.IsNullOrWhiteSpace(Amount) && 
                   decimal.TryParse(Amount, out var amount) && 
                   amount > 0 && 
                   !IsBusy;
        }

        private async void OnTopUp()
        {
            if (!decimal.TryParse(Amount, out var amount) || amount <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid amount", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                _walletService.TopUp(amount);
                
                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = amount,
                    Date = DateTime.Now,
                    Description = "Wallet top-up"
                };
                _transactionService.AddTransaction(transaction);
                
                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully topped up {amount:F2} RSD", "OK");
                Amount = string.Empty;
                
                await Shell.Current.GoToAsync("//HomeView");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
