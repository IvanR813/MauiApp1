namespace MauiApp1
{
    public partial class CanteenPayment : ContentView
    {
        private CanteenViewModel _viewModel;

        public event EventHandler? PaymentProcessed;

        public CanteenPayment()
        {
            InitializeComponent();
        }

        public void SetViewModel(CanteenViewModel viewModel)
        {
            _viewModel = viewModel;
            UpdateTotal();
        }

        private void UpdateQuantity(Entry entry, int change)
        {
            if (int.TryParse(entry.Text, out int currentValue))
            {
                int newValue = currentValue + change;
                if (newValue < 0) newValue = 0;
                entry.Text = newValue.ToString();
                UpdateTotal();
            }
            else
            {
                entry.Text = "0";
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            if (_viewModel == null) return;

            int breakfastQty = int.TryParse(BreakfastQuantityEntry.Text, out int b) ? b : 0;
            int lunchQty = int.TryParse(LunchQuantityEntry.Text, out int l) ? l : 0;
            int dinnerQty = int.TryParse(DinnerQuantityEntry.Text, out int d) ? d : 0;

            _viewModel.BreakfastQuantity = breakfastQty;
            _viewModel.LunchQuantity = lunchQty;
            _viewModel.DinnerQuantity = dinnerQty;

            decimal total = _viewModel.CalculateTotal();
            TotalAmountLabel.Text = $"Total: {total:F2} RSD";
        }

        // Breakfast button handlers
        private void OnBreakfastPlus1Clicked(object? sender, EventArgs e) => UpdateQuantity(BreakfastQuantityEntry, 1);
        private void OnBreakfastPlus10Clicked(object? sender, EventArgs e) => UpdateQuantity(BreakfastQuantityEntry, 10);
        private void OnBreakfastMinus1Clicked(object? sender, EventArgs e) => UpdateQuantity(BreakfastQuantityEntry, -1);
        private void OnBreakfastMinus10Clicked(object? sender, EventArgs e) => UpdateQuantity(BreakfastQuantityEntry, -10);

        // Lunch button handlers
        private void OnLunchPlus1Clicked(object? sender, EventArgs e) => UpdateQuantity(LunchQuantityEntry, 1);
        private void OnLunchPlus10Clicked(object? sender, EventArgs e) => UpdateQuantity(LunchQuantityEntry, 10);
        private void OnLunchMinus1Clicked(object? sender, EventArgs e) => UpdateQuantity(LunchQuantityEntry, -1);
        private void OnLunchMinus10Clicked(object? sender, EventArgs e) => UpdateQuantity(LunchQuantityEntry, -10);

        // Dinner button handlers
        private void OnDinnerPlus1Clicked(object? sender, EventArgs e) => UpdateQuantity(DinnerQuantityEntry, 1);
        private void OnDinnerPlus10Clicked(object? sender, EventArgs e) => UpdateQuantity(DinnerQuantityEntry, 10);
        private void OnDinnerMinus1Clicked(object? sender, EventArgs e) => UpdateQuantity(DinnerQuantityEntry, -1);
        private void OnDinnerMinus10Clicked(object? sender, EventArgs e) => UpdateQuantity(DinnerQuantityEntry, -10);

        private void OnConfirmClicked(object? sender, EventArgs e)
        {
            if (_viewModel == null) return;

            // Update quantities from entries
            int breakfastQty = int.TryParse(BreakfastQuantityEntry.Text, out int b) ? b : 0;
            int lunchQty = int.TryParse(LunchQuantityEntry.Text, out int l) ? l : 0;
            int dinnerQty = int.TryParse(DinnerQuantityEntry.Text, out int d) ? d : 0;

            _viewModel.BreakfastQuantity = breakfastQty;
            _viewModel.LunchQuantity = lunchQty;
            _viewModel.DinnerQuantity = dinnerQty;

            // Calculate total before processing payment
            decimal total = _viewModel.CalculateTotal();
            bool success = _viewModel.ProcessPayment();

            if (success)
            {
                ErrorMessageLabel.IsVisible = false;
                ErrorMessageLabel.Text = "";
                
                // Reset quantities
                BreakfastQuantityEntry.Text = "0";
                LunchQuantityEntry.Text = "0";
                DinnerQuantityEntry.Text = "0";
                UpdateTotal();
                
                // Show success message with the total that was paid
                Application.Current?.MainPage?.DisplayAlert("Success", $"Successfully paid {total:F2} RSD for canteen", "OK");
                
                // Notify parent that payment was processed (this will navigate to HomeView)
                PaymentProcessed?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ErrorMessageLabel.Text = "Insufficient balance";
                ErrorMessageLabel.IsVisible = true;
            }
        }
    }
}
