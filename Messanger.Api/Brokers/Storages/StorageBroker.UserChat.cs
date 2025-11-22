using Messanger.Api.Models.Foundations.UserChats;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<UserChat> userChats { get; set; }
        public async ValueTask<UserChat> InsertUserChatAsync(UserChat userChat) =>
            await InsertAsync(userChat);

        public IQueryable<UserChat> SelectAllUserChats() =>
            SelectAll<UserChat>();

        public async ValueTask<UserChat> SelectUserChatByIdAsync(Guid id) =>
            await SelectAsync<UserChat>(id);

        public async ValueTask<UserChat> UpdateUserChatAsync(UserChat userChat) =>
            await UpdateAsync(userChat);

        public async ValueTask<UserChat> DeleteUserChatAsync(UserChat userChat) =>
            await DeleteAsync(userChat);
    }
}