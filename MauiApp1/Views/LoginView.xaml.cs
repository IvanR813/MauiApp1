using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class LoginView : ContentPage
    {
        private async void OnGoToPage2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeView());
        }
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
