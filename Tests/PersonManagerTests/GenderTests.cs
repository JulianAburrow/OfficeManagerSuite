
using System.Threading.Tasks;

namespace Tests.PersonManagerTests;

public class GenderTests
{
    private readonly PersonManagerDbContext _personManagerDbContext;
    private readonly IGenderHandler _genderHandler;

    public GenderTests()
    {
        var options = new DbContextOptionsBuilder<PersonManagerDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _personManagerDbContext = new PersonManagerDbContext(options);
        _genderHandler = new GenderHandler(_personManagerDbContext);
    }

    private readonly static string TestGenderName1 = "Test Gender Name 1";

    private readonly static string TestGenderName2 = "Test Gender Name 2";

    private readonly GenderModel Gender1 = new()
    {
        GenderName = TestGenderName1,
    };

    private readonly GenderModel Gender2 = new()
    {
        GenderName = TestGenderName2,
    };

    [Fact]
    public async Task CreateGenderAsync_CreatesGender()
    {
        await ClearGendersAsync();

        var initialCount = _personManagerDbContext.Genders.Count();

        await _genderHandler.CreateGenderAsync(Gender1);
        await _genderHandler.CreateGenderAsync(Gender2);
        await _personManagerDbContext.SaveChangesAsync();

        _personManagerDbContext.Genders.Count().Should().Be(initialCount + 2);
    }

    [Fact]
    public async Task GetGendersAsync_ReturnsGenders()
    {
        await ClearGendersAsync();
        _personManagerDbContext.Genders.Add(Gender1);
        _personManagerDbContext.Genders.Add(Gender2);
        await _personManagerDbContext.SaveChangesAsync();
        var genders = await _genderHandler.GetAllGendersAsync();
        genders.Should().HaveCount(2);
        genders.Should().Contain(g => g.GenderName == TestGenderName1);
        genders.Should().Contain(g => g.GenderName == TestGenderName2);
    }

    [Fact]
    public async Task GetGenderAsync_ReturnsGender()
    {
        await ClearGendersAsync();
        _personManagerDbContext.Genders.Add(Gender1);
        await _personManagerDbContext.SaveChangesAsync();

        var gender = await _genderHandler.GetGenderByIdAsync(Gender1.GenderId);
        gender.Should().NotBeNull();
        gender.Should().BeOfType<GenderModel>();
        gender.GenderName.Should().Be(TestGenderName1);
    }

    [Fact]
    public async Task UpdateGenderAsync_UpdatesGender()
    {
        await ClearGendersAsync();

        _personManagerDbContext.Genders.Add(Gender1);
        await _personManagerDbContext.SaveChangesAsync();

        var genderToUpdate = await _personManagerDbContext.Genders.FindAsync(Gender1.GenderId);
        genderToUpdate.Should().NotBeNull();
        genderToUpdate.GenderName = TestGenderName2;
        await _genderHandler.UpdateGenderAsync(genderToUpdate);

        var updatedGender = await _personManagerDbContext.Genders.FindAsync(Gender1.GenderId);
        updatedGender.Should().NotBeNull();
        updatedGender.GenderName.Should().Be(TestGenderName2);
    }

    [Fact]
    public async Task DeleteGenderAsync_DeletesGender()
    {
        await ClearGendersAsync();
        var initialCount = _personManagerDbContext.Genders.Count();
        _personManagerDbContext.Genders.Add(Gender1);
        await _personManagerDbContext.SaveChangesAsync();

        _personManagerDbContext.Genders.Count().Should().Be(initialCount + 1);

        await _genderHandler.DeleteGenderAsync(Gender1.GenderId);

        _personManagerDbContext.Genders.Count().Should().Be(initialCount);
    }

    private async Task ClearGendersAsync()
    {
        _personManagerDbContext.Genders.RemoveRange(_personManagerDbContext.Genders);
        await _personManagerDbContext.SaveChangesAsync();
    }
}
