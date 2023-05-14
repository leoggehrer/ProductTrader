using ProductTrader.Logic;

namespace ProductTrader.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product-Trader");

            Product product = new Product("Brent Rohöl", 68.41);
            Trader trader1 = new Trader("Gerhard", 70, 75);
            Trader trader2 = new Trader("Maximilian", 75, 80);
            Trader trader3 = new Trader("Tobias", 80, 85);

            product.Changed += trader1.UpdateProduct!;
            product.Changed += trader2.UpdateProduct!;
            product.Changed += trader3.UpdateProduct!;
            product.Start();
            Console.ReadLine();
            product.Stop();
        }
    }
}