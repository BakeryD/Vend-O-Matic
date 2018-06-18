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

        public FileWriter FW { get; }

        public decimal Balance { get; private set; }

        public List<Transaction> TransactionLog { get; private set; }

        public List<VMItem> ItemsBought { get; private set; }

        /// <summary>
        /// Accepts money from user and adds to balance.
        /// </summary>
        /// <param name="input"></param>
        public void AcceptCash(int input)
        {
            this.Balance += input;

        }


        /// <summary>
        /// Creates a new Vending Machine object with an inventory, a file writer, a list of items bought, and a list of transactions. 
        /// </summary>
        /// <param name="inventory"></param>
        public VendingMachine(Dictionary<string, List<VMItem>> inventory)
        {
            this.Inventory = inventory;
            ItemsBought = new List<VMItem>();
            this.FW = new FileWriter();
            this.TransactionLog = new List<Transaction>();
        }


        /// <summary>
        /// Removes an item from inventory, subtracts cost from user balance, and logs the transaction.
        /// </summary>
        /// <param name="userSelection">Slot number</param>
        public bool BuyItem(string userSelection)
        {
            if (Inventory[userSelection].Count == 0)       //  PREVENT THE USER FROM GETTING AN ERROR
            {
                return false;
            }

            //IDENTIFY ITEM TO BUY
            var itemToBuy = Inventory[userSelection][0];

            if (itemToBuy.Price > Balance)                        //  "                                       "
            {
                return false;
            }

            else if (!Inventory.ContainsKey(userSelection))      //  "                                       "
            {
                return false;
            }

            //ADD TO LIST OF ITEMS BOUGHT
            this.ItemsBought.Add(itemToBuy);
            //REMOVE FROM INVENTORY
            this.Inventory[userSelection].Remove(itemToBuy);
            //REMOVE COST OF ITEM FROM MONEY USER INSERTED
            Balance -= itemToBuy.Price;
            //IF USER HAS BOUGHT THE LAST ITEM, REMOVE FROM INVENTORY DICTIONARY
            if (Inventory[userSelection].Count==0)
            {
                Inventory.Remove(userSelection);
            }
            //CREATE A TRANSACTION OBJECT
            Transaction itemSold = new Transaction(itemToBuy);
            //ADD TRANSACTION TO LOG
            FW.AddLog(itemSold);
            this.TransactionLog.Add(itemSold);
            //return true;
            return true;

        }

        /// <summary>
        /// Returns the current inventory as a string.
        /// </summary>
        /// <returns></returns>
        public string DisplayAll()
        {

            int qty = 1;
            string output = $"{"Slot",5}{"Name",18}{"Price",20}{"Qty",7}\n ";

            foreach (var item in Inventory)
            {
                string currentKey = item.Key;
                output += currentKey + "\t";
                var currentSlot = item.Value;

                for (int i = 0; i < currentSlot.Count; i++)
                {
                    if (i == 0)
                    {
                        output += $"{currentSlot[i].Name,18}  \t {currentSlot[i].Price.ToString("C2"),10}  \t";
                    }
                    else
                    {
                        qty++;
                    }
                }

                output += qty.ToString() + "\n\r ";
                qty = 1;


            }
            return output;
        }



    }
}
