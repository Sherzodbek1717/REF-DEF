using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REF00013457.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Remaining { get; set; }
        public int Priority { get; set; }
        public int PurchaseLevel { get; set; }
        public decimal Price { get; set; }
    }
}
