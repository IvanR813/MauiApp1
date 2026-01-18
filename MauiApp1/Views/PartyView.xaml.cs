using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class PartyView : ContentPage
    {
        public PartyView()
        {
            InitializeComponent();
            BindingContext = new PartyViewModel();
        }
    }
}
