﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.CLIs;

namespace Capstone.Classes
{
  public  class VendingMachine
    {
        public Dictionary<string,List<VMItem>> Inventory { get; private set; }

        public int Balance { get; private set; }

        

        


       // public Transaction BuyItem(string location,)

        public VendingMachine(Dictionary<string, List<VMItem>> inventory)
        {
            this.Inventory = inventory;
        }
        public Transaction BuyItem()
        {

            return null;

        }
        public string DisplayAll()
        {

            int Qty = 0;
           string output=null;

            foreach (var item in Inventory)
            {
                string currentKey = item.Key;
                output += currentKey+"\t";
                var currentSlot = item.Value;

                for (int i = 0; i < currentSlot.Count; i++)
                {
                    if (i==0)
                    {
                        output += currentSlot[i].Name + "\t" + currentSlot[i].Price.ToString() + "\t";
                    }
                    else
                    {
                        Qty++;
                    }


                }

                output += Qty.ToString()+"\n\r ";
                Qty = 0;


            }
            return output;
        }



    }
}
