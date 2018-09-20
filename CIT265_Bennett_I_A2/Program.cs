/*
 Name: Isaac Bennett
 Class: CIT265
 Professor: Davide Andrea Mauro
 Assignment 2
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT265_Bennett_I_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendor myMachine = new Vendor();
            myMachine.SetupItem(0, 3.5, "Candy", 2);
            myMachine.SetupItem(1, 4.5, "Cup in the shape of a head", 23);
            myMachine.SetupItem(2, 5, "Mismatch patty cake: the cake for kids", 4);
            myMachine.SetupItem(3, 0.25, "Nintendo Switch", 1);
            myMachine.SetupItem(4, 1, "Dollar bill", 5);
            //Testing overloading the machine
            myMachine.SetupItem(5, 300, "Souls of the Damnned", 10);

            //Testing of the display inventory
            // myMachine.DisplayInventory();


            //Main shop method.
            myMachine.Shop();

            
        }
    }
}
