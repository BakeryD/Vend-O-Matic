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
                Console.WriteLine("Purchase Flow");
                Console.WriteLine("Please insert money: ");
                //string input = Console.ReadLine();
                Console.WriteLine("Current Money Provided: ");
                Console.WriteLine();


                


                Console.WriteLine("     m - enter mo' money");
                Console.WriteLine("     p - select product");
                Console.WriteLine("     w - wait, lemme look again");
                Console.WriteLine("     n - nvm, I'm good(quit)");

                Console.Write("I'd like to ");
                string input = Console.ReadLine();

                if (input == "m")
                {
                    Console.WriteLine("Performing feed money");
                }
                else if (input == "p")
                {
                    Console.WriteLine("Performing select product");
                }
                else if (input == "w")
                {
                    DisplayItems submenu = new DisplayItems();
                    submenu.Display();
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
    }
}
