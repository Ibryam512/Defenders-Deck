using DefendersDeck.App.Services;
using DefendersDeck.Domain.DTOs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DefendersDeck.App.ViewModels
{
    public partial class MarketViewModel : BaseViewModel
    {
        private readonly CardService _cardService;

        private bool isLoading;

        public ObservableCollection<CardForMarketDto> Cards { get; set; } = [];

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        public ICommand BuyCommand { get; }
        public ICommand NavigateHomeCommand { get; }

        public MarketViewModel(CardService cardService)
        {
            _cardService = cardService;

            BuyCommand = new Command<CardForMarketDto>(OnBuy);
            NavigateHomeCommand = new Command(OnNavigateHome);

            LoadCards();
        }

        private async void LoadCards()
        {
            IsLoading = true;

            var cards = await _cardService.LoadMarketCardsAsync();
            Cards = new(cards);
            OnPropertyChanged(nameof(Cards));

            IsLoading = false;
        }

        private async void OnBuy(CardForMarketDto cardForMarket)
        {
            if (cardForMarket == null || cardForMarket.InDeck)
                return;

            var success = await _cardService.BuyCard(cardForMarket);

            if (success)
            {
                var card = Cards.Single(x => x.Card.Id == cardForMarket.Card.Id);
                card.InDeck = true;
                OnPropertyChanged(nameof(Cards));
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Not enough amount", "OK");
            }
        }

        private async void OnNavigateHome()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
