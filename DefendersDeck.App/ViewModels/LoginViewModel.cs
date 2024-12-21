using DefendersDeck.App.Services;
using DefendersDeck.Domain.Requests;
using System.Windows.Input;

namespace DefendersDeck.App.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        private string username = "", password = "";
        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;

            LoginCommand = new Command(async () => await Login());
        }

        private async Task Login()
        {
            var request = new LoginRequest(Username, Password);
            var result = await _authService.LoginAsync(request);

            if (result)
            {
                await Shell.Current.DisplayAlert("Success", "Login Successful!", "OK");

                // Navigate to another page (e.g., HomePage)
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Login failed. Please try again.", "OK");
            }
        }
    }
}
