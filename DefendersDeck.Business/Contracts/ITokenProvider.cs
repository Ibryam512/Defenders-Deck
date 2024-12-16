using DefendersDeck.Domain.Entities;

namespace DefendersDeck.Business.Contracts
{
    public interface ITokenProvider
    {
        string CreateToken(User user);
    }
}
