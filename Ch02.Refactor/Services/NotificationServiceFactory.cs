using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class NotificationServiceFactory : INotificationServiceFactory
{
    public INotificationService Create(NotificationChannel channel)
    {
        return channel switch
        {
            NotificationChannel.Gmail => new GmailNotifier(),
            NotificationChannel.Yahoo => new YahooNotifier(),
            _ => new GenericNotifier()
        };
    }
}

public class GmailNotifier : INotificationService
{
    public void SendNotification(string to, string msg) => Console.WriteLine($"Sending Gmail notification to {to}: {msg}");
}

public class YahooNotifier : INotificationService
{
    public void SendNotification(string to, string msg) => Console.WriteLine($"Sending Yahoo notification to {to}: {msg}");
}

public class GenericNotifier : INotificationService
{
    public void SendNotification(string to, string msg) => Console.WriteLine($"Sending generic email to {to}: {msg}");
}