namespace Singleton
{
	internal class Program
	{
		//
		static void Main()
		{
			OrderProcessor processor1 = new ();
			OrderProcessor processor2 = new ();

			processor1.ProcessOrder(101);
			processor2.ProcessOrder(102);

			Logger logger1 = Logger.GetInstance();
			Logger logger2 = Logger.GetInstance();

            Console.WriteLine($"Are both loggers the same instance? {logger1 == logger2}");
        }
	}

	internal class Logger
	{
		private static readonly Lazy<Logger> _instance = new(() => new Logger());

		private Logger() { }

		public static Logger GetInstance()
		{
			return _instance.Value;
		}

		public void Log(string message)
		{
            Console.WriteLine($"Log Entry: {message}");
        }
	}

	internal class OrderProcessor
	{
		public void ProcessOrder(int orderId)
		{
			Logger logger = Logger.GetInstance();

			logger.Log($"Processing order {orderId}...");

			logger.Log($"Order {orderId} has been processed.");

            Console.WriteLine();
        }
	}
}
