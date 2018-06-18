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
            while (true)
            {
                //Console.Clear();

                Console.WriteLine("Main Menu");
                Console.WriteLine();
                Console.WriteLine("<1> View Inventory");    //VIEW INVENTORY
                Console.WriteLine("<2> Purchase Menu.");    //PURCHASE MENU
                Console.WriteLine("<Q> Finish Transaction/Quit");    //FINISH TRANSACTION & QUIT
                Console.WriteLine();
                Console.Write(">");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.Clear();
                    InventoryMenu inventoryMenu = new InventoryMenu(MainMenu.vm);

                    inventoryMenu.Display();
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    PurchaseMenu submenu = new PurchaseMenu(vm);
                    submenu.Display();
                }
                else if (userInput.ToUpper() == "Q")
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Change Due: $" + vm.Balance);

                    decimal updatedChange = vm.Balance;
                    int quarters = 0;
                    int dimes = 0;
                    int nickles = 0;
                    int pennies = 0;

                    quarters = (int)(updatedChange / .25M);
                    updatedChange = updatedChange - (decimal)(quarters * .25);

                    dimes = (int)(updatedChange / .1M);
                    updatedChange = updatedChange - (decimal)(dimes * .1);

                    nickles = (int)(updatedChange / .05M);
                    updatedChange = updatedChange - (decimal)(nickles * .05);

                    // pennies = (int)(updatedChange / .01M);
                    //updatedChange = updatedChange - (decimal)(pennies * .01);
                    Console.WriteLine($"Quarters: {quarters}");
                    Console.WriteLine($"Dimes: {dimes}");
                    Console.WriteLine($"Nickles: {nickles}");
                    Console.WriteLine($"Pennies: {pennies}");
                    Console.WriteLine();


                    foreach (var item in vm.ItemsBought)
                    {
                        Console.WriteLine($"You bought a {item.Type}!");
                        System.Threading.Thread.Sleep(600);
                        Console.Beep(1955, 65);
                        Console.Beep(1955, 50);
                        Console.WriteLine();
                        Console.WriteLine(item.MakeSound());
                        Console.WriteLine();
                        System.Threading.Thread.Sleep(950);
                    }
                    Console.WriteLine();
                    Console.WriteLine("BYE-BYE :)");
                    System.Threading.Thread.Sleep(400);
                    Console.Beep(1307, 75);
                    Console.SetWindowSize(104, 24);
                    System.Threading.Thread.Sleep(400);
                    Console.Beep(1300, 75);
                    Console.SetWindowSize(52, 12);
                    System.Threading.Thread.Sleep(400);
                    Console.Beep(1107, 75);
                    Console.SetWindowSize(26, 6);
                    System.Threading.Thread.Sleep(400);
                    Console.Beep(907, 75);
                    Console.SetWindowSize(13, 3);
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("INVALID INPUT");
                }
            }
        }


        public MainMenu(VendingMachine vm)
        {
            MainMenu.vm = vm;
        }
    }
}
