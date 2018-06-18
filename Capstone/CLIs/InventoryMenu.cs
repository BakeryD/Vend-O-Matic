using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.CLIs
{
    public class InventoryMenu
    {
        public static VendingMachine vm { get; private set; }

        public void Display()
        {
            while (true)
            {

                Console.WriteLine(vm.DisplayAll());
                Console.WriteLine("Inventory Menu"); //INVENTORY MENU
                Console.WriteLine();
                Console.WriteLine("<1> Purchase Menu"); //GO TO PURCHASE MENU
                Console.WriteLine("<2> Quit to main menu"); // QUIT TO MAIN MENU


                Console.Write(">");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.Clear();
                    PurchaseMenu submenu = new PurchaseMenu(vm);
                    submenu.Display();
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

        public InventoryMenu(VendingMachine vm)
        {
            CLIs.InventoryMenu.vm = vm;
        }
    }
}
