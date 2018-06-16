using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Transaction
    {
        /// <summary>
        /// The item that was bought/sold.
        /// </summary>
        public VMItem Item { get; }
        /// <summary>
        /// Time of transaction.
        /// </summary>
        public DateTime Time { get; }

        public Transaction(VMItem item)
        {
            Time = DateTime.Now;
            Item = item;
        }



    }
}
