namespace FacadeSystem
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var module = new Module("Camila");
            var routine = new Routine("Rica");
            var facade = new Facade(module, routine);
            var client = new Client(facade);
            client.PrintInformation();
        }
    }

    public class Client
    {
        private readonly Facade _facade;

        public Client(Facade facade)
        {
            _facade = facade;
        }

        public void PrintInformation()
        {
            _facade.ShowLadingPage();
        }
    }

    public class Facade
    {
        private readonly Module _module;
        private readonly Routine _routine;

        public Facade(Module module, Routine routine)
        {
            _module = module;
            _routine = routine;
        }

        public void ShowLadingPage()
        {
            Console.WriteLine($"Modulo: {_module.Name}");
            Console.WriteLine($"Routine: {_routine.Name}");
        }
    }

    public class Module
    {
        public string Name { get; private set; }

        public Module(string name)
        {
            Name = name;
        }
    }

    public class Routine
    {
        public string Name { get; private set; }

        public Routine(string name)
        {
            Name = name;
        }
    }
}