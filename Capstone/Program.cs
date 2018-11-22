using System;
using VendingMachineProject.Menu;
using VendingMachineProject.Vending_Logic;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Slot> inventory = InventoryReader.GetInventory("Input.txt");
            VendingMachine currentVendingMachine = new VendingMachine(inventory);
            MainMenu.Menu(currentVendingMachine);
        }
    }
}
