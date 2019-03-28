using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product(50);
            product1.productName = "Hard disk";
            product1.StockControlEvent += Product1_StockControlEvent;

            Product product2 = new Product(50);
            product2.productName = "GSM";

            for (int i = 0; i < 10; i++)
            {
                product1.sell(10);
                product2.sell(10);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void Product1_StockControlEvent(string name)
        {
            Console.WriteLine("{0} stock amount is about finish", name);
        }
    }
}
