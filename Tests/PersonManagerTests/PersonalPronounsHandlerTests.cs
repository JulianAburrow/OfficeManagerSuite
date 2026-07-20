namespace Tests.PersonManagerTests;

public class PersonalPronounsHandlerTests
{
    private static PersonalPronounsModel CreatePronouns(string name) =>
        new() { PronounNames = name };

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreatePersonalPronounsAsync_AddsPronouns()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var pronouns = CreatePronouns("He/Him");
        await handler.CreatePersonalPronounsAsync(pronouns);

        context.PersonalPronouns.Count().Should().Be(1);
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetPersonalPronounsByIdAsync_ReturnsPronouns()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var pronouns = CreatePronouns("She/Her");
        context.PersonalPronouns.Add(pronouns);
        await context.SaveChangesAsync();

        var result = await handler.GetPersonalPronounsByIdAsync(pronouns.PersonalPronounsId);

        result.PronounNames.Should().Be("She/Her");
    }

    [Fact]
    public async Task GetPersonalPronounsByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var result = await handler.GetPersonalPronounsByIdAsync(999);

        result.PersonalPronounsId.Should().Be(0);
        result.PronounNames.Should().BeNull();
    }

    // ------------------------------------------------------------
    // GET ALL
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllPersonalPronounsAsync_ReturnsAllPronouns()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        context.PersonalPronouns.Add(CreatePronouns("A"));
        context.PersonalPronouns.Add(CreatePronouns("B"));
        await context.SaveChangesAsync();

        var result = await handler.GetAllPersonalPronounsAsync();

        result.Should().HaveCount(2);
        result.Select(p => p.PronounNames).Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task GetAllPersonalPronounsAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var result = await handler.GetAllPersonalPronounsAsync();

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdatePersonalPronounsAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var pronouns = CreatePronouns("Old");
        context.PersonalPronouns.Add(pronouns);
        await context.SaveChangesAsync();

        pronouns.PronounNames = "New";

        await handler.UpdatePersonalPronounsAsync(pronouns);

        var updated = await context.PersonalPronouns.FindAsync(pronouns.PersonalPronounsId);
        updated.Should().NotBeNull();
        updated.PronounNames.Should().Be("New");
    }

    [Fact]
    public async Task UpdatePersonalPronounsAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var pronouns = CreatePronouns("Ghost");
        pronouns.PersonalPronounsId = 999;

        await handler.UpdatePersonalPronounsAsync(pronouns);

        context.PersonalPronouns.Count().Should().Be(0);
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeletePersonalPronounsAsync_RemovesPronouns()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        var pronouns = CreatePronouns("Temp");
        context.PersonalPronouns.Add(pronouns);
        await context.SaveChangesAsync();

        await handler.DeletePersonalPronounsAsync(pronouns.PersonalPronounsId);

        context.PersonalPronouns.Count().Should().Be(0);
    }

    [Fact]
    public async Task DeletePersonalPronounsAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonalPronounsHandler(factory);
        await ClearPronounsAsync();

        await handler.DeletePersonalPronounsAsync(999);

        context.PersonalPronouns.Count().Should().Be(0);
    }

    // ------------------------------------------------------------
    // UTIL
    // ------------------------------------------------------------

    private async Task ClearPronounsAsync()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        context.PersonalPronouns.RemoveRange(context.PersonalPronouns);
        await context.SaveChangesAsync();
    }
}
