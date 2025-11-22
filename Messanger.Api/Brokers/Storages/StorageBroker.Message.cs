using Messanger.Api.Models.Foundations.Messages;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Message> Messages { get; set; }

        public async ValueTask<Message> InsertMessageAsync(Message message) =>
            await InsertAsync(message);

        public async ValueTask<Message> SelectMessageByidAsync(Guid id) =>
            await SelectAsync<Message>(id);

        public async ValueTask<Message> UpdateMessageAsync(Message message) =>
            await UpdateAsync(message);

        public async ValueTask<Message> DeleteMessageAsync(Message message) =>
            await DeleteMessageAsync(message);
    }
}