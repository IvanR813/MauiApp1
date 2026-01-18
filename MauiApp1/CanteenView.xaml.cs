namespace MauiApp1
{
    public partial class CanteenView : ContentPage
    {
        private CanteenViewModel _viewModel;

        public CanteenView()
        {
            InitializeComponent();
            _viewModel = new CanteenViewModel();
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

        private void UpdateBalanceLabel()
        {
            if (BalanceLabel != null && _viewModel != null)
            {
                BalanceLabel.Text = _viewModel.GetBalanceString();
            }
        }

        private void OnPaymentProcessed(object? sender, EventArgs e)
        {
            UpdateBalanceLabel();
        }
    }
}
