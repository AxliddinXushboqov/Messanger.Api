using Messanger.Api.Models.Foundations.Chats;
using Messanger.Api.Services.Foundations.Chats;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : RESTFulController
    {
        private readonly IChatService chatService;

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Chat>> PostChatAsync(Chat chat) =>
            await this.chatService.AddChatAsync(chat);

        [HttpGet]
        public ActionResult<IQueryable<Chat>> GetAllChats()
        {
            var allChats = this.chatService.RetrieveAllChats();
            return Ok(allChats);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<Chat>> GetChatByIdAsync(Guid id) =>
            await this.chatService.RetrieveChatByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<Chat>> PutChatAsync(Chat chat) =>
            await this.chatService.ModifyChatAsync(chat);

        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<Chat>> DeleteChatByIdAsync(Guid id) =>
            await this.chatService.RemoveChatAsync(id);
    }
}