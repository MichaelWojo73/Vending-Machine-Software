using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProject.Menu
{
    public static class MainMenu
    {
        public static void Menu(VendingMachine currentVendingMachine)
        {
            bool finished = false;
            do
            {
                Console.WriteLine("WELCOME TO THE VENDING MACHINE");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(Q) Quit");
                Console.Write("Input Option: ");
                string Option = Console.ReadLine().ToUpper();
                switch (Option)
                {
                    case "1":
                        DisplayItems.Menu(currentVendingMachine);
                        finished = true;
                        break;
                    case "2":
                        Purchase.Menu(currentVendingMachine);
                        finished = true;
                        break;
                    case "Q":
                        finished = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Not a valid choice");
                        break;

                }
            } while (!finished);
        }
    }
}
