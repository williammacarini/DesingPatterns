using BuilderPerson.Domain;

namespace BuilderPerson.Builder
{
    public class NewBuilder
    {
        protected Person person = new Person();

        public BuilderPersonDetails PersonDetails => new BuilderPersonDetails(person);
        public BuilderJobDetails JobDetails => new BuilderJobDetails(person);

        public static implicit operator Person(NewBuilder pb)
        {
            return pb.person;
        }
    }

    public class BuilderPersonDetails : NewBuilder
    {
        public BuilderPersonDetails(Person person)
        {
            this.person = person;
        }

        public BuilderPersonDetails Name(string name)
        {
            person.Name = name;
            return this;
        }

        public BuilderPersonDetails LastName(string lastName)
        {
            person.LastName = lastName;
            return this;
        }

        public BuilderPersonDetails City(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class BuilderJobDetails : NewBuilder
    {
        public BuilderJobDetails(Person person)
        {
            this.person = person;
        }

        public BuilderJobDetails Company(string company)
        {
            person.Company = company;
            return this;
        }

        public BuilderJobDetails Job(string job)
        {
            person.Job = job;
            return this;
        }

        public BuilderJobDetails Salary(decimal salary)
        {
            person.Salary = salary;
            return this;
        }
    }
}
