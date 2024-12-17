using DefendersDeck.App.ViewModels;

namespace DefendersDeck.App.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel registerViewModel)
	{
        InitializeComponent();

        BindingContext = registerViewModel;
	}
}