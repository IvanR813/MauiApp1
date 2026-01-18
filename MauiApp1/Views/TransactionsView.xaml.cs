using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class TransactionsView : ContentPage
    {
        public TransactionsView()
        {
            InitializeComponent();
            BindingContext = new TransactionsViewModel();
        }
    }
}
