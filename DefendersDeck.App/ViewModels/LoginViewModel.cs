using DefendersDeck.App.Services;
using DefendersDeck.Domain.Requests;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DefendersDeck.App.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _authService;

        private string username = "", password = "";
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;

            LoginCommand = new Command(async () => await Login());
        }

        private async Task<bool> Login()
        {
            var request = new LoginRequest(Username, Password);
            return await _authService.LoginAsync(request);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
