using EduHub.Ch02.Domain;

namespace EduHub.Ch02;

public class EventService
{
    private readonly IClubRepository _repository;
    private readonly IAppLogger _logger;

    public EventService(IClubRepository repository, IAppLogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date)
    {
        var club = _repository.GetClubById(clubId) ?? throw new InvalidOperationException("Club not found");
        var ev = new Event { Id = Guid.NewGuid(), ClubId = clubId, Title = title, Date = date };
        _logger.Log($"[{DateTime.Now}] Event created: {title}");
        return ev;
    }
}