using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class CanteenView : ContentPage
    {
        public CanteenView()
        {
            InitializeComponent();
            BindingContext = new CanteenViewModel();
        }
    }
}
