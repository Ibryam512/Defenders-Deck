using DefendersDeck.App.ViewModels;

namespace DefendersDeck.App.Views;

public partial class MarketPage : ContentPage
{
	public MarketPage(MarketViewModel marketViewModel)
	{
		InitializeComponent();
		BindingContext = marketViewModel;
	}
}