using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class ConsoleReportStrategy : IReportStrategy
{
    public void Generate(List<Club> clubs, IClubRepository repo)
    {
        foreach (var club in clubs)
        {
            var memberCount = repo.GetMemberCount(club.Id);
            Console.WriteLine($"Club: {club.Name} | Members: {memberCount}");
        }
    }
}

public class CsvReportStrategy : IReportStrategy
{
    public void Generate(List<Club> clubs, IClubRepository repo)
    {
        Console.WriteLine("ClubName,MemberCount");
        foreach (var club in clubs)
        {
            var memberCount = repo.GetMemberCount(club.Id);
            Console.WriteLine($"{club.Name},{memberCount}");
        }
    }
}