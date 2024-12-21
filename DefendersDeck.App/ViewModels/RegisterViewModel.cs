using DefendersDeck.App.Services;
using DefendersDeck.Domain.Requests;
using System.Windows.Input;

namespace DefendersDeck.App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
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

        public ICommand RegisterCommand { get; private set; }

        public RegisterViewModel(AuthService authService)
        {
            _authService = authService;

            RegisterCommand = new Command(async () => await Register());
        }

        private async Task Register()
        {
            var request = new RegisterRequest(Username, Password);
            var result = await _authService.RegisterAsync(request);

            if (result)
            {
                await Shell.Current.DisplayAlert("Success", "Registration Successful!", "OK");

                // Navigate to another page (e.g., HomePage)
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Registration failed. Please try again.", "OK");
            }
        }
    }
}
