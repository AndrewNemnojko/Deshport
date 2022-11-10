

namespace Deshport.Domain.ViewModel.Product
{
    public class ProductView
    {
        public int Id { get; set; }
        public byte[]? Picture { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
