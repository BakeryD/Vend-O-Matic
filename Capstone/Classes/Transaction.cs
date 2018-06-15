using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Transaction
    {
        public VMItem Item { get; }

        public DateTime Time { get; }

        public Transaction(VMItem item)
        {
            Time = DateTime.Today;
            Item = item;

        }



    }
}
