using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interfaces;

public interface IEventObserver
{
    void OnEventCreated(Event ev);
}