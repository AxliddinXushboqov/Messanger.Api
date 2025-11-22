using Messanger.Api.Models.Foundations.Messages;

namespace Messanger.Api.Services.Foundations.Messages
{
    public interface IMessageService
    {
        ValueTask<Message> AddMessageAsync(Message message);
        ValueTask<Message> RetrieveMessageByidAsync(Guid id);
        ValueTask<Message> ModifyMessageAsync(Message message);
        ValueTask<Message> RemoveMessageAsync(Guid id);
    }
}