using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProjectTests
{
    [TestClass]
    public class InputFileTests
    {
        [TestMethod]
        public void InputFileFillsDictionariesCorrectly()
        {
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("input.txt");

            //Act
            string name = inventory["A1"].ItemInSlot.Name;
            decimal price = inventory["A1"].ItemInSlot.Price;
            string type = inventory["A1"].ItemInSlot.Type;

            // Assert
            Assert.AreEqual("Potato Crisps", name);
            Assert.AreEqual(3.05M, price);
            Assert.AreEqual("Chip", type);
        }

    }
}
