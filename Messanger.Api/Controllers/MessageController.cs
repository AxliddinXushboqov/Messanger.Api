using Messanger.Api.Models.Foundations.Messages;
using Messanger.Api.Services.Foundations.Messages;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : RESTFulController
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpPost]
        
        public async ValueTask<ActionResult<Message>> PostMessageAsync(Message message) =>
            await this.messageService.AddMessageAsync(message);

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<Message>> GetMessageByIdAsync(Guid id) =>
            await this.messageService.RetrieveMessageByidAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<Message>> PutMessageAsync(Message message) =>
            await this.messageService.ModifyMessageAsync(message);

        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<Message>> DeleteMessageByIdAsync(Guid id) =>
            await this.messageService.RemoveMessageAsync(id);
    }
}
