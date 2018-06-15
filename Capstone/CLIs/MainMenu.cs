﻿using System;
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
                Console.WriteLine("     n - nvm, I'm good");

                Console.Write("I'd like to ");
                string userInput = Console.ReadLine();

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
                else if (userInput == "n")
                {
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
