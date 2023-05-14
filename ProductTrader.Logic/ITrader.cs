namespace ProductTrader.Logic
{
    public interface ITrader
    {
        /// <summary>
        /// Returns the current profit.
        /// </summary>
        double CurrentProfit { get; }
        /// <summary>
        /// The Trader's name. 
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the profit made so far.
        /// </summary>
        double PastProfit { get; }
        /// <summary>
        /// Gets the purchase value.
        /// </summary>
        double PurchaseValue { get; }
        /// <summary>
        /// Gets the retail value.
        /// </summary>
        double RetailValue { get; }

        /// <summary>
        /// Registration method for the share.
        /// </summary>
        /// <param name="sender">The share.</param>
        /// <param name="eventArgs">Not in used.</param>
        void UpdateProduct(object sender, EventArgs eventArgs);
    }
}