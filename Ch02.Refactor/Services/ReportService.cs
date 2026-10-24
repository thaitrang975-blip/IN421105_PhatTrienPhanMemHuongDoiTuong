namespace EduHub.Ch02;

public class ReportService
{
    private readonly IClubRepository _repository;
    private readonly IAppLogger _logger;

    public ReportService(IClubRepository repository, IAppLogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void PrintClubReport()
    {
        foreach (var club in _repository.GetAllClubs())
        {
            var memberCount = _repository.GetMemberCount(club.Id);
            Console.WriteLine($"Club: {club.Name} | Members: {memberCount}");
            _logger.Log($"Report generated for {club.Name}");
        }
    }
}