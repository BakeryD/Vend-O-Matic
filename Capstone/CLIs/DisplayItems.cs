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
<<<<<<< HEAD
                Console.WriteLine();
                Console.WriteLine("     1 - okay, I know what I want");
                Console.WriteLine("     n - nvm, I'm good(quit)");
=======
                Console.WriteLine("     1 - okay, I know what I want");   // Display Inventory
                Console.WriteLine("     b - nvm, I'm good");
>>>>>>> f3a42062cc204ce652b204688c91443142d6c7b2

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Purchase submenu = new Purchase();
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
