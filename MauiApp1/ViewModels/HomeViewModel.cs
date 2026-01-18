using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private string _studentName;
        private string _faculty;
        private decimal _balance;
        private readonly IAuthService _authService;
        private readonly IWalletService _walletService;

        public HomeViewModel()
        {
            _authService = new MockAuthService();
            _walletService = new MockWalletService();
            
            LoadData();
            
            GoToTopUpCommand = new Command(async () => await Shell.Current.GoToAsync("//TopUpView"));
            GoToCanteenCommand = new Command(async () => await Shell.Current.GoToAsync("//CanteenView"));
            GoToDormCommand = new Command(async () => await Shell.Current.GoToAsync("//DormPaymentView"));
            GoToActivateCardCommand = new Command(async () => await Shell.Current.GoToAsync("//ActivateCardView"));
            GoToImportCardCommand = new Command(async () => await Shell.Current.GoToAsync("//ImportCardView"));
            GoToLaundryCommand = new Command(async () => await Shell.Current.GoToAsync("//LaundryView"));
            GoToPartyCommand = new Command(async () => await Shell.Current.GoToAsync("//PartyView"));
            GoToTransactionsCommand = new Command(async () => await Shell.Current.GoToAsync("//TransactionsView"));
        }

        public string StudentName
        {
            get => _studentName;
            set => SetProperty(ref _studentName, value);
        }

        public string Faculty
        {
            get => _faculty;
            set => SetProperty(ref _faculty, value);
        }

        public decimal Balance
        {
            get => _balance;
            set => SetProperty(ref _balance, value);
        }

        public Command GoToTopUpCommand { get; }
        public Command GoToCanteenCommand { get; }
        public Command GoToDormCommand { get; }
        public Command GoToActivateCardCommand { get; }
        public Command GoToImportCardCommand { get; }
        public Command GoToLaundryCommand { get; }
        public Command GoToPartyCommand { get; }
        public Command GoToTransactionsCommand { get; }

        private void LoadData()
        {
            var student = _authService.GetCurrentStudent();
            if (student != null)
            {
                StudentName = student.FullName;
                Faculty = student.Faculty;
            }
            else
            {
                StudentName = "Guest";
                Faculty = "N/A";
            }

            Balance = _walletService.GetBalance();
        }
    }
}
