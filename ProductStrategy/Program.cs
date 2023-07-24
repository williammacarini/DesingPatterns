namespace ProductStrategy;

public static class Program
{
    static void Main(string[] args)
    {
        var date = DateTime.Now;
        DateTime? date1 = null;
        DateTime? date2 = date1?.Date;

        // Step 4: Usage
        var context = new Context();

        // Set strategy A
        context.SetStrategy(new SmartTV());
        context.ExecuteStrategy(); // Output: Executing strategy A

        // Set strategy B
        context.SetStrategy(new OldTV());
        context.ExecuteStrategy(); // Output: Executing strategy B
    }
}
public interface IStrategy
{
    void Execute();
}

public class SmartTV : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("It's a smart TV!");
    }
}

public class OldTV : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("It's a old TV!");
    }
}

public class Context
{
    private IStrategy _strategy;

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}