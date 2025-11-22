using Messanger.Api.Brokers.Files;
using Messanger.Api.Brokers.Storages;
using Messanger.Api.Brokers.Tokens;
using Messanger.Api.Services.Foundations.Chats;
using Messanger.Api.Services.Foundations.Files;
using Messanger.Api.Services.Foundations.Messages;
using Messanger.Api.Services.Foundations.Tokens;
using Messanger.Api.Services.Foundations.UserChats;
using Messanger.Api.Services.Foundations.Users;
using Messanger.Api.Services.Orchestrations.Users;
using Messanger.Api.Services.Orchestrations.UserSecurities;

namespace Messanger.Api
{
    public class RegisterServices
    {
        public void AddFoundationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IChatService, ChatService>();
            builder.Services.AddTransient<IFileService, FileService>();
            builder.Services.AddTransient<IMessageService, MessageService>();
            builder.Services.AddTransient<ITokenService, TokenService>();
            builder.Services.AddTransient<IUserChatService, UserChatService>();
            builder.Services.AddTransient<IUserService, UserService>();
        }

        public void AddOrchestrationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserOrchestrationService, UserOrchestrationService>();
            builder.Services.AddTransient<IUserSecurityOrchestrationService, UserSecurityOrchestrationService>();
        }

        public void AddBrokers(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IStorageBroker, StorageBroker>();
            builder.Services.AddTransient<IFileBroker, FileBroker>();
            builder.Services.AddTransient<ITokenBroker, TokenBroker>();
        }
    }
}