namespace CarPrototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            var car = new Car("Cerato", "White", new DateTime(2022, 01, 01), CarType.Sedan);
            car.Color = "Black";
            var carShallowCopy = car.ShallowCopy();
            carShallowCopy.Type = CarType.Hatch;
            var carDeepCopy = car.DeepCoppy();
            carDeepCopy.Type = CarType.SUV;

            Console.WriteLine(car);
            Console.WriteLine(carShallowCopy);
            Console.WriteLine(carDeepCopy);
            Console.ReadLine();

        }
    }
}
