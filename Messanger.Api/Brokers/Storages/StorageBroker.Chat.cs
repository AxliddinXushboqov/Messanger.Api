using Messanger.Api.Models.Foundations.Chats;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Chat> Chats { get; set; }

        public async ValueTask<Chat> InsertChatAsync(Chat chat) =>
            await InsertAsync(chat);

        public IQueryable<Chat> SelectAllChats()
        {
            return this.Chats
                .Include(p => p.Messages)
                .AsQueryable();
        }

        public async ValueTask<Chat> SelectChatByIdAsync(Guid id) =>
            await SelectAsync<Chat>(id);

        public async ValueTask<Chat> UpdateChatAsync(Chat chat) =>
            await UpdateAsync(chat);

        public async ValueTask<Chat> DeleteChatAsync(Chat chat) =>
            await DeleteAsync(chat);
    }
}
