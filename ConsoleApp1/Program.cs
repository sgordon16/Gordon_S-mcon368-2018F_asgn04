using MCON_368_Asgn04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double SumTotal;
            Sale[] salesList = new Sale[] { new Sale("Apple", "Marry", .75, 5, "96 Cedar Rd.", true),
                new Sale("Coffe", "John", 2.5, 2, "36 Main Ave.", false),
                new Sale("Ketchup", "Mike", 3, 2, "27 Groove St.", false),
                new Sale("Coffe", "George", 2.5, 1, "234 Cranberry Rd.", true),
                new Sale("Mustard", "Jack", 2, 3, "507 Blueberry Ln.", false),
                new Sale("Tea", "Bob", 1, 4, "887 Olive St.", true)
            };

            SumTotal = TotalProfit(salesList, sale => sale.Item == "Coffe", 
                sale => (sale.PricePerItem * sale.Quantity) * 0.8, 
                (sale, profit) => Console.WriteLine("Coffee item for " + sale.Customer + " , total profit: " + profit), 
                sale => Console.WriteLine("Non - Coffee item, skipping"));
            Console.WriteLine("Total: " + SumTotal);

            SumTotal = TotalProfit(salesList, sale => sale.Quantity > 1,
                sale => (sale.ExpeditedShipping ? 20 : 0) + (sale.PricePerItem * sale.Quantity),
                (sale, profit) => Console.Write(sale.ExpeditedShipping ? "Expedited Shipping sale of " + sale.Item + " -Extra $20 profit\n" : ""),
                sale => Console.WriteLine("Single Order Item " + sale.Item));
            Console.WriteLine("Total: " + SumTotal);
            Console.ReadKey();
            double TotalProfit(Sale[] sales, Func<Sale, bool> func1, Func<Sale, double> func2, Action<Sale, double> action1, Action<Sale> action2)
            {
                double total = 0;
                foreach (Sale sale in sales)
                {
                    if(func1(sale))
                    {
                        double profit = func2(sale);
                        action1(sale, profit);
                        total += profit;
                    }
                    else
                    {
                        action2(sale);
                    }
                }
                return total;
            }
        }
    }
}
