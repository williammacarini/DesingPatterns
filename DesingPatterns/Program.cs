//using Builder.Builder;
//using Builder.Domain;

//var builderPayment = new BuilderPayment(new Payment()).AddUsersToPay().AddDataToPay().Build();

//Console.WriteLine(builderPayment);



using DotNetDesignPatternDemos.Creational.Factories.Coding.Exercise;

namespace DotNetDesignPatternDemos.Creational.Factories
{
    namespace Coding.Exercise
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Id.ToString($"{Id} + {Name}");
            }
        }

        public class PersonFactory
        {
            private int id = 0;

            public Person CreatePerson(string name)
            {
                return new Person { Id = id++, Name = name };
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pf = new PersonFactory();

            var p1 = pf.CreatePerson("Chris");
            Console.WriteLine(p1);

            var p2 = pf.CreatePerson("Sarah");
            Console.WriteLine(p2);
        }
    }
}
