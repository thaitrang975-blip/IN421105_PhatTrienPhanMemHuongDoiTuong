using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class EmailNotifierObserver : IEventObserver
{
    public void OnEventCreated(Event ev)
    {
        Console.WriteLine($"Email sent: New event '{ev.Title}' created.");
    }
}

public class LogNotifierObserver : IEventObserver
{
    private readonly IAppLogger _logger;
    public LogNotifierObserver(IAppLogger logger) => _logger = logger;

    public void OnEventCreated(Event ev)
    {
        _logger.Log($"[{DateTime.Now}] Event created in log: {ev.Title}");
    }
}