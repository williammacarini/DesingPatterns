namespace Clothes
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proxy Design Pattern");

            var client = new Client();

            var clothe = new Clote();
            client.ClientCode(clothe, 10);
            client.ClientCode(clothe, 55);

            var clotheProxy = new ClotheProxy(clothe);
            client.ClientCode(clotheProxy, 11);
            client.ClientCode(clotheProxy, 50);
        }
    }
}

public interface IClothe
{
    string GetClotheSize(int weight);
}

public class Clote : IClothe
{
    public string GetClotheSize(int weight)
    {
        var result = weight switch
        {
            (> 30) and (< 50) => "PP",
            (> 49) and (< 65) => "P",
            (> 64) and (< 80) => "M",
            (> 79) and (< 95) => "G",
            (> 94) and (< 110) => "GG",
            _ => "Not Found!"
        };

        Console.WriteLine($"Clothe size: {result}");
        return result;
    }
}

public class ClotheProxy : IClothe
{
    private readonly IClothe _proxy;
    private int _weight;

    public ClotheProxy(IClothe proxy)
    {
        _proxy = proxy;
    }

    public bool CheckAccess()
    {
        if (_weight > 30)
            return true;
        return false;
    }

    public string GetClotheSize(int weight)
    {
        _weight = weight;
        if (CheckAccess())
        {
            return _proxy.GetClotheSize(_weight);
        }
        return "Not found!";
    }
}

public class Client
{
    public void ClientCode(IClothe clothe, int weight)
    {
        clothe.GetClotheSize(weight);
    }
}