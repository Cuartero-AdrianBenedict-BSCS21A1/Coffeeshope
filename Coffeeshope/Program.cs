using System;
using System.Linq;
using System.Collections.Generic;

namespace coffee
{
    public static class Program
    {
        public static void Main()
        {
            bool exit = false;
            var Menu = new Dictionary<string, decimal>();
            var Order = new Dictionary<string, decimal>();

            while (!exit)
            {
                Console.WriteLine("--------------");
                Console.WriteLine("Welcome to the Coffee Shop!");
                Console.WriteLine(" ");
                Console.WriteLine("1 - Add Menu Item");
                Console.WriteLine("--------------");
                Console.WriteLine("2 - View Menu");
                Console.WriteLine("--------------");
                Console.WriteLine("3 - Place Order");
                Console.WriteLine("--------------");
                Console.WriteLine("4 - View Order");
                Console.WriteLine("--------------");
                Console.WriteLine("5 - Calculate Total");
                Console.WriteLine("--------------");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("--------------");
                Console.Write("Please select your desired Function: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMenuItem(Menu);
                        break;
                    case "2":
                        ViewMenu(Menu);
                        break;
                    case "3":
                        PlaceOrder(Menu, Order);
                        break;
                    case "4":
                        ViewOrder(Order);
                        break;
                    case "5":
                        CalculateTotal(Order);
                        break;
                    case "6":
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("System Aplication exited!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Invalid function of choice!");
                        Console.WriteLine("Please try again");
                        Console.WriteLine("---------------------");
                        break;
                }
            }
        }

        private static void AddMenuItem(Dictionary<string, decimal> Menu)
        {
            Console.Write("Enter desired Item: ");
            string item = Console.ReadLine();

            Console.WriteLine("-------------------------------------");
            Console.Write("Enter items price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price > 0)
            {
                Menu[item] = price;
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Item successfully added!");
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Error!: There was an error on the input please try again");
            }
        }

        private static void ViewMenu(Dictionary<string, decimal> Menu)
        {
            if (Menu.Count == 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("No menu items currently available.");
                return;
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Welcome for todays menu:");
            int index = 1;
            foreach (var item in Menu)
            {
                Console.WriteLine($"{index}. {item.Key} - {item.Value:₱}");
                index++;
            }
        }

        private static void PlaceOrder(Dictionary<string, decimal> menu, Dictionary<string, decimal> order)
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Unfortunately no menu items are available at the time, please try again later");
                return;
            }

            ViewMenu(menu);
            Console.WriteLine("-------------------------------------");
            Console.Write("Select item number to order: ");
            if (int.TryParse(Console.ReadLine(), out int orderNumber) && orderNumber >= 1 && orderNumber <= menu.Count)
            {
                var item = menu.ElementAt(orderNumber - 1);
                if (order.ContainsKey(item.Key))
                {
                    order[item.Key] += item.Value;
                }
                else
                {
                    order[item.Key] = item.Value;
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Order successfully added!");
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Error!: Invalid item number!");
            }
        }

        private static void ViewOrder(Dictionary<string, decimal> order)
        {
            if (order.Count == 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("No items in the order.");
                return;
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Your Order:");
            foreach (var item in order)
            {
                Console.WriteLine($"{item.Key} - {item.Value:₱}");
            }
        }

        private static void CalculateTotal(Dictionary<string, decimal> order)
        {
            if (order.Count == 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("There are currently no items in order");
                return;
            }

            decimal Total = order.Values.Sum();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total item amount is:  {Total:C}");
            Console.WriteLine("Please pay at the cashier or via mobile app");
        }
    }
}