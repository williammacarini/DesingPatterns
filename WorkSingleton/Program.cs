using System.Transactions;

namespace WorkSingleton
{
    public class Program
    {
        static void Main()
        {
            var familyProcess = new FamilyProcess(new Log());
            var log = new Log();
            familyProcess.GetMember("William");
            familyProcess.Refresh();
        }
    }

    public class Singleton<T>
    {
        //private static Lazy<Singleton<T>> _instance = new Lazy<Singleton<T>>(() => new());

        //public Singleton() { }

        //public static Singleton<T> GetInstance() => _instance.Value;


        private static Singleton<T> _instance;
        private static readonly object _instanceLock = new object();
        public string Value { get; set; }

        public Singleton() { }

        public static Singleton<T> GetInstance(string value)
        {
            if (_instance is null)
            {
                lock (_instanceLock)
                {
                    if (_instance is null)
                    {
                        _instance = new Singleton<T>();
                        _instance.Value = value;

                    }
                }
            }
            return _instance;
        }
    }

    public class Base : Singleton<Base>
    {
        private readonly Log _log;

        public Base(Log log)
        {
            _log = log;
        }

        protected delegate TMetodo Metodo<out TMetodo>();
        protected delegate void Metodo();

        protected TMetodo ExecuteMethod<TMetodo>(Metodo<TMetodo> metodo)
        {
            _log.LogStar();
            TMetodo result;

            using (TransactionScope scope = new TransactionScope())
            {
                result = metodo.Invoke();
                scope.Complete();
            }

            _log.LogFinish();
            return result;
        }

        protected void ExecuteMethod(Metodo metodo)
        {
            _log.LogStar();

            using (TransactionScope scope = new TransactionScope())
            {
                metodo.Invoke();
                scope.Complete();
            }

            _log.LogFinish();
        }
    }

    public class Log : Singleton<Log>
    {
        public Log() { }

        public void LogStar()
        {
            Console.WriteLine("Start " + DateTime.Now);
        }

        public void LogFinish()
        {
            Console.WriteLine("Finish " + DateTime.Now);
        }
    }

    public class Family : Base
    {
        private readonly Log _log;
        public Family(Log log) : base(log)
        {
            _log = log;
        }

        public Tuple<string, int> GetFamily(string name)
        {
            var members = new List<Tuple<string, int>>();
            members.Add(new Tuple<string, int>("William", 25));
            members.Add(new Tuple<string, int>("Camila", 26));
            members.Add(new Tuple<string, int>("Enzo", 7));
            members.Add(new Tuple<string, int>("Chanel", 4));

            return members.FirstOrDefault(f => f.Item1 == name);
        }

        public void RefreshFamily()
        {
            Console.WriteLine("Refresh done!");
        }
    }

    public class FamilyProcess : Family
    {
        private readonly Log _log;
        public FamilyProcess(Log log) : base(log)
        {
            _log = log;
        }
        public Tuple<string, int> GetMember(string member)
        {
            Tuple<string, int> findMember = ExecuteMethod(() => GetFamily(member));
            Console.WriteLine(findMember);
            return findMember;
        }

        public void Refresh()
        {
            ExecuteMethod(RefreshFamily);
        }
    }
}