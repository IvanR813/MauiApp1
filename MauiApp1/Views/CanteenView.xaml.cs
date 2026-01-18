namespace MauiApp1.Views
{
    public partial class CanteenView : ContentPage
    {
        private MauiApp1.CanteenViewModel _viewModel;

        public CanteenView()
        {
            InitializeComponent();
            _viewModel = new MauiApp1.CanteenViewModel();
            BindingContext = _viewModel;
            
            // Update balance label
            UpdateBalanceLabel();
            
            // Set view model for payment view
            if (PaymentView != null)
            {
                PaymentView.SetViewModel(_viewModel);
                PaymentView.PaymentProcessed += OnPaymentProcessed;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateBalanceLabel();
        }

        private void UpdateBalanceLabel()
        {
            if (BalanceLabel != null && _viewModel != null)
            {
                BalanceLabel.Text = _viewModel.GetBalanceString();
            }
        }

        private async void OnPaymentProcessed(object? sender, EventArgs e)
        {
            UpdateBalanceLabel();
            
            // Navigate back to HomeView to refresh the balance there
            await Shell.Current.GoToAsync("//HomeView");
        }
    }
}
