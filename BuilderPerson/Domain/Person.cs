namespace BuilderPerson.Domain
{
    public class Person
    {
        public string Name, LastName, City;
        public string Company, Job;
        public decimal Salary;

        public override string? ToString()
        {
            return $"{Name}, {LastName}, {City}, {Company}, {Job}, {Salary}";
        }
    }
}
