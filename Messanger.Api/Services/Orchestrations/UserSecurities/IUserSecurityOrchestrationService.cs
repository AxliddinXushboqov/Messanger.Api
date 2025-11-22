using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;

namespace Messanger.Api.Services.Orchestrations.UserSecurities
{
    public interface IUserSecurityOrchestrationService
    {
        ValueTask<User> AddUserAsync(User user);
        public UserToken LoginUser(string PhoneNumber);
    }
}