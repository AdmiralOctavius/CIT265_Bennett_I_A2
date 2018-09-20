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
            inventory[0] = new Item();
            inventory[1] = new Item();
            inventory[2] = new Item();
            inventory[3] = new Item();
            inventory[4] = new Item();
        }

        //Basic function to display all of the items in the machine
        public void DisplayInventory()
        {
            int i = 0;
            foreach (Item item in inventory)
            {
                ++i;
                Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
            }
        }

        //Addition of items to the machine
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

        //Function to calculate the current transaction price
        public double totalCustomerCost(int[] userBasket)
        {
            double result = 0;

            for(int i =0; i<userBasket.Length; i++)
            {
                result = result + (inventory[i].Price * userBasket[i]);
            }

            return result;
        }

        //Actual shop function
        public void Shop()
        {
            //Setup variables needed
            int i = 0;
            int userIn = -1;
            int currentSelection = -1;
            bool getNum = false;
            int[] totalQty = new int[5];

            //Give the user Info
            DisplayInventory();

            Console.WriteLine("6] Exit");
            Console.WriteLine("Please use the number keys to select your item. 1-5 for items, 6 to exit, 7 to check inventory.");

            //Main while loop, will escape on 5
            while (userIn != 5)
            {
                                
                getNum = int.TryParse(Console.ReadLine(), out userIn);
                userIn = userIn - 1;

                //Limiting the input to within 0-4, the items in the machine
                if (userIn >= 0 && userIn <= 4)
                {
                    //Output the selected item
                    Console.WriteLine(inventory[userIn].Name + " costs: " + inventory[userIn].Price + ". There are: " + inventory[userIn].Quantity + " within this machine. Would you like to buy some? \n 1 for yes, preses any other number to see the menu.");
                    currentSelection = userIn;
                    
                    getNum = Int32.TryParse(Console.ReadLine(), out userIn);

                    //Checking for confirm
                    if (userIn == 1)
                    {

                        Console.WriteLine("How many of this item do you want?");
                        getNum = Int32.TryParse(Console.ReadLine(), out userIn);

                        //If the item still exists in the machine
                        if (userIn > 0 && userIn <= inventory[currentSelection].Quantity)
                        {
                            Console.WriteLine("Okay, adding: " + userIn + " to your total.");
                            totalQty[currentSelection] += userIn;
                            inventory[currentSelection].Quantity = inventory[currentSelection].Quantity - userIn;
                            Console.WriteLine("The total cost of your time at this machine is: " + totalCustomerCost(totalQty));
                        }
                        //If there are none left
                        else if(inventory[currentSelection].Quantity == 0)
                        {
                            Console.WriteLine("Sorry, none of that item left.");
                        }
                        //If the user gave a correct amount
                        else if(userIn > inventory[currentSelection].Quantity)
                        {
                            Console.WriteLine("There are not that many in the machine! Would you like to take the remaining: " + inventory[currentSelection].Quantity + " That is in the machine? Press 1 to confirm, press any other number to return to the menu.");
                            getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                            if(userIn == 1)
                            {
                                Console.WriteLine("Okay, adding: " + inventory[currentSelection].Quantity + " to your total.");
                                totalQty[currentSelection] += inventory[currentSelection].Quantity;
                                inventory[currentSelection].Quantity = inventory[currentSelection].Quantity - inventory[currentSelection].Quantity;
                                Console.WriteLine("The total cost of your time at this machine is: " + totalCustomerCost(totalQty));
                            }
                        }
                        //Incorrect amount
                        else
                        {
                            Console.WriteLine("Not a correct number");
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Returning to main menu...");
                    Console.WriteLine("The total cost of your time at this machine is: " + totalCustomerCost(totalQty));
                    DisplayInventory();
                    Console.WriteLine("6] Exit");
                    Console.WriteLine("Please use the number keys to select your item. 1-5 for items, 6 to exit.");

                }

                //Letting the user exit
                else if (userIn == 5)
                {
                    Console.WriteLine("Goodbye!");
                }

                //Invalid input check
                else
                {
                    Console.WriteLine("Not a valid item number silly!");
                }
                
            }
        }

    }
}
