using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.CLIs
{
    public class Purchase
    {
        public static int GetInteger(string message)
        {
            string userInput = message;
            int intValue = 0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Please insert money that folds, not jingles. Try again.");
                }

                if (int.TryParse(message, out intValue))
                {
                    return intValue;
                }
                //Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out intValue));

            return intValue;

        }

        public static VendingMachine vm { get; private set; }

        public void PurchaseMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Purchase Flow");
                Console.WriteLine("What would you like to do?");


                Console.WriteLine("     m - enter dolla$");
                Console.WriteLine("     p - select product");
                Console.WriteLine("     w - wait, lemme look again");
                Console.WriteLine("     d - I'm done, let's go back to the main menu");

                Console.Write("I'd like to ");
                string userInput = Console.ReadLine();

                if (userInput == "m")
                {
                    Console.Clear();
                    Console.WriteLine("Current Balance: $" + vm.Balance);
                    Console.Write("Please insert money: $ ");

                    int input = GetInteger(Console.ReadLine());

                        vm.AcceptCash(input);
                        Console.WriteLine("Current Balance: $ " + vm.Balance);
                        Console.WriteLine();
                    

                }
                else if (userInput == "p")
                {
                    Console.Clear();
                    Console.WriteLine("Current Balance: $" + vm.Balance);
                    Console.Write("Whatchu tryna get?: ");
                    string userSelection = Console.ReadLine().ToUpper();

                    if (!vm.Inventory.ContainsKey(userSelection))
                    {
                        Console.WriteLine("Invalid slot id. Please try again.");

                    }
                    else if (vm.Inventory[userSelection].Count == 0)
                    {
                        Console.WriteLine("Sold out. Womp womp.");
                    }
                    else if (vm.Inventory[userSelection][0].Price > vm.Balance) 
                    {
                        Console.WriteLine("Insufficient funds. Womp womp.");
                    }
                    else
                    {
                        vm.BuyItem(userSelection);
                        Console.WriteLine("Success! Nom nom nom.");
                    }




                }
                else if (userInput == "w")
                {
                    Console.Clear();
                    DisplayItems inventoryMenu = new DisplayItems(MainMenu.vm);
                    inventoryMenu.InventoryMenu();


                }
                else if (userInput == "d")
                {

                    Console.WriteLine("Bye, Felicia");
                    Console.Clear();
                    MainMenu mainMenu = new MainMenu(vm);
                    mainMenu.Display();

                    //<-- breaks off the whileloop and because it's the end of the line for the entire method so it pops off the stack and returns to the main menu
                }
                else
                {
                    Console.WriteLine("Whaaaat???");
                }
            }
        }
        public Purchase(VendingMachine vm)
        {
            Purchase.vm = vm;
        }
    }


}
