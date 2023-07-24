using static System.Console;

namespace BankAccountMemento
{
    public record Memento
    {
        public int Money { get; init; }

        public Memento(int money)
        {
            Money = money;
        }
    }

    public class BankAccount
    {
        private int _money;
        private readonly List<Memento> _changes = new();
        private int _current;

        public BankAccount(int money)
        {
            _money = money;
            _changes.Add(new Memento(money));
        }

        public Memento Deposit(int amount)
        {
            _money += amount;
            var currentMemento = new Memento(_money);
            _changes.Add(currentMemento);
            ++_current;
            return currentMemento;
        }

        public void Restore(Memento memento)
        {
            if (memento != null)
            {
                _money = memento.Money;
                _changes.Add(memento);
                _current = _changes.Count - 1;
            }
        }

        public Memento? Undo()
        {
            if (_current > 0)
            {
                var memento = _changes[--_current];
                _money = memento.Money;
                return memento;
            }
            return null;
        }

        public Memento? Redo()
        {
            if (_current + 1 < _changes.Count)
            {
                var m = _changes[++_current];
                _money = m.Money;
                return m;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{nameof(_money)}: {_money}";
        }
    }

    public static class Program
    {
        static void Main()
        {
            var ba = new BankAccount(100);
            ba.Deposit(50);
            ba.Deposit(25);
            WriteLine(ba);

            ba.Undo();
            WriteLine($"Undo 1: {ba}");
            ba.Undo();
            WriteLine($"Undo 2: {ba}");
            ba.Redo();
            WriteLine($"Redo 2: {ba}");
        }
    }
}
