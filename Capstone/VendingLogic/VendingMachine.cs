using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Menu;
using VendingMachineProject.Documentation;

namespace VendingMachineProject.Vending_Logic
{
    public class VendingMachine
    {
        public decimal BeforeProcessFedMoney { get; private set; }

        public decimal TFedMoney { get; private set; }

        public Dictionary<string, Slot> PositionSlot { get; }

        public List<Item> Cart { get; private set; }

        public VendingMachine(Dictionary<string, Slot> inventory)
        {
            this.PositionSlot = inventory;
            this.Cart = new List<Item>();
        }

        public void FeedMoney(decimal fedMoney)
        {
            this.BeforeProcessFedMoney = this.TFedMoney;
            TFedMoney += fedMoney;
            Audit.MakeAudit(this.BeforeProcessFedMoney, this.TFedMoney, "FEED MONEY");
        }

        public void AddItem(string position)
        {
            if (this.PositionSlot[position.ToUpper()].Quantity > 0)
            {
                Cart.Add(this.PositionSlot[position.ToUpper()].RemoveItem());
                Console.WriteLine($"{position} | {this.PositionSlot[position].ItemInSlot.Name} | {this.PositionSlot[position].ItemInSlot.Price} | Has been added to your cart!");
            }
            else
            {
                Console.WriteLine($"Item at position {position.ToUpper()} ({this.PositionSlot[position.ToUpper()].ItemInSlot.Name}) is out of stock");
            }


        }
        public void RemoveItem(string position)
        {
            if (this.Cart.Contains(this.PositionSlot[position.ToUpper()].ItemInSlot))
            {
                Cart.Remove(this.PositionSlot[position.ToUpper()].ItemInSlot);
                this.PositionSlot[position.ToUpper()].AddItem();
            }
        }

        public Change FinishTransaction()
        {
            decimal totalCost;
            do
            {
                totalCost = 0.0M;
                foreach (Item chosenItem in Cart)
                {
                    totalCost += chosenItem.Price;
                }
                if (TFedMoney < totalCost)
                {
                    Console.WriteLine($"You do not have enough money for this transaction, Remove an Item or Feed Money.");
                    Console.WriteLine($"The current cost is ${totalCost} you fed in ${TFedMoney} in total.");
                    ExceptionPurchaseMenu.Menu(this);
                }
            } while (TFedMoney < totalCost);
            foreach (Item chosenItem in Cart)
            {
                this.BeforeProcessFedMoney = this.TFedMoney;
                string position = "";
                foreach (KeyValuePair<string, Slot> kvp in this.PositionSlot)
                {
                    if (kvp.Value.ItemInSlot == chosenItem)
                    {
                        position = kvp.Key;
                    }
                }
                this.TFedMoney -= chosenItem.Price;
                Audit.MakeAudit(this.BeforeProcessFedMoney, this.TFedMoney, (chosenItem.Name + " " + position));
            }
            Change change = new Change(TFedMoney);
            this.BeforeProcessFedMoney = this.TFedMoney;
            TFedMoney = 0.0M;
            Audit.MakeAudit(this.BeforeProcessFedMoney, this.TFedMoney, "GIVE CHANGE");
            return change;
        }

        public void EmptyCart()
        {
            Cart.Clear();
        }







    }





}
