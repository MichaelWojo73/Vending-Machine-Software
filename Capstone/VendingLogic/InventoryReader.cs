using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VendingMachineProject.Vending_Logic
{
    public class InventoryReader
    {
        public static Dictionary<string, Slot> GetInventory(string fileName)
        {
            Dictionary<string, Slot> inventory = new Dictionary<string, Slot>();

            const int Position_Slot = 0;
            const int Position_Name = 1;
            const int Position_Price = 2;
            const int Position_Type = 3;

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] fields = line.Split('|');

                    string position = fields[Position_Slot];
                    string name = fields[Position_Name];
                    decimal price = decimal.Parse(fields[Position_Price]);
                    string type = fields[Position_Type];

                    Item item = new Item(name, type, price);
                    Slot slot = new Slot(item);
                    inventory.Add(position, slot);
                }
            }

            return inventory;
        }
    }
}
