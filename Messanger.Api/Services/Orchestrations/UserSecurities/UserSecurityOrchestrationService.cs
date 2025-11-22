using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;
using Messanger.Api.Services.Foundations.Tokens;
using Messanger.Api.Services.Foundations.Users;

namespace Messanger.Api.Services.Orchestrations.UserSecurities
{
    public class UserSecurityOrchestrationService : IUserSecurityOrchestrationService
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public UserSecurityOrchestrationService(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            var existsUser = this.userService.RetrieveAllUsers().FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber);

            if (existsUser == null)
            {
                user.UserId = Guid.NewGuid();
                return await this.userService.AddUserAsync(user);
            }
            else
                throw new Exception("User Already Exists");
        }

        public UserToken LoginUser(string PhoneNumber)
        {
            IQueryable<User> allUsers = this.userService.RetrieveAllUsers();

            var result = allUsers.FirstOrDefault(retrievedUser =>
                retrievedUser.PhoneNumber.Equals(PhoneNumber));

            if (result != null)
            {
                return this.tokenService.AddToken(result);
            }
            else
                throw new Exception("User Not Found");
        }
    }
}