using EduHub.Ch02.Domain;

namespace EduHub.Ch02;

public interface IClubRepository
{
	void AddClub(Club club);
	List<Club> GetAllClubs();
	void AddMember(Member member);
	int GetMemberCount(Guid clubId);
	Club GetClubById(Guid clubId);
	List<Member> GetMembersByClub(Guid clubId);
}