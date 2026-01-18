using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _studentNumber;
        private readonly IAuthService _authService;

        public LoginViewModel()
        {
            _authService = new MockAuthService();
            LoginCommand = new Command(OnLogin, CanLogin);
            
            PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(StudentNumber))
                {
                    LoginCommand.ChangeCanExecute();
                }
            };
        }

        public string StudentNumber
        {
            get => _studentNumber;
            set => SetProperty(ref _studentNumber, value);
        }

        public Command LoginCommand { get; }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(StudentNumber) && !IsBusy;
        }

        private void OnLogin()
        {
            if (string.IsNullOrWhiteSpace(StudentNumber))
            {
                return;
            }

            IsBusy = true;

            try
            {
                var student = _authService.Login(StudentNumber);
                
                if (student != null)
                {
                    Shell.Current.GoToAsync("//HomeView");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
