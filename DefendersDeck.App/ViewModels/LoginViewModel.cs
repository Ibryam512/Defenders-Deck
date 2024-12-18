﻿using DefendersDeck.App.Services;
using DefendersDeck.Domain.Requests;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DefendersDeck.App.ViewModels
{
    public partial class LoginViewModel : INotifyPropertyChanged
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

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
