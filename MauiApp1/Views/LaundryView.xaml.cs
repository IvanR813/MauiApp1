namespace MauiApp1.Views
{
    public partial class LaundryView : ContentPage
    {
        public LaundryView()
        {
            InitializeComponent();
            LoadTimeSlots();
        }

        private void LoadTimeSlots()
        {
            var timeSlots = new List<string>
            {
                "08:00 - 10:00",
                "10:00 - 12:00",
                "12:00 - 14:00",
                "14:00 - 16:00",
                "16:00 - 18:00",
                "18:00 - 20:00"
            };

            foreach (var slot in timeSlots)
            {
                TimeSlotPicker.Items.Add(slot);
            }
        }

        private async void OnScheduleClicked(object sender, EventArgs e)
        {
            if (TimeSlotPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Please select a time slot", "OK");
                return;
            }

            var selectedSlot = TimeSlotPicker.Items[TimeSlotPicker.SelectedIndex];
            await DisplayAlert("Success", $"Laundry scheduled successfully for {selectedSlot}", "OK");
        }
    }
}
