namespace ProductTrader.Logic
{
    /// <summary>
    /// Represents a product with fluctuating value over time.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified name and start value.
    /// </remarks>
    /// <param name="name">The name of the product.</param>
    /// <param name="startValue">The initial value of the product.</param>
    public class Product(string name, double startValue) : IProduct
    {
        private const int UpdateTime = 500;
        #region fields
        private static readonly Random Random = new(DateTime.UtcNow.Millisecond);
        private DateTime _startTime;
        private volatile bool _running = false;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the minimum value the product has had.
        /// </summary>
        public double MinValue { get; private set; } = startValue >= 0 ? startValue : 0;

        /// <summary>
        /// Gets the current value of the product.
        /// </summary>
        public double Value { get; private set; } = startValue >= 0 ? startValue : 0;

        /// <summary>
        /// Gets the maximum value the product has had.
        /// </summary>
        public double MaxValue { get; private set; } = startValue >= 0 ? startValue : 0;
        #endregion properties

        #region events
        /// <summary>
        /// Occurs when the value of the product changes.
        /// </summary>
        public event EventHandler? Changed;

        #endregion events
        #region constructors
        #endregion constructors

        #region methods
        /// <summary>
        /// Starts the simulation of the product value fluctuation.
        /// </summary>
        public void Start()
        {
            if (_running == false)
            {
                _running = true;
                Thread t = new(Run)
                {
                    IsBackground = true
                };
                _startTime = DateTime.UtcNow;
                t.Start();
            }
        }

        /// <summary>
        /// Stops the simulation of the product value fluctuation.
        /// </summary>
        public void Stop()
        {
            _running = false;
        }

        /// <summary>
        /// Runs the simulation of the product value fluctuation.
        /// </summary>
        private void Run()
        {
            double fluctuation;

            while (_running)
            {
                Thread.Sleep(UpdateTime);

                fluctuation = CalculateFluctuation(Random.Next(0, 50) / 1000.0);
                Value += fluctuation;
                if (Value < MinValue)
                {
                    MinValue = Value;
                }
                else if (Value > MaxValue)
                {
                    MaxValue = Value;
                }
                Changed?.Invoke(this, new ProductEventArgs(Name, MaxValue, Value, MinValue));
            }
        }

        /// <summary>
        /// Calculates the fluctuation of the product value.
        /// </summary>
        /// <param name="fluctuation">The fluctuation factor.</param>
        /// <returns>The calculated fluctuation.</returns>
        private double CalculateFluctuation(double fluctuation)
        {
            double result;
            int upOrDown = Random.Next(1, 101);

            if (upOrDown >= 50)
            {
                result = Value * fluctuation;
            }
            else
            {
                fluctuation *= -1;
                result = Value * fluctuation;
            }
            return result;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Name,-20} {Value,10:f} EUR {MinValue,10:f} EUR {MaxValue,10:f} EUR Time:{(DateTime.UtcNow - _startTime).TotalSeconds:f} sec";
        }
        #endregion methods
    }
}