namespace EduHub.Ch02;

public interface INotificationService
{
    void SendNotification(string recipient, string message);
}