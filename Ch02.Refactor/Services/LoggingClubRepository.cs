using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _innerRepository;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(IClubRepository innerRepository, IAppLogger logger)
    {
        _innerRepository = innerRepository;
        _logger = logger;
    }

    public void AddClub(Club club)
    {
        _logger.Log($"[{DateTime.Now}] Accessing DB to add club: {club.Name}");
        _innerRepository.AddClub(club);
    }

    public List<Club> GetAllClubs()
    {
        _logger.Log($"[{DateTime.Now}] Accessing DB to get all clubs");
        return _innerRepository.GetAllClubs();
    }

    public void AddMember(Member member)
    {
        _logger.Log($"[{DateTime.Now}] Accessing DB to add member: {member.Name}");
        _innerRepository.AddMember(member);
    }

    public int GetMemberCount(Guid clubId) => _innerRepository.GetMemberCount(clubId);
}