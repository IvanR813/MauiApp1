namespace MauiApp1
{
    public class CanteenViewModel
    {
        private decimal _cashBalance = 1000.00m; // Default balance, you can load this from storage

        public decimal CashBalance
        {
            get => _cashBalance;
            set => _cashBalance = value;
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

            if (total > CashBalance)
            {
                return false; // Insufficient balance
            }

            // Deduct from balance
            CashBalance -= total;
            return true;
        }

        public string GetBalanceString()
        {
            return $"Available Balance: {CashBalance:F2} RSD";
        }
    }
}
