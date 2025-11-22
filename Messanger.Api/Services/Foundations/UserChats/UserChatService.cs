using Messanger.Api.Brokers.Storages;
using Messanger.Api.Models.Foundations.UserChats;

namespace Messanger.Api.Services.Foundations.UserChats
{
    public class UserChatService : IUserChatService
    {
        private readonly IStorageBroker storageBroker;

        public UserChatService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<UserChat> AddUserChatAsync(UserChat userChat)
        {
            userChat.Id = Guid.NewGuid();
            return await this.storageBroker.InsertUserChatAsync(userChat);
        }

        public IQueryable<UserChat> RetrieveAllUserChats() =>
            this.storageBroker.SelectAllUserChats();

        public async ValueTask<UserChat> RetrieveUserChatByIdAsync(Guid id) =>
            await this.storageBroker.SelectUserChatByIdAsync(id);

        public async ValueTask<UserChat> ModifyUserChatAsync(UserChat userChat) =>
            await this.storageBroker.UpdateUserChatAsync(userChat);

        public async ValueTask<UserChat> RemoveUserChatAsync(Guid id)
        {
            var userChat = await this.storageBroker.SelectUserChatByIdAsync(id);

            return await this.storageBroker.DeleteUserChatAsync(userChat);
        }
    }
}