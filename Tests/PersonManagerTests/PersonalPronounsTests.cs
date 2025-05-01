namespace Tests.PersonManagerTests;

public class PersonalPronounsTests
{
    private readonly PersonManagerDbContext _personManagerDbContext;
    private readonly IPersonalPronounsHandler _personalPronounsHandler;
    public PersonalPronounsTests()
    {
        var options = new DbContextOptionsBuilder<PersonManagerDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _personManagerDbContext = new PersonManagerDbContext(options);
        _personalPronounsHandler = new PersonalPronounsHandler(_personManagerDbContext);
    }

    private readonly static string TestPronouns1 = "Test Pronoun 1";
    
    private readonly static string TestPronouns2 = "Test Pronoun 2";
    
    private readonly PersonalPronounsModel PersonalPronouns1 = new()
    {
        PronounNames = TestPronouns1,
    };
    
    private readonly PersonalPronounsModel PersonalPronouns2 = new()
    {
        PronounNames = TestPronouns2,
    };

    [Fact]
    public async Task CreatePersonalPronounsAsync_CreatesPersonalPronouns()
    {
        await ClearPersonalPronounsAsync();
        var initialCount = _personManagerDbContext.PersonalPronouns.Count();
        await _personalPronounsHandler.CreatePersonalPronounsAsync(PersonalPronouns1);
        await _personalPronounsHandler.CreatePersonalPronounsAsync(PersonalPronouns2);
        await _personManagerDbContext.SaveChangesAsync();
        _personManagerDbContext.PersonalPronouns.Count().Should().Be(initialCount + 2);
    }

    [Fact]
    public async Task GetPersonalPronounsAsync_ReturnsPersonalPronouns()
    {
        await ClearPersonalPronounsAsync();
        _personManagerDbContext.PersonalPronouns.Add(PersonalPronouns1);
        _personManagerDbContext.PersonalPronouns.Add(PersonalPronouns2);
        await _personManagerDbContext.SaveChangesAsync();
        var personalpronouns = await _personalPronounsHandler.GetAllPersonalPronounsAsync();
        personalpronouns.Should().HaveCount(2);
        personalpronouns.Should().Contain(e => e.PronounNames == TestPronouns1);
        personalpronouns.Should().Contain(e => e.PronounNames == TestPronouns2);
    }

    [Fact]
    public async Task GetPersonalPronounAsync_ReturnsPersonalPronoun()
    {
        await ClearPersonalPronounsAsync();
        _personManagerDbContext.PersonalPronouns.Add(PersonalPronouns1);
        await _personManagerDbContext.SaveChangesAsync();

        var personalPronouns = await _personalPronounsHandler.GetPersonalPronounsByIdAsync(PersonalPronouns1.PersonalPronounsId);
        personalPronouns.Should().NotBeNull();
        personalPronouns.Should().BeOfType<PersonalPronounsModel>();
        personalPronouns.PronounNames.Should().Be(TestPronouns1);
    }

    [Fact]
    public async Task UpdatePersonalPronounsAsync_UpdatesPersonalPronouns()
    {
        await ClearPersonalPronounsAsync();

        _personManagerDbContext.PersonalPronouns.Add(PersonalPronouns1);
        await _personManagerDbContext.SaveChangesAsync();

        var personalPronounsToUpdate = await _personalPronounsHandler.GetPersonalPronounsByIdAsync(PersonalPronouns1.PersonalPronounsId);
        personalPronounsToUpdate.Should().NotBeNull();
        personalPronounsToUpdate.PronounNames = TestPronouns2;
        await _personalPronounsHandler.UpdatePersonalPronounsAsync(personalPronounsToUpdate);

        var updatedPronouns = await _personalPronounsHandler.GetPersonalPronounsByIdAsync(PersonalPronouns1.PersonalPronounsId);
        updatedPronouns.Should().NotBeNull();
        updatedPronouns.PronounNames.Should().Be(TestPronouns2);
    }

    [Fact]
    public async Task DeletePersonalPronounsAsync_DeletesPersonalPronouns()
    {
        await ClearPersonalPronounsAsync();
        var initialCount = _personManagerDbContext.PersonalPronouns.Count();
        _personManagerDbContext.PersonalPronouns.Add(PersonalPronouns1);
        await _personManagerDbContext.SaveChangesAsync();

        _personManagerDbContext.Genders.Count().Should().Be(initialCount + 1);

        await _personalPronounsHandler.DeletePersonalPronounsAsync(PersonalPronouns1.PersonalPronounsId);

        _personManagerDbContext.PersonalPronouns.Count().Should().Be(initialCount);
    }

    private async Task ClearPersonalPronounsAsync()
    {
        _personManagerDbContext.PersonalPronouns.RemoveRange(_personManagerDbContext.PersonalPronouns);
        await _personManagerDbContext.SaveChangesAsync();
    }
}
