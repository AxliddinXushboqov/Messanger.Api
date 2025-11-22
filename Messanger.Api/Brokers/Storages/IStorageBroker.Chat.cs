using Messanger.Api.Models.Foundations.Chats;

namespace Messanger.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Chat> InsertChatAsync(Chat chat);
        IQueryable<Chat> SelectAllChats();
        ValueTask<Chat> SelectChatByIdAsync(Guid id);
        ValueTask<Chat> UpdateChatAsync(Chat chat);
        ValueTask<Chat> DeleteChatAsync(Chat chat);
    }
}