using JetBrains.dotMemoryUnit;

namespace Flyweight
{
    public static class Program
    {
        static void Main(string[] args)
        {
            void ForceGC()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            static string RandomString()
            {
                Random rand = new Random();
                return new string(
                  Enumerable.Range(0, 10).Select(i => (char)('a' + rand.Next(26))).ToArray());
            }

            var users = new List<User>();

            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User($"{firstName} {lastName}").Memory());

            ForceGC();
        }

        public class User
        {
            static List<string> strings = new List<string>();
            private int[] _names { get; }

            public User(string fullName)
            {
                int getOrAdd(string s)
                {
                    int idx = strings.IndexOf(s);
                    if (idx != -1) return idx;
                    else
                    {
                        strings.Add(s);
                        return strings.Count - 1;
                    }
                }

                _names = fullName.Split(' ').Select(getOrAdd).ToArray();
            }

            public User Memory()
            {
                dotMemory.Check(memory =>
                {
                    Console.WriteLine(memory.SizeInBytes);
                });

                return this;
            }
            public string FullName => string.Join(" ", _names);
        }
    }
}