namespace DefendersDeck.App.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void OnMarketButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MarketPage");
    }
}