using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class FileWriter
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

            try
            {
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    var itemSold = t.Item.Name;
                    var itemType = t.Item.Type;
                    var itemPrice = t.Item.Price;
                    var time = t.Time;
                    sw.WriteLine($"{itemSold,20}{itemType.ToString(),10}{itemPrice.ToString("C2"),15}\t SOLD AT \t{time} ");
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GenerateSalesReport(List<Transaction> salesLog)
        {
            string salesLogPath= System.IO.Path.Combine(Environment.CurrentDirectory, "SalesReport.txt");
            using (StreamWriter sw = new StreamWriter(salesLogPath, false))
            {
                try
                {
                    decimal totalSales = 0;
                    sw.WriteLine($"\tItem Name\t  Type\t\tPrice\t\tTime of Transaction");
                    foreach (var sale in salesLog)
                    {
                        var itemName = sale.Item.Name;
                        var itemType = sale.Item.Type;
                        var itemPrice = sale.Item.Price;// .ToString("C2");
                        var timeofSale = sale.Time;
                        totalSales += itemPrice;
                        sw.WriteLine($"{itemName,20}{itemType.ToString(),10}{itemPrice.ToString("C2"),15}\t SOLD AT {timeofSale}");

                    }
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine($"Total Sales on {DateTime.Today.Day}.{DateTime.Today.Month}.2018 = {totalSales.ToString("C2")}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message+"Error Generating Sales Report"); ;
                }
            }
        }
        public FileWriter()
        {
            this.Path = System.IO.Path.Combine(Environment.CurrentDirectory, "Log.txt");
        }

    }
}
