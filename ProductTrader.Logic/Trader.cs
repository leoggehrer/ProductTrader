namespace ProductTrader.Logic
{
    /// <summary>
    /// Represents a trader that can buy and sell products.
    /// </summary>
    public class Trader(string name, double purchaseValue, double retailValue) : ITrader
    {
        #region fields
        private bool _hasBought = false;
        private double _buyValue = 0;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets the name of the trader.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the purchase value of the product.
        /// </summary>
        public double PurchaseValue { get; private set; } = purchaseValue;

        /// <summary>
        /// Gets the profit made so far.
        /// </summary>
        public double PastProfit
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current profit.
        /// </summary>
        public double CurrentProfit
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the retail value of the product.
        /// </summary>
        public double RetailValue { get; private set; } = retailValue;

        #endregion properties

        #region methods
        /// <summary>
        /// Updates the product based on the event arguments.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        public void UpdateProduct(object sender, EventArgs e)
        {
            if (e is ProductEventArgs product)
            {
                if (_hasBought && product.Value >= RetailValue)
                {
                    PastProfit += product.Value - _buyValue;
                    _hasBought = false;
                    _buyValue = 0.0;
                    CurrentProfit = PastProfit;
                }
                else if (_hasBought == false && product.Value >= PurchaseValue && product.Value <= RetailValue)
                {
                    _hasBought = true;
                    _buyValue = product.Value;
                    CurrentProfit = PastProfit;
                }
                else
                {
                    CurrentProfit = PastProfit;
                    CurrentProfit += _hasBought ? _buyValue - product.Value : 0;
                }
                if (CurrentProfit > 0)
                {
                    ;
                }
                Console.WriteLine($"{this}");
            }
        }

        /// <summary>
        /// Returns a string representation of the trader.
        /// </summary>
        /// <returns>A string that represents the trader.</returns>
        public override string ToString()
        {
            return $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";
        }
        #endregion methods
    }
}
