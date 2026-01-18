using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class DormPaymentView : ContentPage
    {
        public DormPaymentView()
        {
            InitializeComponent();
            BindingContext = new DormPaymentViewModel();
        }
    }
}
