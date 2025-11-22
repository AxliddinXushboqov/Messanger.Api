using Messanger.Api.Brokers.Storages;
using Messanger.Api.Models.Foundations.Messages;

namespace Messanger.Api.Services.Foundations.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IStorageBroker storageBroker;

        public MessageService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Message> AddMessageAsync(Message message)
        {
            message.Id = Guid.NewGuid();
            message.CreatedDate = DateTime.Now;
            return await this.storageBroker.InsertMessageAsync(message);
        }
        public async ValueTask<Message> RetrieveMessageByidAsync(Guid id) =>
            await this.storageBroker.SelectMessageByidAsync(id);

        public async ValueTask<Message> ModifyMessageAsync(Message message) =>
           await this.storageBroker.UpdateMessageAsync(message);

        public async ValueTask<Message> RemoveMessageAsync(Guid id)
        {
            var message = await this.storageBroker.SelectMessageByidAsync(id);

            return await this.storageBroker.DeleteMessageAsync(message);
        }
    }
}