﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
  public  class FileWriter
    {
        public string Path { get; }
        /// <summary>
        /// Adds the item sold, type, price and time of transaction to Log.txt
        /// </summary>
        /// <param name="t"></param>
        public void AddLog(Transaction t)
        {

                if (!File.Exists(Path))
                {
                    StreamWriter sw = new StreamWriter(Path, true);
                    sw.WriteLine($"\tItem Name\t  Type\t\tPrice\t\tTime of Transaction");
                    sw.Dispose();
                }
            
            using (StreamWriter sw=new StreamWriter(Path,true))
            {

                var itemSold = t.Item.Name;
                var itemType = t.Item.Type;
                var itemPrice = t.Item.Price;
                var time = t.Time;
                sw.WriteLine($"{itemSold,20}{itemType.ToString(),10}{itemPrice.ToString("C2"),15}\t SOLD AT \t{time} ");
            }

        }
        public FileWriter()
        {
            this.Path = System.IO.Path.Combine(Environment.CurrentDirectory, "Log.txt");
        }

    }
}
