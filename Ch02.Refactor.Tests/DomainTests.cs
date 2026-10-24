using EduHub.Ch02.Domain;
using Xunit;

namespace Ch02.Refactor.Tests;

public class DomainTests
{
    [Fact]
    public void Club_Create_ValidName_ReturnsClubObject()
    {
        var name = "Tech Club";
        var desc = "Description";
        var club = Club.Create(name, desc);
        Assert.NotNull(club);
        Assert.Equal(name, club.Name);
    }

    [Fact]
    public void Club_Create_EmptyName_ThrowsArgumentException()
    {
        var name = "";
        Assert.Throws<ArgumentException>(() => Club.Create(name, "Desc"));
    }

    [Fact]
    public void Club_HasRoom_LessThanMaxMembers_ReturnsTrue()
    {
        var currentMembers = 49;
        var club = Club.Create("Test Club", "Desc");
        var result = club.HasRoom(currentMembers);
        Assert.True(result);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        var ev = new Event { Id = Guid.NewGuid(), ClubId = Guid.NewGuid(), Title = "Event", Date = DateTime.Now };
        var memberId = Guid.NewGuid();
        var result = ev.Register(memberId);
        Assert.True(result);
        Assert.Contains(memberId, ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_Register_ExistingMember_ReturnsFalse()
    {
        var ev = new Event { Id = Guid.NewGuid(), ClubId = Guid.NewGuid(), Title = "Event", Date = DateTime.Now };
        var memberId = Guid.NewGuid();
        ev.Register(memberId);
        var result = ev.Register(memberId);
        Assert.False(result);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        var ev = new Event { Id = Guid.NewGuid(), ClubId = Guid.NewGuid(), Title = "Event", Date = DateTime.Now };
        var memberId = Guid.NewGuid();
        Assert.Throws<InvalidOperationException>(() => ev.CheckIn(memberId));
    }
}