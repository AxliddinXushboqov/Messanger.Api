using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;
using Messanger.Api.Services.Orchestrations.UserSecurities;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccauntController : RESTFulController
    {
        private readonly IUserSecurityOrchestrationService userSecurityOrchestrationService;

        public AccauntController(IUserSecurityOrchestrationService userSecurityOrchestrationService) =>
            this.userSecurityOrchestrationService = userSecurityOrchestrationService;

        [HttpPost("Register")]
        public async ValueTask<ActionResult<User>> Register(User user) =>
             await this.userSecurityOrchestrationService.AddUserAsync(user);

        [HttpPost("Login")]
        public ActionResult<UserToken> Login(string phoneNumber) =>
            this.userSecurityOrchestrationService.LoginUser(phoneNumber);
    }
}