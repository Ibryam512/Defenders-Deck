using DefendersDeck.Domain.Requests;
using DefendersDeck.Domain.Responses;
using System.Net.Http.Json;

namespace DefendersDeck.App.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5066/")
            };
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var plainResponse = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            var response = await plainResponse.Content.ReadFromJsonAsync<BaseResponse<string>>();

            return response!.Success;
        }
    }
}
