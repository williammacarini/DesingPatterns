using NUnit.Framework;

namespace FlyweightJetBrains
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }

    [TestFixture]
    public class TestUser
    {
        [Test]
        public void Test()
        {
            var users = Enumerable.Range(0, 1000).Select(_ => new User("William"));
        }
    }
}