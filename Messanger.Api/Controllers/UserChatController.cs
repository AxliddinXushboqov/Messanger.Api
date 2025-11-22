using Messanger.Api.Models.Foundations.UserChats;
using Messanger.Api.Services.Foundations.UserChats;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserChatController : RESTFulController
    {
        private readonly IUserChatService userChatService;

        public UserChatController(IUserChatService userChatService) =>
            this.userChatService = userChatService;

        [HttpPost]
        public async ValueTask<ActionResult<UserChat>> PostUserChatAsync(UserChat userChat)
        {
            try
            {
                var storeduserchat = await this.userChatService.AddUserChatAsync(userChat);

                return Created(storeduserchat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<UserChat>> GetAllUserChats()
        {
            var allUserChats = this.userChatService.RetrieveAllUserChats();

            return Ok(allUserChats);
        }

        [HttpGet]
        [Route("ById")]
        public async ValueTask<ActionResult<UserChat>> GetUserChatByidAsync(Guid id)
        {
            try
            {
                return await this.userChatService.RetrieveUserChatByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<UserChat>> PutUserChatAsync(UserChat newUserChat)
        {
            try
            {
                return await this.userChatService.ModifyUserChatAsync(newUserChat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async ValueTask<ActionResult<UserChat>> DeleteUserChatAsync(Guid id)
        {
            try
            {
                return await this.userChatService.RemoveUserChatAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
