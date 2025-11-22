using Messanger.Api.Models.Foundations.Chats;

namespace Messanger.Api.Services.Foundations.Chats
{
    public interface IChatService
    {
        ValueTask<Chat> AddChatAsync(Chat chat);
        IQueryable<Chat> RetrieveAllChats();
        ValueTask<Chat> RetrieveChatByIdAsync(Guid id);
        ValueTask<Chat> ModifyChatAsync(Chat chat);
        ValueTask<Chat> RemoveChatAsync(Guid id);
    }
}