using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.CLIs
{
    public class MainMenu
    {
        public void Display()
        {
            PrintHeader();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you need to...");
                Console.WriteLine(" 1 - figure out what you want?");  
                Console.WriteLine(" 2 - nah, just gimme the food.");
                Console.WriteLine(" b - nvm, I'm good");

                Console.Write("I'd like to ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    DisplayItems submenu = new DisplayItems();
                    submenu.Display();
                }
                else if (input == "2")
                {
                    Purchase submenu = new Purchase();
                    submenu.Display();
                }
                else if (input == "b")
                {
                    Console.WriteLine("Bye, Felicia");
                    break;
                }
                else
                {
                    Console.WriteLine("Whaaaat???");
                }
            }
        }

        private void PrintHeader()
        {

            Console.WriteLine("WELCOME TO THE TECH ELEVATOR CAFETERIA");
        }
    }
}
