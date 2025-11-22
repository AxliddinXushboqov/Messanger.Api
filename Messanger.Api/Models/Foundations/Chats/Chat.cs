using Messanger.Api.Models.Foundations.Messages;
using Messanger.Api.Models.Foundations.UserChats;

namespace Messanger.Api.Models.Foundations.Chats
{
    public class Chat
    {
        public Guid ChatId { get; set; }
        public virtual ICollection<UserChat> UserChats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}