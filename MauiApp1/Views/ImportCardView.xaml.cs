namespace MauiApp1.Views
{
    public partial class ImportCardView : ContentPage
    {
        public ImportCardView()
        {
            InitializeComponent();
        }

        private async void OnImportCardClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Card linked to account (demo)", "OK");
        }
    }
}
