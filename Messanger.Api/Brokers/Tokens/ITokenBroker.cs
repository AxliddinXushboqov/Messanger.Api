using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;

namespace Messanger.Api.Brokers.Tokens
{
    public interface ITokenBroker
    {
        UserToken GenerateJWTToken(User user);
    }
}