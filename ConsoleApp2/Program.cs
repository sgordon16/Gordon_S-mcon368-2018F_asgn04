using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCON_368_Asgn04
{
    class Program
    {
        static void Main(string[] args)
        {
            Sale[] Sales = new Sale[10];

            var PricePerItemOver10 =
                from sale in Sales
                where sale.PricePerItem > 10.0
                select sale;

            var PricePerItemOver10Extension = Sales.Where(sale => sale.PricePerItem > 10.0);

            var QuantityIs1 =
                from sale in Sales
                where sale.Quantity == 1
                select sale;

            var QuantityIs1Extension = Sales.Where(sale => sale.Quantity == 1)
                .OrderByDescending(sale => sale);

            var TeaNoExpeditedShipping =
                from sale in Sales
                where sale.Item == "Tea" && !sale.ExpeditedShipping
                select sale;
            var TeaNoExpeditedShippingExtension = Sales.Where(sale => sale.Item == "Tea" && !sale.ExpeditedShipping);

            var TotalOrderOver100 =
                from sale in Sales
                where (sale.PricePerItem * sale.Quantity) > 100.0
                select sale;

            var TotalOrderOver100Extension = Sales.Where(sale => (sale.PricePerItem * sale.Quantity) > 100.0);

            var LLCSales =
                from sale in Sales
                where sale.Customer.Contains("LLC")
                select new { sale.Item, TotalPrice = sale.PricePerItem * sale.Quantity, Shipping = sale.Address + (sale.ExpeditedShipping ? "EXPEDITE" : "") };

            var LLCSalesExtension = Sales.Where(sale => sale.Customer.Contains("LLC")).
                Select(sale => new { sale.Item, TotalPrice = sale.PricePerItem * sale.Quantity, Shipping = sale.Address + (sale.ExpeditedShipping ? "EXPEDITE" : "") });
        }   
    }

    public class Sale
    {
        public Sale(String Item, String Customer, double PricePerItem, int Quantity, String Address, bool ExpeditedShipping)
        {
            this.Item = Item;
            this.Customer = Customer;
            this.PricePerItem = PricePerItem;
            this.Quantity = Quantity;
            this.Address = Address;
            this.ExpeditedShipping = ExpeditedShipping;
        }
        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping { get; set; }

    }
}
