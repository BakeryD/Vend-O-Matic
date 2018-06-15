using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.CLIs;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, List<VMItem>> Inventory { get; private set; }

        public decimal Balance { get; private set; }

        public List<Transaction> TransactionLog { get; private set; }

<<<<<<< HEAD
                private static void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE TECH ELEVATOR CAFETERIA");
        }
=======
        public List<VMItem> ItemsBought { get; private set; }

>>>>>>> 25451e5c73789c58dc271f9cf2df53b91bd4ef0f



 

            //public int GiveChange()

        /// <summary>
        /// accepts money input from user and returns balance 
        /// </summary>
        /// <param name="input"></param>
        public void AcceptCash(int input)
        {
            this.Balance += input;
        }


        //
        public VendingMachine(Dictionary<string, List<VMItem>> inventory)
        {
            this.Inventory = inventory;
            ItemsBought = new List<VMItem>();
        }



        public Transaction BuyItem(string userSelection)
        {
            var itemToBuy = Inventory[userSelection][0];
            this.ItemsBought.Add(itemToBuy);
            this.Inventory[userSelection].Remove(itemToBuy);
            Balance -= itemToBuy.Price;
            Transaction itemSold = new Transaction(itemToBuy);

<<<<<<< HEAD

            return null;
=======
            return itemSold;
>>>>>>> 25451e5c73789c58dc271f9cf2df53b91bd4ef0f

        }


        public string DisplayAll()
        {

            int Qty = 0;
            string output = " ";

            foreach (var item in Inventory)
            {
                string currentKey = item.Key;
                output += currentKey + "\t";
                var currentSlot = item.Value;

                for (int i = 0; i < currentSlot.Count; i++)
                {
                    if (i == 0)
                    {
                        output += currentSlot[i].Name + "\t" + currentSlot[i].Price.ToString() + "\t";
                    }
                    else
                    {
                        Qty++;
                    }


                }

                output += Qty.ToString() + "\n\r ";
                Qty = 0;


            }
            return output;
        }



    }
}
