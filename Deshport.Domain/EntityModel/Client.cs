

using Deshport.Domain.Enum;

namespace Deshport.Domain.EntityModel
{
    public class Client
    {
        public int Id { get; set; }
        public byte[]? Picture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }        
        public string Password { get; set; }
        public Roles Role { get; set; } = Roles.User;
        public DateTime DateRegistration { get; set; }

    }
}
