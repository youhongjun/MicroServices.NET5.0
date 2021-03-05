using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service.Models
{
    public class ProductModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public int Total => Price * Inventory;
    }
}
