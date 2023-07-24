namespace FactoryMethodPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var listTest = new List<int> { 0, 1, 2, 3 };
            var listFor = new List<int>();
            var listLinq = new List<int>();

            foreach (var value in listTest)
            {
                listFor.Add(value);
                Console.WriteLine("Teste For: " + value);
            }

            listLinq = listTest.Select(s => s).ToList();

            foreach (var value in listLinq)
            {
                Console.WriteLine("Linq: " + value);
            }
        }
    }
}