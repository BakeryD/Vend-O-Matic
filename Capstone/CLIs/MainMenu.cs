using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.CLIs
{
    public class MainMenu
    {
        public static VendingMachine vm { get; private set; }

        public void Display()
        {
           // PrintHeader();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you need to...");

                Console.WriteLine("     1 - figure out what you want?");
                Console.WriteLine("     2 - nah, just gimme the food.");
                Console.WriteLine("     f - lemme finish!");

                Console.Write("I'd like to ");
                string userInput = Console.ReadLine();

                //change due variables 


                if (userInput == "1")
                {
                    DisplayItems inventoryMenu = new DisplayItems(MainMenu.vm);

                   inventoryMenu.InventoryMenu();
                }
                else if (userInput == "2")
                {
                    Purchase submenu = new Purchase(vm);
                    submenu.PurchaseMenu();
                }
                else if (userInput == "f")
                {
                    Console.WriteLine();
                    Console.WriteLine("Change Due: $" + vm.Balance);

                    decimal updatedChange = vm.Balance;
                    int quarters = 0;
                    int dimes = 0;
                    int nickles = 0;
                    int pennies = 0;

                    do
                    {
                        quarters = (int)(updatedChange / .25M);
                        updatedChange = updatedChange - (decimal)(quarters * .25);

                        dimes = (int)(updatedChange / .1M);
                        updatedChange = updatedChange - (decimal)(dimes * .1);

                        nickles = (int)(updatedChange / .05M);
                        updatedChange = updatedChange - (decimal)(nickles * .05);

                        pennies = (int)(updatedChange / .01M);
                        updatedChange = updatedChange - (decimal)(pennies * .01);

                    }
                    while (updatedChange > 0);




                    Console.WriteLine("Bye, Felicia");
                    Console.Beep(3007,500);




                    break;
                }
                else
                {
                    Console.WriteLine("Whaaaat???");
                }
            }
        }

        private static void PrintHeader()
        {

            Console.WriteLine("WELCOME TO THE TECH ELEVATOR CAFETERIA");
        }
        public MainMenu(VendingMachine vm)
        {
            MainMenu.vm = vm;
        }
    }
}
