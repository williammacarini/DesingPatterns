using BuilderPerson.Builder;
using BuilderPerson.Domain;

public class Program
{
    private static void Main(string[] args)
    {
        var pb = new NewBuilder();
        Person person = pb
          .PersonDetails
            .Name("William")
            .LastName("Macarini")
            .City("Cascavel")
          .JobDetails
            .Company("Ambev")
            .Job("Engineer")
            .Salary(123000);

        Console.WriteLine(person);
    }
}