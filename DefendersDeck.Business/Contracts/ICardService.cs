using DefendersDeck.Domain.DTOs;
using DefendersDeck.Domain.Entities;
using DefendersDeck.Domain.Responses;

namespace DefendersDeck.Business.Contracts
{
    public interface ICardService
    {
        Task<BaseResponse<IEnumerable<CardDto>>> GetCardsAsync();
        Task<BaseResponse<IEnumerable<CardForMarketDto>>> GetCardsForMarketAsync(int id);
        Task<BaseResponse<IEnumerable<CardDto>>> GetDeckAsync(int id);
        Task<BaseResponse<bool>> AddCardToDeck(int cardId, int userId);
        Task<IEnumerable<Card>> GenerateDeck();
    }
}
