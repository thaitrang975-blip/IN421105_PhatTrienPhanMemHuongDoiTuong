using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interfaces;

public interface INotificationServiceFactory
{
    INotificationService Create(NotificationChannel channel);
}