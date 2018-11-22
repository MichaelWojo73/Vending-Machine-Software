using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProjectTests
{
    [TestClass]
    public class SlotTests
    {
        [DataTestMethod]
        [DataRow("A1", 5)]
        [DataRow("B1", 5)]
        [DataRow("C1", 5)]
        public void AddItemShouldIncreaseQuantityzbyFive(string position, int expected)
        {
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");

            //Act


            //Assert
            Assert.AreEqual(expected, inventory[position].Quantity);
        }

        [TestMethod]
        public void RemoveItemShouldDecreaseQuantityByOne()
        {
            //Arrange
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");

            //Act
            inventory["A1"].RemoveItem();

            //Assert
            Assert.AreEqual(4, inventory["A1"].Quantity);


        }

        [TestMethod]
        public void AddItemShouldIncreaseQuantityByOneOnly()
        {
            //Arrange
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");

            //Act
            inventory["A1"].RemoveItem();
            inventory["A1"].RemoveItem();
            inventory["A1"].AddItem();

            //Assert
            Assert.AreEqual(4, inventory["A1"].Quantity);

        }
    }
}
