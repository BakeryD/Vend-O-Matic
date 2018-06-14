using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.CLIs
{
    public class DisplayItems
    {
        public void Display()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("SubMenu 1");
                Console.WriteLine()
                Console.WriteLine("     1 - okay, I know what I want");
                Console.WriteLine("     b - nvm, I'm good");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Purchase submenu = new Purchase();
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
