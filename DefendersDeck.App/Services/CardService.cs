using DefendersDeck.Domain.Constants;
using DefendersDeck.Domain.DTOs;
using DefendersDeck.Domain.Responses;
using System.Net.Http.Json;

namespace DefendersDeck.App.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient;

        public CardService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5066/"),
            };
        }

        public async Task<IEnumerable<CardForMarketDto>> LoadMarketCardsAsync()
        {
            var token = await SecureStorage.GetAsync(BaseConstants.JwtKey);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var plainResponse = await _httpClient.GetAsync("api/cards/market");
            var response = await plainResponse.Content.ReadFromJsonAsync<BaseResponse<IEnumerable<CardForMarketDto>>>();

            if (!response.Success)
            {
                return [];
            }

            return response.Data!;
        }

        public async Task<bool> BuyCard(CardForMarketDto cardForMarket)
        {
            var token = await SecureStorage.GetAsync(BaseConstants.JwtKey);

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var plainResponse = await _httpClient.PostAsync($"api/cards/deck/{cardForMarket.Card.Id}", null);
            var response = await plainResponse.Content.ReadFromJsonAsync<BaseResponse<bool>>();

            if (!response.Success)
            {
                return false;
            }

            return response.Data;
        }
    }
}
