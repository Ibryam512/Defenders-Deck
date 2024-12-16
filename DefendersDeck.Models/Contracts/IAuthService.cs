using DefendersDeck.Domain.Responses;

namespace DefendersDeck.Domain.Contracts
{
    public interface IAuthService
    {
        Task<BaseResponse<string>> Register(Domain.Requests.RegisterRequest request);
        Task<BaseResponse<string>> Login(Domain.Requests.LoginRequest request);
    }
}
