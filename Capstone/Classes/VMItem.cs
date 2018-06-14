using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VMItem
    {
        public string Name { get; }
       // public string Type { get; }
        public ItemType Type { get; }
        public decimal Price { get; }

        public VMItem(string name,  ItemType type,decimal price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

    }
}
