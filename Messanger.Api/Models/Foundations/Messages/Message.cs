using System.Text.Json.Serialization;
using Messanger.Api.Models.Foundations.Chats;
using Messanger.Api.Models.Foundations.Users;

namespace Messanger.Api.Models.Foundations.Messages
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ChatId { get; set; }
        [JsonIgnore]
        public virtual Chat Chat { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
