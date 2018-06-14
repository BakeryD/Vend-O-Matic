﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Capstone.CLIs;

namespace Capstone.Classes
{
    public class FileReader
    {
        

        public string Path { get; }

        public Dictionary<string , List<VMItem> > Stock()
        {
            Dictionary<string , List<VMItem>> inventory = new Dictionary<string , List<VMItem>>();
            

            try
            {
                using (StreamReader sr= new StreamReader(Path))
                {

                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();

                        string[] item = line.Split('|');

                        string location = item[0];
                        string name = item[1];
                        decimal price = decimal.Parse(item[2]);
                        ItemType type = ItemType.Gum;

                        if (item[3].ToLower() == "chip")
                        {
                            type = ItemType.Chip;
                        }
                        else if (item[3].ToLower() == "drink")
                        {
                            type = ItemType.Drink;
                        }
                        else if (item[3].ToLower() == "candy")
                        {
                            type = ItemType.Candy;
                        }
                        

                        if (inventory.ContainsKey(location))
                        {
                            inventory[location].Add(new VMItem(name, type, price));

                        }
                        else
                        {
                            List<VMItem> itemsInSlot = new List<VMItem>();
                            itemsInSlot.Add(new VMItem(name, type, price));

                            inventory.Add(location, itemsInSlot);
                        }
                    }

                }


            }
            catch (IOException ex)
            {

                Console.WriteLine(ex.Message+"\n\n BYE BYE NOW...");
            }
            return inventory;


        }

        public FileReader()
        {
            this.Path = System.IO.Path.Combine(Environment.CurrentDirectory, "StartingInventory.csv");
        }



    }
}
