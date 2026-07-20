namespace Tests.PersonManagerTests;

public class GenderHandlerTests
{
    private static GenderModel CreateGender(string name) =>
        new() { GenderName = name };

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreateGenderAsync_AddsGender()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new GenderHandler(factory);

        var gender = CreateGender("Male");
        await handler.CreateGenderAsync(gender);

        var result = await context.Genders.FirstOrDefaultAsync();
        result.Should().NotBeNull();
        result!.GenderName.Should().Be("Male");
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetGenderByIdAsync_ReturnsGender()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var gender = CreateGender("Female");
        context.Genders.Add(gender);
        await context.SaveChangesAsync();

        var handler = new GenderHandler(factory);
        var result = await handler.GetGenderByIdAsync(gender.GenderId);

        result.Should().NotBeNull();
        result.GenderName.Should().Be("Female");
    }

    [Fact]
    public async Task GetGenderByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new GenderHandler(factory);

        var result = await handler.GetGenderByIdAsync(999);

        result.GenderId.Should().Be(0);
        result.GenderName.Should().BeNull();
    }

    // ------------------------------------------------------------
    // GET ALL
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllGendersAsync_ReturnsAllGenders()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.Genders.AddRange(
            CreateGender("A"),
            CreateGender("B")
        );
        await context.SaveChangesAsync();

        var handler = new GenderHandler(factory);
        var result = await handler.GetAllGendersAsync();

        result.Should().HaveCount(2);
        result.Select(g => g.GenderName).Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task GetAllGendersAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new GenderHandler(factory);

        var result = await handler.GetAllGendersAsync();

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdateGenderAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var gender = CreateGender("Old");
        context.Genders.Add(gender);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new GenderHandler(factory);

        var updated = new GenderModel
        {
            GenderId = gender.GenderId,
            GenderName = "New"
        };

        await handler.UpdateGenderAsync(updated);

        var result = await context.Genders.FindAsync(gender.GenderId);
        result!.GenderName.Should().Be("New");
    }

    [Fact]
    public async Task UpdateGenderAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new GenderHandler(factory);

        var updated = new GenderModel
        {
            GenderId = 999,
            GenderName = "Ghost"
        };

        await handler.UpdateGenderAsync(updated);

        context.Genders.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeleteGenderAsync_RemovesGender()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var gender = CreateGender("Temp");
        context.Genders.Add(gender);
        await context.SaveChangesAsync();

        var handler = new GenderHandler(factory);
        await handler.DeleteGenderAsync(gender.GenderId);

        context.Genders.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteGenderAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new GenderHandler(factory);

        await handler.DeleteGenderAsync(999);

        context.Genders.Should().BeEmpty();
    }
}
