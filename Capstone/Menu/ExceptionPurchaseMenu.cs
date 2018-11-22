using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProject.Menu
{
    public static class ExceptionPurchaseMenu
    {
        public static void Menu(VendingMachine currentVendingMachine)
        {
            bool finished = false;
            do
            {
                Console.WriteLine("WELCOME TO THE PURCHASE MENU");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) View Current Cart");
                Console.WriteLine("(4) Approve Changes");
                Console.WriteLine($"Current Money Provided: {currentVendingMachine.TFedMoney}");
                Console.Write("Input Option: ");
                string option = Console.ReadLine();
                string input = "";
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Input the amount of money you would like to feed ($1, $2, $5, $10):  ");
                        input = Console.ReadLine();
                        decimal moneyFeedIn = 0.0M;
                        if (input.IndexOf('$') > -1)
                        {
                            input.Remove(input.IndexOf('$'), 1);

                        }
                        moneyFeedIn = decimal.Parse(input);
                        if (moneyFeedIn == 1.00M || moneyFeedIn == 2.00M || moneyFeedIn == 5.00M || moneyFeedIn == 10.00M)
                        {
                            currentVendingMachine.FeedMoney(moneyFeedIn);
                            Console.WriteLine($"Successfully fed in money");
                        }
                        else
                        {
                            Console.WriteLine("You can only feed in money values ($1, $2, $5, $10).");

                        }
                        Console.WriteLine("Press any key to return to Exception Purchase Menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Would you like to add or remove a product? ");
                        Console.WriteLine("(1) Add Product To Cart");
                        Console.WriteLine("(2) Remove Product From Cart");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.Write("Input slot position to add to cart: ");
                            input = Console.ReadLine().ToUpper();
                            if (currentVendingMachine.PositionSlot.ContainsKey(input))
                            {
                                currentVendingMachine.AddItem(input); 
                            }
                            else
                            {
                                Console.WriteLine("----- INVALID POSITION -----");

                            }
                        }
                        else
                        {
                            Console.Write("Input slot position to remove from cart: ");
                            input = Console.ReadLine().ToUpper();
                            if (currentVendingMachine.PositionSlot.ContainsKey(input))
                            {
                                if (currentVendingMachine.Cart.Contains(currentVendingMachine.PositionSlot[input].ItemInSlot))
                                {
                                    currentVendingMachine.RemoveItem(input);
                                    Console.WriteLine($"{input} | {currentVendingMachine.PositionSlot[input].ItemInSlot.Name} | {currentVendingMachine.PositionSlot[input].ItemInSlot.Price} | Has been removed from your cart!");

                                }
                                else
                                {
                                    Console.WriteLine("You do not have that item in your cart");
                                }
                            }
                            else
                            {
                                Console.WriteLine("----- INVALID POSITION -----");
                            }
                        }
                        Console.WriteLine("Press any key to return to Exception Purchase Menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        foreach (Item item in currentVendingMachine.Cart)
                        {
                            string position = "";
                            foreach (KeyValuePair<string, Slot> kvp in currentVendingMachine.PositionSlot)
                            {
                                if (kvp.Value.ItemInSlot == item)
                                {
                                    position = kvp.Key;
                                }
                            }
                            Console.WriteLine($"{position} | {item.Name} | ${item.Price} | {item.Type}");
                        }
                        break;
                    case "4":
                        Console.Clear();
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

