namespace TemplateMethodMessage;

public static class Program
{
    static void Main(string[] args)
    {
        var message = new Message("Testing Template Method!");
        message.SendMessageBySMS();
        message.SendMessageByWhatsApp();
        message.SendMessageByInstagram();

        var message2 = new Message("Testing Template Method 2!");
        message2.SendAllMessage();
    }
}

public abstract class TemplateMessage
{
    public void SendAllMessage()
    {
        SendMessageBySMS();
        SendMessageByWhatsApp();
        SendMessageByInstagram();
    }

    public abstract void SendMessageBySMS();
    public abstract void SendMessageByWhatsApp();
    public abstract void SendMessageByInstagram();
}

public class Message : TemplateMessage
{
    public string TextMessage { get; init; }

    public Message(string textMessage)
    {
        TextMessage = textMessage;
    }

    public override void SendMessageByInstagram()
    {
        Console.WriteLine($"Instagram:{TextMessage}");
    }

    public override void SendMessageBySMS()
    {
        Console.WriteLine($"SMS:{TextMessage}");
    }

    public override void SendMessageByWhatsApp()
    {
        Console.WriteLine($"WhatsApp:{TextMessage}");
    }
}