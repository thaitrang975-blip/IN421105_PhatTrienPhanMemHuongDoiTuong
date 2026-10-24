using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interfaces;

public interface IReportStrategy
{
    void Generate(List<Club> clubs, IClubRepository repo);
}