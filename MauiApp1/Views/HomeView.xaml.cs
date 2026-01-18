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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HomeViewModel vm)
            {
                vm.RefreshBalance();
            }
        }

    }
}
