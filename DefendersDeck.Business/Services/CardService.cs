using DefendersDeck.Business.Contracts;
using DefendersDeck.Business.Mappers;
using DefendersDeck.DataAccess.Contracts;
using DefendersDeck.Domain.DTOs;
using DefendersDeck.Domain.Entities;
using DefendersDeck.Domain.Responses;

namespace DefendersDeck.Business.Services
{
    public class CardService(IRepository<Card> cardRepository, IRepository<User> userRepository) : ICardService
    {
        public async Task<BaseResponse<IEnumerable<CardDto>>> GetCardsAsync()
        {
            var cards = await cardRepository.GetAllAsync();

            var cardsResponse = cards.Select(card => card.ToCardDto());

            return BaseResponse<IEnumerable<CardDto>>.Successful(cardsResponse);
        }

        public async Task<BaseResponse<IEnumerable<CardForMarketDto>>> GetCardsForMarketAsync(int id)
        {
            var cards = await cardRepository.GetAllAsync();
            var deck = await GetDeck(id);

            var cardsForMarket = cards
                                    .Concat(deck)
                                    .DistinctBy(card => card.Id)
                                    .Select(card => card.ToCardForMarketDto(inDeck: deck.Any(c => c.Id == card.Id)))
                                    .OrderBy(card => card.InDeck);

            return BaseResponse<IEnumerable<CardForMarketDto>>.Successful(cardsForMarket);
        }

        public async Task<BaseResponse<IEnumerable<CardDto>>> GetDeckAsync(int id)
        {
            var deck = await GetDeck(id);

            var deckResponse = deck.Select(card => card.ToCardDto());

            return BaseResponse<IEnumerable<CardDto>>.Successful(deckResponse);
        }

        private async Task<IEnumerable<Card>> GetDeck(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user is null)
            {
                return [];
            }

            return user.Cards;
        }

        public async Task<IEnumerable<Card>> GenerateDeck()
        {
            var cards = await cardRepository.GetAllAsync();

            var attackCards = cards.Where(x => x.Type == Domain.Enums.CardType.Attack).Take(2);
            var defenseCards = cards.Where(x => x.Type == Domain.Enums.CardType.Defense).Take(2);
            var healingCards = cards.Where(x => x.Type == Domain.Enums.CardType.Healing).Take(1);

            var deck = attackCards.Concat(defenseCards).Concat(healingCards);

            return deck;
        }
    }
}
