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
        public ItemType Type { get; }
        public decimal Price { get; }

        public string MakeSound()
        {
            switch (Type)
            {
                case ItemType.Candy:
                    return "Munch Munch, Yum!";
                case ItemType.Chip:
                    return "Crunch Crunch, Yum!";
                case ItemType.Drink:
                    return "Glug Glug, Yum!";
                case ItemType.Gum:
                    return "Chew Chew, Yum!";

            }
            return "";
        }

        public VMItem(string name,  ItemType type,decimal price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

    }
}
