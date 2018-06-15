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

                private static void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE TECH ELEVATOR CAFETERIA");
        }


        // public Transaction BuyItem(string location,)

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
        }



        public Transaction BuyItem(string userSelection)
        {
            var itemToBuy = Inventory[userSelection][0];
            this.Inventory[userSelection].Remove(itemToBuy);
            Balance -= itemToBuy.Price;


            return null;

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
