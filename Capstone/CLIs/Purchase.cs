using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.CLIs
{
    public class Purchase
    {
        public void Display()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Purchase");
                Console.WriteLine("     1 - feed money");
                Console.WriteLine("     2 - select product");
                Console.WriteLine("     3 - wait, lemme look again");
                Console.WriteLine("     b - nvm, I'm good");

                Console.Write("I'd like to ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Performing feed money");
                }
                else if (input == "2")
                {
                    Console.WriteLine("Performing select product");
                }
                else if (input == "3")
                {
                    DisplayItems submenu = new DisplayItems();
                    submenu.Display();
                }
                else if (input == "b")
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
    }
}
