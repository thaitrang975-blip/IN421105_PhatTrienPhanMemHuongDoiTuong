using EduHub.Ch02.Domain;

namespace EduHub.Ch02;

public class ClubService
{
    private readonly IClubRepository _repository;
    private readonly IAppLogger _logger;
    private readonly INotificationService _notificationService;

    public ClubService(IClubRepository repository, IAppLogger logger, INotificationService notificationService)
    {
        _repository = repository;
        _logger = logger;
        _notificationService = notificationService;
    }

    public void CreateClub(string name, string description, string presidentEmail)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Club name is required");
        if (name.Length > 100) throw new ArgumentException("Club name too long");

        var club = new Club { Id = Guid.NewGuid(), Name = name, Description = description };
        _repository.AddClub(club);
        _logger.Log($"[{DateTime.Now}] Club created: {name}");
        _notificationService.SendNotification(presidentEmail, $"Club {name} created.");
    }

    public void AddMemberToClub(Guid clubId, string memberName, string email)
    {
        var club = _repository.GetClubById(clubId) ?? throw new InvalidOperationException("Club not found");
        if (_repository.GetMemberCount(clubId) >= 50) throw new InvalidOperationException("Club is full");

        var member = new Member { Id = Guid.NewGuid(), Name = memberName, Email = email, ClubId = clubId };
        _repository.AddMember(member);
        _logger.Log($"[{DateTime.Now}] Member {memberName} joined {club.Name}");
        _notificationService.SendNotification(email, $"Welcome to {club.Name}");
    }
}