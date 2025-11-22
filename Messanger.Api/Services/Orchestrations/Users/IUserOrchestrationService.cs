using System.Security.Claims;
using Messanger.Api.Models.Foundations.Users;

namespace Messanger.Api.Services.Orchestrations.Users
{
    public interface IUserOrchestrationService
    {
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> RetrieveUserByIdAsync(Guid userId);
        ValueTask<User> RetrieveUserProfileAsync(ClaimsPrincipal user);
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<string> ModifyUserImageAsync(Guid userid, MemoryStream memoryStream);
        ValueTask<User> RemoveUserAsync(Guid id);
    }
}