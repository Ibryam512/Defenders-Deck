using DefendersDeck.Domain.Responses;

namespace DefendersDeck.Business.Contracts
{
    public interface IAuthService
    {
        Task<BaseResponse<string>> Register(Domain.Requests.RegisterRequest request);
        Task<BaseResponse<string>> Login(Domain.Requests.LoginRequest request);
    }
}
