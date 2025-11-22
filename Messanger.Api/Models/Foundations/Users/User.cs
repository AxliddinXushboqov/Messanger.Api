using Messanger.Api.Models.Foundations.Messages;
using Messanger.Api.Models.Foundations.UserChats;

namespace Messanger.Api.Models.Foundations.Users
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string image { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<UserChat> UserChats { get; set; }
        public virtual ICollection<Message> UserMessages { get; set; }
    }
}