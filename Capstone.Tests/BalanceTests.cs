using System;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass, TestCategory("Balance Property")]
    public class BalanceTests
    {
        private static FileReader fr = new FileReader();
        private VendingMachine vm = new VendingMachine(fr.Stock());
        [TestMethod]
        public void Verify_Balance_UpdatesWithDeposit()
        {
            vm.AcceptCash(5);
            Assert.AreEqual((decimal)5, vm.Balance);

        }
    }
}
