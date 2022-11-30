

namespace Deshport.Domain.EntityModel
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? Picture { get; set; }
        
    }

    
}
