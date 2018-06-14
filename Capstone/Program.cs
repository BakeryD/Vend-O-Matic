using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileReader fr = new FileReader();
          var inventory=  fr.Stock();
            VendingMachine vm = new VendingMachine(inventory);
            Console.WriteLine(vm.Inventory);
        }
    }
}
