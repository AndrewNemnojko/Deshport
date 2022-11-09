using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deshport.Domain.EntityModel
{
    public class Product
    {
        public int Id { get; set; }
        public byte[]? Picture { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
