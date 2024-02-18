using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWork
{
    public  class product
    {
        public string Name { get; set; }
        public decimal Price{ get; set; }

        public product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
