using System;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass, TestCategory("Item Properties")]
    public class VMItemTests
    {
        private static FileReader fr = new FileReader();
        private VendingMachine vm = new VendingMachine(fr.Stock());

        [TestMethod]
        public void Verify_Items_Have_Sound()
        {
           var sound= vm.Inventory["A1"][0].MakeSound();
            Assert.IsNotNull(sound);
        }
    }
}
