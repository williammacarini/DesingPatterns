namespace ComputerDecorator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            var newComputer = new ConcreteComputer("Dell", "Black", 4, 8000);
            client.SeeComputer(newComputer);

            ConcreteDecorator decorator = new ConcreteDecorator(newComputer, "William", 5000);
            client.SeeComputer(decorator);
        }
    }

    public abstract class AbstractComputer
    {
        public abstract void Components();
    }

    public class ConcreteComputer : AbstractComputer
    {
        public readonly string Model;
        public readonly string Color;
        public readonly int Thread;
        public readonly int Memory;

        public ConcreteComputer(string model, string color, int thread, int memory)
        {
            Model = model;
            Color = color;
            Thread = thread;
            Memory = memory;
        }

        public override void Components()
        {
            Console.WriteLine($"Details: {Model}, {Color}, {Thread}, {Memory}");
        }

        public string Print()
        {
            Components();
            return "Finished!";
        }

        public override string ToString()
        {
            return $"{Print()}";
        }
    }

    public class Decorator : AbstractComputer
    {
        private AbstractComputer _computerAbstract;

        public Decorator(AbstractComputer computerAbstract)
        {
            _computerAbstract = computerAbstract;
        }

        public void SetComponents(AbstractComputer abstractComputer)
        {
            _computerAbstract = abstractComputer;
        }

        public override void Components()
        {
            if (_computerAbstract is not null)
            {
                _computerAbstract.Components();
            }
            else
            {
                Console.WriteLine("Empty Description!");
            }
        }
    }

    public class ConcreteDecorator : Decorator
    {
        protected string Owner;
        protected int Value;

        public ConcreteDecorator(ConcreteComputer computer, string owner, int value) : base(computer)
        {
            Owner = owner;
            Value = value;
        }

        public override void Components()
        {
            Console.WriteLine($"{Owner}, {Value}");
        }

        public override string ToString()
        {
            Components();
            return "Finished!";
        }
    }

    public class Client
    {
        public void SeeComputer(AbstractComputer computer)
        {
            Console.WriteLine($"Result: {computer}");
        }
    }
}