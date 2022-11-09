

namespace Deshport.Domain.EntityModel
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }        
        public string Password { get; set; }
        public DateTime DateRegistration { get; set; }

    }
}
