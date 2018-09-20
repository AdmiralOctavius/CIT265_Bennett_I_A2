using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT265_Bennett_I_A2
{
    public class Item
    {
        private double price;
        private string name;
        private int quantity;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
