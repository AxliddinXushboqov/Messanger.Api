using Messanger.Api.Models.Foundations.UserChats;

namespace Messanger.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<UserChat> InsertUserChatAsync(UserChat userChat);
        IQueryable<UserChat> SelectAllUserChats();
        ValueTask<UserChat> SelectUserChatByIdAsync(Guid id);
        ValueTask<UserChat> UpdateUserChatAsync(UserChat userChat);
        ValueTask<UserChat> DeleteUserChatAsync(UserChat userChat);
    }
}