﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
  public  class VendingMachine
    {
        public Dictionary<string,List<VMItem>> Inventory { get; }

        public int Balance { get; private set; }


       // public Transaction BuyItem(string location,)

        public VendingMachine(Dictionary<string, List<VMItem>> inventory)
        {
            this.Inventory = inventory;
        }




    }
}