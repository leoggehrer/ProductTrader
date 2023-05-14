namespace ProductTrader.Logic
{
    public interface IProduct
    {
        /// <summary>
        /// Gets the name of the stock.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Returns the maximum value the stock has had.
        /// </summary>
        double MaxValue { get; }
        /// <summary>
        /// Gets the current value of the stock.
        /// </summary>
        double Value { get; }
        /// <summary>
        /// Returns the minimum value the stock has had.
        /// </summary>
        double MinValue { get; }

        /// <summary>
        /// Fired when the value of the stock has changed.
        /// </summary>
        event EventHandler? Changed;

        /// <summary>
        /// Starts the simulation.
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the simulation.
        /// </summary>
        void Stop();
    }
}