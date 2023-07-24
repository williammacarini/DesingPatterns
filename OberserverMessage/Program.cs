namespace ObserverMessage
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; }

        private readonly List<IObserver> _observers = new();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SendNotification()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            State = new Random().Next(0, 10);

            Console.WriteLine("Subject: My state has just changed to: " + State);
            Notify();
        }
    }

    public class FirstObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            if (((Subject)subject).State < 3)
            {
                Console.WriteLine("FirstOberserver" + ": Reacted to the event.");
            }
        }
    }

    public class SecondOberserver : IObserver
    {
        public void Update(ISubject subject)
        {
            if (((Subject)subject).State == 0 || ((Subject)subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }

    public static class Program
    {
        static void Main()
        {
            var subject = new Subject();
            var first = new FirstObserver();
            subject.Attach(first);

            var second = new SecondOberserver();
            subject.Attach(second);

            subject.SendNotification();
            subject.SendNotification();

            subject.Detach(second);

            subject.SendNotification();
        }
    }
}