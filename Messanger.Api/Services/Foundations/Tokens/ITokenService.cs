using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;

namespace Messanger.Api.Services.Foundations.Tokens
{
    public interface ITokenService
    {
        UserToken AddToken(User user);
    }
}