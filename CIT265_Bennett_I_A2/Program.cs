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
            myMachine.SetupItem(1, 4.5, "Communist manifesto", 23);
            myMachine.SetupItem(2, 5, "Mismatch patty cake: the cake for kids", 4);
            myMachine.SetupItem(3, 0.25, "Nintendo Switch", 1);
            myMachine.SetupItem(4, 1, "Dollar bill", 5);
            myMachine.SetupItem(5, 300, "Souls of the Damnned", 10);

            // myMachine.DisplayInventory();

            myMachine.Shop();

            Item newItem = new Item();
            newItem.Name = "My Name";
        }
    }
}
