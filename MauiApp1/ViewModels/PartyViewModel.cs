namespace MauiApp1.ViewModels
{
    public class PartyViewModel : BaseViewModel
    {
        private DateTime _partyDate;
        private string _roomNumber;
        private TimeSpan _partyTime;

        public PartyViewModel()
        {
            PartyDate = DateTime.Now;
            PartyTime = DateTime.Now.TimeOfDay;
            SchedulePartyCommand = new Command(OnScheduleParty, CanScheduleParty);
            
            PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(PartyDate) || 
                    e.PropertyName == nameof(RoomNumber) || 
                    e.PropertyName == nameof(PartyTime))
                {
                    SchedulePartyCommand.ChangeCanExecute();
                }
            };
        }

        public DateTime PartyDate
        {
            get => _partyDate;
            set => SetProperty(ref _partyDate, value);
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set => SetProperty(ref _roomNumber, value);
        }

        public TimeSpan PartyTime
        {
            get => _partyTime;
            set => SetProperty(ref _partyTime, value);
        }

        public Command SchedulePartyCommand { get; }

        private bool CanScheduleParty()
        {
            return !string.IsNullOrWhiteSpace(RoomNumber) && !IsBusy;
        }

        private async void OnScheduleParty()
        {
            if (string.IsNullOrWhiteSpace(RoomNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a room number", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                var dateTime = PartyDate.Date + PartyTime;
                var message = $"Party scheduled successfully.\nPorter has been notified (demo).\n\nRoom: {RoomNumber}\nDate: {PartyDate:dd.MM.yyyy}\nTime: {PartyTime:hh\\:mm}";
                
                await Application.Current.MainPage.DisplayAlert("Success", message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
