using Messanger.Api.Models.Foundations.UserChats;

namespace Messanger.Api.Services.Foundations.UserChats
{
    public interface IUserChatService
    {
        ValueTask<UserChat> AddUserChatAsync(UserChat userChat);
        IQueryable<UserChat> RetrieveAllUserChats();
        ValueTask<UserChat> RetrieveUserChatByIdAsync(Guid id);
        ValueTask<UserChat> ModifyUserChatAsync(UserChat userChat);
        ValueTask<UserChat> RemoveUserChatAsync(Guid id);
    }
}
