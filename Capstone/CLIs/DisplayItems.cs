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
                Console.Clear();

                Console.WriteLine(vm.DisplayAll());
                Console.WriteLine("Inventory Menu"); //INVENTORY MENU
                Console.WriteLine();
                Console.WriteLine("<1> Return to Purchase Menu"); //GO TO PURCHASE MENU
                Console.WriteLine("<2> Quit to main menu"); // QUIT TO MAIN MENU


                Console.Write(">");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Purchase submenu = new Purchase(vm);
                    submenu.PurchaseMenu();
                }
                else if (userInput == "2")
                {
                    Console.Clear();

                    Console.WriteLine("Bye, Felicia");
                    break; //<-- breaks off the whileloop and because it's the end of the line for the entire method so it pops off the stack and returns to the main menu
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("C'MON, THERE'S ONLY 2 CHOICES!");
                    Console.WriteLine();
                }
            }
        }

        public DisplayItems(VendingMachine vm)
        {
            DisplayItems.vm = vm;
        }
    }
}
