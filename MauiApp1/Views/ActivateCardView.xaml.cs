namespace MauiApp1.Views
{
    public partial class ActivateCardView : ContentPage
    {
        public ActivateCardView()
        {
            InitializeComponent();
        }

        private async void OnActivateCardClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Card activated successfully (demo)", "OK");
        }
    }
}
