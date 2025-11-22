using Messanger.Api.Brokers.Storages;
using Messanger.Api.Models.Foundations.Users;

namespace Messanger.Api.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<User> AddUserAsync(User user) =>
            await this.storageBroker.InsertUserAsync(user);
        public IQueryable<User> RetrieveAllUsers() =>
             this.storageBroker.SelectAllUsers();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
            await this.storageBroker.SelectUserByIdAsync(userId);

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.storageBroker.UpdateUserAsync(user);

        public async ValueTask<User> RemoveUserAsync(User user) =>
            await this.storageBroker.DeleteUserAsync(user);
    }
}