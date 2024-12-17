using DefendersDeck.Domain.DTOs;
using DefendersDeck.Domain.Entities;

namespace DefendersDeck.Business.Mappers
{
    internal static class CardMapper
    {
        public static CardDto ToCardDto(this Card card)
        {
            var cardDto = new CardDto
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                ImageUrl = card.ImageUrl,
                Type = card.Type,
                Amount = card.Amount,
                Price = card.Price,
                Turns = card.Turns,
            };

            return cardDto;
        }

        public static CardForMarketDto ToCardForMarketDto(this Card card, bool inDeck)
        {
            var cardDto = card.ToCardDto();

            var cardForMarketDto = new CardForMarketDto
            {
                Card = cardDto,
                InDeck = inDeck,
            };

            return cardForMarketDto;
        }

        public static Card ToCard(this CardDto cardDto)
        {
            var card = new Card 
            {
                Id = cardDto.Id,
                Name = cardDto.Name,
                Description = cardDto.Description,
                ImageUrl = cardDto.ImageUrl,
                Type = cardDto.Type,
                Amount = cardDto.Amount,
                Price = cardDto.Price,
                Turns = cardDto.Turns,
            };

            return card;
        }
    }
}
