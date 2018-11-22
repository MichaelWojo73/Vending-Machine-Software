using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProject.Menu
{
    public static class DisplayItems
    {
        public static void Menu(VendingMachine currentVendingMachine)
        {
            foreach (KeyValuePair<string, Slot> kvp in currentVendingMachine.PositionSlot)
            {
                if (kvp.Value.Quantity > 0)
                {
                    Console.WriteLine($"{kvp.Key} | {kvp.Value.ItemInSlot.Name} | {kvp.Value.ItemInSlot.Price} | {kvp.Value.ItemInSlot.Type} | {kvp.Value.Quantity}");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key} | OUT OF STOCK");
                }
            }

            Console.Write("Enter any input to return to main menu: ");
            Console.ReadLine();
            MainMenu.Menu(currentVendingMachine);
        }
    }
}
