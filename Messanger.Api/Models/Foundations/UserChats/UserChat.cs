using System.Text.Json.Serialization;
using Messanger.Api.Models.Foundations.Chats;
using Messanger.Api.Models.Foundations.Users;

namespace Messanger.Api.Models.Foundations.UserChats
{
    public class UserChat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public Guid ChatId { get; set; }
        [JsonIgnore]
        public virtual Chat Chat { get; set; }
    }
}