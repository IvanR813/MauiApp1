using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class TopUpView : ContentPage
    {
        public TopUpView()
        {
            InitializeComponent();
            BindingContext = new TopUpViewModel();
        }
    }
}
