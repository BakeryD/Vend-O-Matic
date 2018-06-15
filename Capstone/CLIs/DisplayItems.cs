using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.CLIs
{
    public class DisplayItems
    {
        public static VendingMachine vm { get; private set; }

        public void InventoryMenu()
        {
            while (true)
            {
                
                Console.WriteLine(vm.DisplayAll());
                Console.WriteLine("SubMenu 1");
                Console.WriteLine();
                Console.WriteLine("     1 - okay, I know what I want");
                Console.WriteLine("     n - nvm, I'm good(quit)");


                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Purchase submenu = new Purchase(vm);
                    submenu.PurchaseMenu();
                }

                else if (input == "n")
                {
                    Console.WriteLine("Bye, Felicia");
                    break; //<-- breaks off the whileloop and because it's the end of the line for the entire method so it pops off the stack and returns to the main menu
                }
                else
                {
                    Console.WriteLine("Whaaaat???");
                }
            }
        }

        public DisplayItems(VendingMachine vm)
        {
            DisplayItems.vm = vm;
        }
    }
}
