using Messanger.Api.Models.Foundations.Messages;

namespace Messanger.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Message> InsertMessageAsync(Message message);
        ValueTask<Message> SelectMessageByidAsync(Guid id);
        ValueTask<Message> UpdateMessageAsync(Message message);
        ValueTask<Message> DeleteMessageAsync(Message message);
    }
}