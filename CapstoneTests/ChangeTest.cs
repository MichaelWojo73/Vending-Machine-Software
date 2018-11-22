using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineProject.Vending_Logic;
namespace VendingMachineProjectTests
{
    [TestClass]
    public class ChangeTest
    {
        [DataTestMethod]
        [DataRow(8.00, 32, 0, 0, 0)]
        [DataRow(8.25, 33, 0, 0, 0)]
        [DataRow(8.35, 33, 1, 0, 0)]
        [DataRow(8.45, 33, 2, 0, 0)]
        [DataRow(1.60, 6, 1, 0, 0)]
        [DataRow(1.30, 5, 0, 1, 0)]
        [DataRow(1.34, 5, 0, 1, 4)]
        [DataRow(1.69, 6, 1, 1, 4)]
        public void TestIfChangeIsReturnedCorrectlyIntoCoins(double changeInput, int expectedQuarters, int expectedDimes, int expectedNickels, int expectedPennies)
        {
            //Arrange

            Change c = new Change(Convert.ToDecimal(changeInput));

            //Act

            //Assert
            Assert.AreEqual(expectedQuarters, c.AmountOfQuarters);
            Assert.AreEqual(expectedDimes, c.AmountOfDimes);
            Assert.AreEqual(expectedNickels, c.AmountOfNickels);
            Assert.AreEqual(expectedPennies, c.AmountOfPennies);
        }


    }
}
