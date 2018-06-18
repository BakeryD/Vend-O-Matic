using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;


namespace Capstone.Tests
{
    [TestClass, TestCategory("Purchase Feature")]
    public class PurchaseFeatureTests
    {
       private static FileReader fr = new FileReader();
       private VendingMachine vm = new VendingMachine(fr.Stock());
        [TestMethod]
        public void Verify_Purchases_Update_Inventory()
        {
            string itemA1 = "A1";

            int initialQtyOfItemA1 = vm.Inventory[itemA1].Count;
            decimal costOfA1 = vm.Inventory[itemA1][0].Price;


            vm.AcceptCash((int)costOfA1 + 1);

            vm.BuyItem(itemA1);
            var qtyOfItemA1 = vm.Inventory[itemA1].Count;


            Assert.AreEqual(4, qtyOfItemA1);




        }
        [TestMethod]
        public void Verify_Purchase_CannotBeMadeWith_InsufficientFunds()
        {
            string itemA1 = "A1";

            int initialQtyOfItemA1 = vm.Inventory[itemA1].Count;
            decimal costOfA1 = vm.Inventory[itemA1][0].Price;
            var didPurchaseWork = vm.BuyItem(itemA1);

            Assert.IsFalse(didPurchaseWork);


        }
        [TestMethod]
        public void Verify_Cannot_PurchaseFromEmptySlot()
        {
            string itemA1 = "A1";

            int initialQtyOfItemA1 = vm.Inventory[itemA1].Count;
            decimal costOfA1 = vm.Inventory[itemA1][0].Price;
            vm.AcceptCash(45);
            for (int i = 0; i < initialQtyOfItemA1; i++)
            {
                vm.BuyItem(itemA1);
            }

            Assert.IsFalse(vm.BuyItem(itemA1));

        }
        [TestMethod]
        public void Verify_Purchase_Updates_Balance()
        {
            string itemA1 = "A1";

            int initialQtyOfItemA1 = vm.Inventory[itemA1].Count;
            decimal costOfA1 = vm.Inventory[itemA1][0].Price;
            decimal initialBalance = 5;
            vm.AcceptCash((int)initialBalance);
            vm.BuyItem(itemA1);
            Assert.AreEqual(initialBalance - costOfA1, vm.Balance);

        }

        [TestMethod]
        public void Verify_Transactions_Are_TimeStamped()
        {
            vm.AcceptCash(5);
            vm.BuyItem("A1");
            var hasTime = vm.TransactionLog[0].Time.GetType();


            Assert.IsInstanceOfType(DateTime.Now, hasTime);
        }

    }
}
