using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1
{
    public class CanteenViewModel
    {
        private readonly IWalletService _walletService;
        private readonly ITransactionService _transactionService;

        public CanteenViewModel()
        {
            _walletService = AppState.WalletService;
            _transactionService = AppState.TransactionService;
        }

        public decimal CashBalance
        {
            get => _walletService.GetBalance();
        }

        public int BreakfastQuantity { get; set; } = 0;
        public int LunchQuantity { get; set; } = 0;
        public int DinnerQuantity { get; set; } = 0;

        private const decimal BreakfastPrice = 56.00m;
        private const decimal LunchPrice = 120.00m;
        private const decimal DinnerPrice = 90.00m;

        public decimal CalculateTotal()
        {
            return (BreakfastQuantity * BreakfastPrice) +
                   (LunchQuantity * LunchPrice) +
                   (DinnerQuantity * DinnerPrice);
        }

        public bool ProcessPayment()
        {
            decimal total = CalculateTotal();

            if (total <= 0)
            {
                return false; // No items selected
            }

            // Use wallet service to process payment
            bool success = _walletService.Pay(total);

            if (success)
            {
                // Record transaction
                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = -total,
                    Date = DateTime.Now,
                    Description = $"Canteen payment - Breakfast: {BreakfastQuantity}, Lunch: {LunchQuantity}, Dinner: {DinnerQuantity}"
                };
                _transactionService.AddTransaction(transaction);
            }

            return success;
        }

        public string GetBalanceString()
        {
            return $"Available Balance: {CashBalance:F2} RSD";
        }
    }
}
