namespace LearnSingleton
{
	public static class Program
	{
		static void Main()
		{
			var process1 = new Thread(() => { TestSingleton("Food"); });
			var process2 = new Thread(() => { TestSingleton("Dinner"); });

			process1.Start();
			process2.Start();

			process1.Join();
			process2.Join();

			var s1 = Singleton.GetInstance("t");
			var s2 = Singleton.GetInstance("f");

			if (s1 == s2)
			{
				Console.WriteLine("Singleton works!");
			}
			else
			{
				Console.WriteLine("Singleton failed");
			}
		}

		public static void TestSingleton(string value)
		{
			var singleton = Singleton.GetInstance(value);
			Console.WriteLine(singleton.Value);
		}
	}

	public sealed class Singleton
	{
		private static Singleton _instance;
		private static readonly object _instanceLock = new object();
		public string Value { get; set; }

		private Singleton() { }

		public static Singleton GetInstance(string value)
		{
			if (_instance is null)
			{
				lock (_instanceLock)
				{
					if (_instance is null)
					{
						_instance = new Singleton();
						_instance.Value = value;

					}
				}
			}
			return _instance;
		}
	}
}