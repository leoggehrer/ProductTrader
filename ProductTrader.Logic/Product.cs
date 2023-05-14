namespace ProductTrader.Logic
{
    public class Product : IProduct
    {
        private const int UpdateTime = 500;
        #region fields
        private static Random Random = new Random(DateTime.UtcNow.Millisecond);
        private DateTime _startTime;
        private volatile bool _running = false;
        #endregion fields

        #region properties
        public string Name { get; }
        public double MinValue { get; private set; }
        public double Value { get; private set; }
        public double MaxValue { get; private set; }
        #endregion properties

        #region events
        public event EventHandler? Changed;
        #endregion events

        #region constructors
        public Product(string name, double startValue)
        {
            Name = name;
            MinValue = startValue >= 0 ? startValue : 0;
            Value = startValue >= 0 ? startValue : 0;
            MaxValue = startValue >= 0 ? startValue : 0;
        }
        #endregion constructors

        #region methods
        public void Start()
        {
            if (_running == false)
            {
                _running = true;
                Thread t = new Thread(Run);
                t.IsBackground = true;
                _startTime = DateTime.UtcNow;
                t.Start();
            }
        }
        public void Stop()
        {
            _running = false;
        }

        private void Run()
        {
            double fluctuation = 0;

            while (_running)
            {
                Thread.Sleep(UpdateTime);

                fluctuation = CalculateFluctuation(Random.Next(0, 50) / 1000.0);
                Value = Value + fluctuation;
                if (Value < MinValue)
                {
                    MinValue = Value;
                }
                else if (Value > MaxValue)
                {
                    MaxValue = Value;
                }
                Console.WriteLine($"{this}");
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        private double CalculateFluctuation(double maxFluctuation)
        {
            double result = 0;
            int upOrDown = Random.Next(1, 101);

            if (upOrDown >= 50)
            {
                result = Value * maxFluctuation;
            }
            else
            {
                result = Value * maxFluctuation * -1;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name,-20} {Value,10:f} EUR {MinValue,10:f} EUR {MaxValue,10:f} EUR Time:{(DateTime.UtcNow - _startTime).TotalSeconds:f} sec";
        }
        #endregion methods
    }
}