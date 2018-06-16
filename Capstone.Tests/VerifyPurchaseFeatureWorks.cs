using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;


namespace Capstone.Tests
{
    [TestClass]
    public class VerifyPurchaseFeatureWorks
    {
        private string itemA1 = "A1";
      public static  FileReader fr = new FileReader();
       public static VendingMachine vm = new VendingMachine(fr.Stock());


        [TestMethod]
        public void Verify_Purchases_Update_Inventory()
        {
            //string itemA1 = "A1";
            //FileReader fr = new FileReader();
            //VendingMachine vm = new VendingMachine(fr.Stock());
            decimal costOfA1=vm.Inventory[itemA1][0].Price;

            vm.AcceptCash((int)costOfA1 + 1);

            vm.BuyItem(itemA1);
            var qtyOfItemA1 = vm.Inventory[itemA1].Count;


            Assert.AreEqual(4, qtyOfItemA1);




        }

        [TestMethod]
        public void Verify_Purchase_CannotBeMadeWith_InsufficientFunds()
        {
            var didPurchaseWork = vm.BuyItem(itemA1);

            Assert.IsFalse(didPurchaseWork);


        }
    }
}
