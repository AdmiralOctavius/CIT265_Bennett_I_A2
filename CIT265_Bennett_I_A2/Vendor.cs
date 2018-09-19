using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT265_Bennett_I_A2
{

    public class Vendor
    {

        private Item[] inventory;
        public Vendor()
        {
            inventory = new Item[5];
            //At the moment in addition to inializing the array in the constructor, we need to initalize the items as well.
            //There should be a faster, less hard coded way to do this
            inventory[0] = new Item();
            inventory[1] = new Item();
            inventory[2] = new Item();
            inventory[3] = new Item();
            inventory[4] = new Item();
        }

        public void DisplayInventory()
        {
            int i = 0;
            foreach (Item item in inventory)
            {
                ++i;
                Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
            }
        }

        public void SetupItem(int position, double inPrice, string inName, int inQuantity)
        {
            if (inventory.Length > position)
            {
                inventory[position].Name = inName;
                inventory[position].Price = inPrice;
                inventory[position].Quantity = inQuantity;
                Console.WriteLine("Item: " + inventory[position].Name + " Added to machine");
            }
            else
            {
                Console.WriteLine("Too large of an index");
            }
        }

        public double totalCustomerCost(int[] userBasket)
        {
            double result = 0;

            for(int i =0; i<userBasket.Length; i++)
            {
                result = result + (inventory[i].Price * userBasket[i]);
            }

            return result;
        }
        public void Shop()
        {
            int i = 0;
            int userIn = -1;
            int currentSelection = -1;
            bool getNum = false;
            //double currentTotal = 0;
            //Instead of double use Item array
            int[] totalQty = new int[5];

            foreach (Item item in inventory)
            {
                ++i;
                Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
            }
            Console.WriteLine("6] Exit");
            Console.WriteLine("Please use the number keys to select your item. 1-5 for items, 6 to exit, 7 to check inventory.");
            while (userIn != 5)
            {

                //userIn = int.Parse(Console.ReadLine());
                getNum = int.TryParse(Console.ReadLine(), out userIn);
                userIn = userIn - 1;
                if (userIn >= 0 && userIn <= 4)
                {
                    Console.WriteLine(inventory[userIn].Name + " costs: " + inventory[userIn].Price + ". There are: " + inventory[userIn].Quantity + " within this machine. Would you like to buy some? \n 1 for yes, preses any other number to see the menu.");
                    currentSelection = userIn;
                    //userIn = int.Parse(Console.ReadLine());
                    getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                    if (userIn == 1)
                    {
                        Console.WriteLine("How many of this item do you want?");
                        //userIn = int.Parse(Console.ReadLine());
                        getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                        if (userIn > 0 && userIn <= inventory[currentSelection].Quantity)
                        {
                            Console.WriteLine("Okay, adding: " + userIn + " to your total.");
                            totalQty[currentSelection] += userIn;
                            Console.WriteLine("The total cost of your time at this machine is: " + totalCustomerCost(totalQty));
                        }
                        else if(userIn > inventory[currentSelection].Quantity)
                        {
                            Console.WriteLine("There are not that many in the machine! Would you like to take the remaining: " + inventory[currentSelection].Quantity + " That is in the machine? Press 1 to confirm, press any other number to return to the menu.");
                            getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                            if(userIn == 1)
                            {
                                Console.WriteLine("Okay, adding: " + inventory[currentSelection].Quantity + " to your total.");
                                totalQty[currentSelection] += inventory[currentSelection].Quantity;
                                Console.WriteLine("The total cost of your time at this machine is: " + totalCustomerCost(totalQty));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not a correct number");
                        }
                    }

                    Console.WriteLine("Returning to main menu...");
                    i = 0;
                    foreach (Item item in inventory)
                    {
                        ++i;
                        Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
                    }
                    Console.WriteLine("6] Exit");
                    Console.WriteLine("Please use the number keys to select your item. 1-5 for items, 6 to exit.");

                }
                else if (userIn == 5)
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Not a valid item number silly!");
                }

            }
        }

    }
}
