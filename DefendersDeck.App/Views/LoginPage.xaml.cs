using DefendersDeck.App.ViewModels;

namespace DefendersDeck.App.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();

		BindingContext = loginViewModel;
	}
}