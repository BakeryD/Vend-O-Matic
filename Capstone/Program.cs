using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Capstone.CLIs;
=======
using Capstone.Classes;
>>>>>>> 73f9b3778d95b15467234f03d511a21132a08f7f

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            MainMenu mainmenu = new MainMenu();
            mainmenu.Display(); // <-- tells main menu to display first
=======
            FileReader fr = new FileReader();
          var inventory=  fr.Stock();
            VendingMachine vm = new VendingMachine(inventory);
>>>>>>> 73f9b3778d95b15467234f03d511a21132a08f7f

        }
    }
}
