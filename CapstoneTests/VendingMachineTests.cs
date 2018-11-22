using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProjectTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow(10.00, 10.00)]
        [DataRow(5.00, 5.00)]

        public void FedMoneyShouldAddToYourTotalMoney(double expectedMoney, double fedMoney)
        {
            // Arrange
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");
            VendingMachine currentVendingMachine = new VendingMachine(inventory);

            //Act
            currentVendingMachine.FeedMoney(Convert.ToDecimal(fedMoney));
            //Assert

            Assert.AreEqual(Convert.ToDecimal(expectedMoney), currentVendingMachine.TFedMoney);
        }
        [TestMethod]
       
        public void AdditemAddsItemToYourCart()
        {
            //Arrange
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");
            VendingMachine currentVendingMachine = new VendingMachine(inventory);

            //Act
            currentVendingMachine.AddItem("A1");


            //Assert
            bool foundItemInCart = false;
            foreach (Item item in currentVendingMachine.Cart)
            {
                if (item.Name == inventory["A1"].ItemInSlot.Name)
                {
                    Assert.AreEqual(item.Name, inventory["A1"].ItemInSlot.Name);
                    foundItemInCart = true;
                }
            }
            Assert.IsTrue(foundItemInCart);
        }

        [TestMethod]
        public void RemoveItemFromCart()
        {
            //Arrange
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");
            VendingMachine currentVendingMachine = new VendingMachine(inventory);
            

            // Act
            currentVendingMachine.AddItem("A1");
            currentVendingMachine.RemoveItem("A1");

            //Assert
            Assert.AreEqual(0, currentVendingMachine.Cart.Count);
        }

    }



}
