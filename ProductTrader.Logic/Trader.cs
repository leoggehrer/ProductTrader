namespace ProductTrader.Logic
{
    public class Trader : ITrader
    {
        #region fields
        private bool _hasBought = false;
        private double _buyValue = 0;
        #endregion fields

        #region properties
        public string Name { get; }
        public double PurchaseValue { get; private set; }
        public double PastProfit
        {
            get;
            private set;
        }
        public double CurrentProfit
        {
            get;
            private set;
        }
        public double RetailValue { get; private set; }
        #endregion properties
        public Trader(string name, double purchaseValue, double retailValue)
        {
            Name = name;
            PurchaseValue = purchaseValue;
            RetailValue = retailValue;
        }

        #region methods
        public void UpdateProduct(object sender, EventArgs eventArgs)
        {
            if (sender is Product product)
            {
                if (_hasBought && product.Value >= RetailValue)
                {
                    PastProfit += product.Value - _buyValue;
                    _hasBought = false;
                    _buyValue = 0.0;
                    CurrentProfit = PastProfit;
                }
                else if (_hasBought == false && product.Value <= PurchaseValue)
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
                Console.WriteLine($"{this}");
            }
        }
        public override string ToString()
        {
            return $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";
        }
        #endregion methods
    }
}
