using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Services.Orchestrations.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserOrchestrationService userOrchestrationService;

        public UserController(IUserOrchestrationService userOrchestrationService)
        {
            this.userOrchestrationService = userOrchestrationService;
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            var allUsers = this.userOrchestrationService.RetrieveAllUsers();

            return Ok(allUsers);
        }

        [HttpGet]
        [Route("ById")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid id) =>
            await this.userOrchestrationService.RetrieveUserByIdAsync(id);

        [HttpGet("Profile")]
        [Authorize(Roles = "Admin,User")]
        public async ValueTask<ActionResult<User>> GetUserProfileAsync()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");

            if (!Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                return BadRequest("UserId is not in a valid format.");
            }

            return await this.userOrchestrationService.RetrieveUserProfileAsync(User);
        }

        [HttpPut]
        [Route("Put User")]
        public async ValueTask<ActionResult<User>> PutUserAsync(User user) =>
            await this.userOrchestrationService.ModifyUserAsync(user);

        [HttpPut]
        [Route("Put User Image")]
        public async ValueTask<string> PutuserImageAsync(Guid userId, IFormFile imageFile)
        {
            MemoryStream memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return await this.userOrchestrationService.ModifyUserImageAsync(userId, memoryStream);
        }

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeleteUserByIdAsync(Guid id) =>
            await this.userOrchestrationService.RemoveUserAsync(id);
    }
}