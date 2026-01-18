using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}
