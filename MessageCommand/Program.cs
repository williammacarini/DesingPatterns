namespace MessageCommand
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting.");

            var executeCommand = new ExecuteCommand();
            executeCommand.Execute(new SMSCommand("New SMS to test!"));
            executeCommand.Execute(new WhatsAppCommand("New WhatsApp to test!"));

            Console.WriteLine("Finished.");
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class SMSCommand : ICommand
    {
        private readonly string _message;

        public SMSCommand(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"SMS: {_message}");
        }
    }

    public class WhatsAppCommand : ICommand
    {
        private readonly string _message;

        public WhatsAppCommand(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"WhatsApp: {_message}");
        }
    }

    public class ExecuteCommand
    {
        public void Execute(ICommand command) => command.Execute();
    }
}