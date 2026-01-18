using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(TopUpView), typeof(TopUpView));
            Routing.RegisterRoute(nameof(DormPaymentView), typeof(DormPaymentView));
            Routing.RegisterRoute(nameof(CanteenView), typeof(CanteenView));
            Routing.RegisterRoute(nameof(ActivateCardView), typeof(ActivateCardView));
            Routing.RegisterRoute(nameof(ImportCardView), typeof(ImportCardView));
            Routing.RegisterRoute(nameof(LaundryView), typeof(LaundryView));
            Routing.RegisterRoute(nameof(PartyView), typeof(PartyView));
            Routing.RegisterRoute(nameof(TransactionsView), typeof(TransactionsView));
        }
    }
}
