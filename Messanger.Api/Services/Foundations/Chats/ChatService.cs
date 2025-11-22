using Messanger.Api.Brokers.Storages;
using Messanger.Api.Models.Foundations.Chats;

namespace Messanger.Api.Services.Foundations.Chats
{
    public class ChatService : IChatService
    {
        private readonly IStorageBroker storageBroker;

        public ChatService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Chat> AddChatAsync(Chat chat)
        {
            chat.ChatId = Guid.NewGuid();
            return await this.storageBroker.InsertChatAsync(chat);
        }

        public IQueryable<Chat> RetrieveAllChats() =>
            this.storageBroker.SelectAllChats();

        public async ValueTask<Chat> RetrieveChatByIdAsync(Guid id) =>
            await this.storageBroker.SelectChatByIdAsync(id);

        public async ValueTask<Chat> ModifyChatAsync(Chat chat) =>
            await this.storageBroker.UpdateChatAsync(chat);

        public async ValueTask<Chat> RemoveChatAsync(Guid id)
        {
            var chat = await this.storageBroker.SelectChatByIdAsync(id);

            return await this.storageBroker.DeleteChatAsync(chat);
        }
    }
}
