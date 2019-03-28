using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeEvents
{
    public delegate void StockControl(string name);
    public class Product
    {
        public event StockControl StockControlEvent;
        int _stock;
        public Product(int stock)
        {
            _stock = stock;
        }
        public string productName { get; set; }
        public int stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (value <= 15 && StockControlEvent != null)
                {
                    StockControlEvent(productName);
                }
            }
        }

        public void sell(int amount)
        {
            stock -= amount;
            Console.WriteLine("{1} stock amount :{0}", stock, productName);
        }
    }
}
