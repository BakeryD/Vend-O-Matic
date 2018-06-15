using System;
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
        
        public void AddLog(Transaction t)
        {
            using (StreamWriter sw=new StreamWriter(Path,true))
            {
                if (File.Exists(Path))
                {
                    File.Create(Path);
                }
                var itemSold = t.Item.Name;
                var itemType = t.Item.Type;
                var itemPrice = t.Item.Price;
                var time = t.Time;
                sw.WriteLine($"{itemSold}\t\t{itemType.ToString()}\t\t{itemPrice.ToString("C2")}\t\t SOLD AT {time} ");

            }

        }
        public FileWriter()
        {
            this.Path = System.IO.Path.Combine(Environment.CurrentDirectory, "Log.txt");
        }

    }
}
