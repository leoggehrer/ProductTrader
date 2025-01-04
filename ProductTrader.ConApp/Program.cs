using ProductTrader.Logic;
namespace ProductTrader.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(/*string[] args*/)
        {
            Console.WriteLine("Product-Trader");

            Product product = new("Brent Rohöl", 68.41);
            Trader trader1 = new("Gerhard", 70, 75);
            Trader trader2 = new("Maximilian", 75, 80);
            Trader trader3 = new("Tobias", 80, 85);

            product.Changed += PrintHeader!;
            product.Changed += PrintProduct!;
            product.Changed += PrintTraderHeader!;
            product.Changed += trader1.UpdateProduct!;
            product.Changed += trader2.UpdateProduct!;
            product.Changed += trader3.UpdateProduct!;
            product.Start();
            Console.ReadLine();
            product.Stop();
        }

        /// <summary>
        /// Prints the header information when the product changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        static void PrintHeader(object sender, EventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Product-Trader");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the product information when the product changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        static void PrintProduct(object sender, EventArgs e)
        {
            if (e is ProductEventArgs product)
            {
                ConsoleColor saveColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{"Product",-20} {"CurrentValue",14} {"MinValue",14} {"MaxValue",14}");
                Console.ForegroundColor = saveColor;
                Console.WriteLine($"{product.Name,-20} {product.Value,10:f} EUR {product.MinValue,10:f} EUR {product.MaxValue,10:f} EUR");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the trader header information when the product changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        static void PrintTraderHeader(object sender, EventArgs e)
        {
            if (e is ProductEventArgs product)
            {
                ConsoleColor saveColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{nameof(Trader),-20} {nameof(Trader.CurrentProfit),14} {nameof(Trader.PurchaseValue),14} {nameof(Trader.RetailValue),14}");
                Console.ForegroundColor = saveColor;
            }
        }
    }
}