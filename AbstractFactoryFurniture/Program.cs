namespace AbstractFactoryFurniture
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactoryFurniture abstractFactoryFurniture = new Furniture();
            abstractFactoryFurniture.CreateFurniture("Old").CreateChair();
            abstractFactoryFurniture.CreateFurniture("Old").CreateSofa();

            abstractFactoryFurniture.CreateFurniture("Vintage").CreateChair();
            abstractFactoryFurniture.CreateFurniture("Vintage").CreateSofa();
        }
    }

    public abstract class AbstractFactoryFurniture
    {
        public abstract FurnitureAbstract CreateFurniture(string type);
    }

    public abstract class FurnitureAbstract
    {
        public abstract void CreateChair();

        public abstract void CreateSofa();
    }

    public class Furniture : AbstractFactoryFurniture
    {
        public override FurnitureAbstract CreateFurniture(string type)
        {
            if (type == "Old")
            {
                return new Old();
            }
            else if (type == "Vintage")
            {
                return new Vintage();
            }
            else
            {
                throw new ArgumentException("Erro!");
            }
        }
    }

    public class Old : FurnitureAbstract
    {
        public override void CreateChair()
        {
            Console.WriteLine("Old Chair!");
        }

        public override void CreateSofa()
        {
            Console.WriteLine("Old Sofa!");
        }
    }

    public class Vintage : FurnitureAbstract
    {
        public override void CreateChair()
        {
            Console.WriteLine("Vintage Chair!");
        }

        public override void CreateSofa()
        {
            Console.WriteLine("Vintage Sofa!");
        }
    }
}
