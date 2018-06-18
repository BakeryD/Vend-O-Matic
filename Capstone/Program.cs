using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.CLIs;
using Capstone.Classes;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileReader fr = new FileReader();
            var inventory = fr.Stock();

            VendingMachine vm = new VendingMachine(inventory);

            MainMenu mainMenu = new MainMenu(vm);
            mainMenu.Display();    // <-- tells main menu to display first
        }
    }
}
