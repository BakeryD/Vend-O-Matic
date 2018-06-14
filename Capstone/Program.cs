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


            Dictionary<string, List<VMItem>> inventory = fr.Stock();


<<<<<<< HEAD
            VendingMachine vm = new VendingMachine(inventory);

            

            //MainMenu mainmenu = new MainMenu();
            MainMenu.Display(); // <-- tells main menu to display first






=======

            //
            FileReader fr = new FileReader();
            var inventory=  fr.Stock();
            VendingMachine vm = new VendingMachine(inventory);

>>>>>>> 2447354d6149bbf2496103a163fedcc865fca857

            Console.WriteLine(vm.DisplayAll());

        }
    }
}
