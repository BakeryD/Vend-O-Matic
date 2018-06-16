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
                Console.WriteLine("Purchase Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("<1> Insert Money"); //ADD MONEY TO BALANCE
                Console.WriteLine("<2> Buy Item");   //CHOSE ITEM
                Console.WriteLine("<3> View Inventory Menu");   //VIEW INVENTORY MENU
                Console.WriteLine("<4> Quit to Main Menu");  //QUIT TO MAIN MENU
                Console.WriteLine($"Total Amount Inserted: {vm.Balance.ToString("C2")}");
                Console.WriteLine();

                Console.Write(">");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Current Balance: $" + vm.Balance);
                    Console.Write("Please insert money: $ ");

                    int input = GetInteger(Console.ReadLine());


                    vm.AcceptCash(input);
                    Console.WriteLine("Current Balance: $ " + vm.Balance);
                    Console.WriteLine();
                    Console.WriteLine();

                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Current Balance: $" + vm.Balance);
                    Console.Write(">Enter Slot Code:  ");
                    string userSelection = Console.ReadLine().ToUpper();

                    if (!vm.Inventory.ContainsKey(userSelection))
                    {
                        Console.WriteLine("Invalid Slot Code. Please Try Again.");
                    }
                    else if (vm.Inventory[userSelection].Count == 0)
                    {
                        Console.Beep(1955, 45);
                        Console.Beep(1955, 50);
                        Console.WriteLine("Sold out. Womp womp womp.");
                    }
                    else if (vm.Inventory[userSelection][0].Price > vm.Balance)
                    {
                        Console.Beep(1955, 65);
                        Console.Beep(1955, 50);
                        Console.WriteLine("Insufficient funds. Womp womp womp.");
                    }

                    else
                    {
                        vm.BuyItem(userSelection);


                        Console.Clear();
                        Console.WriteLine("VENDING....");
                        Console.WriteLine();
                        System.Threading.Thread.Sleep(400);
                        Console.WriteLine("Item Dispensed.");
                        Console.WriteLine();
                    }




                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    DisplayItems inventoryMenu = new DisplayItems(MainMenu.vm);
                    inventoryMenu.InventoryMenu();


                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    MainMenu mainMenu = new MainMenu(vm);
                    mainMenu.Display();

                    //<-- breaks off the whileloop and because it's the end of the line for the entire method so it pops off the stack and returns to the main menu
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try Again");
                }
            }
        }
        public Purchase(VendingMachine vm)
        {
            Purchase.vm = vm;
        }
    }


}
