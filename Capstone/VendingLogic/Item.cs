using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject.Vending_Logic
{
    public class Item
    {
        public string Name { get; }

        public string Type { get; }

        public decimal Price { get; }

        public Item(string name, string type, decimal price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }
    }
}
