using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject.Vending_Logic
{
    public class Slot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Slot"/> class.        
        /// </summary>
        /// <param name="item">the item that the slot holds</param>
        public Slot(Item item)
        {
            this.ItemInSlot = item;
            this.Quantity = 5;
        }

        public Item ItemInSlot { get; }

        public int Quantity { get; private set; }

        public Item RemoveItem()
        {
            this.Quantity--;

            return this.ItemInSlot;
        }

        public void AddItem()
        {
            this.Quantity++;
        }
    }
}
