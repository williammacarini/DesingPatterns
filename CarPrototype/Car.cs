namespace CarPrototype
{
    public class Car : ICar
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime FabricationDate { get; set; }
        public CarType Type { get; set; }

        public Car(string name, string cor, DateTime fabricationDate, CarType type)
        {
            Name = name;
            Color = cor;
            FabricationDate = fabricationDate;
            Type = type;
        }

        public Car ShallowCopy()
        {
            return (Car)this.MemberwiseClone();
        }

        public Car DeepCoppy()
        {
            var clone = (Car)this.MemberwiseClone();
            clone.Name = Name;
            clone.Color = Color;
            clone.FabricationDate = FabricationDate;
            clone.Type = Type;
            return clone;
        }

        public override string? ToString()
        {
            return $"{Name} + {Color} + {FabricationDate.Date} + {Type}";
        }
    }

    public enum CarType
    {
        Sedan = 0,
        Hatch = 1,
        SUV = 2,
    }

    public interface ICar
    {
        Car ShallowCopy();

        Car DeepCoppy();
    }
}
