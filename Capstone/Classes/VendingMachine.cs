﻿using System;
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
            if (Inventory[userSelection].Count == 0)       //  "                                       "
            {
                return false;
            }

            //IDENTIFY ITEM TO BUY
            var itemToBuy = Inventory[userSelection][0];

            if (itemToBuy.Price > Balance)                        //  PREVENT THE USER FROM GETTING AN ERROR
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
