using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.CLIs;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainmenu = new MainMenu();
            mainmenu.Display(); // <-- tells main menu to display first

        }
    }
}
