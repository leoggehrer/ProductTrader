namespace ProductTrader.Logic
{
    /// <summary>
    /// Provides data for product-related events.
    /// </summary>
    public class ProductEventArgs(string name, double maxValue, double value, double minValue) : EventArgs
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Returns the maximum value the stock has had.
        /// </summary>
        public double MaxValue { get; } = maxValue;
        /// <summary>
        /// Gets the current value of the stock.
        /// </summary>
        public double Value { get; } = value;
        /// <summary>
        /// Returns the minimum value the stock has had.
        /// </summary>
        public double MinValue { get; } = minValue;
    }
}
