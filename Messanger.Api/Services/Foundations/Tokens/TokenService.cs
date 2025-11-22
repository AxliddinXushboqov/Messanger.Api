using Messanger.Api.Brokers.Tokens;
using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;

namespace Messanger.Api.Services.Foundations.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly ITokenBroker tokenBroker;

        public TokenService(ITokenBroker tokenBroker) =>
            this.tokenBroker = tokenBroker;

        public UserToken AddToken(User user) =>
            this.tokenBroker.GenerateJWTToken(user);
    }
}