public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Отправка Email: {message}");
    }
}

public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Отправка SMS: {message}");
    }
}

public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Send(string message)
    {
        _messageService.SendMessage(message);
    }
}

class Program
{
    static void Main()
    {
        IMessageService emailService = new EmailService();
        Notification emailNotification = new Notification(emailService);
        emailNotification.Send("Это email сообщение.");

        IMessageService smsService = new SmsService();
        Notification smsNotification = new Notification(smsService);
        smsNotification.Send("Это SMS сообщение.");
    }
}
