namespace Tests.PersonManagerTests.Helpers;

public static class DbContextHelper
{
    public static IDbContextFactory<PersonManagerDbContext> GetInMemoryFactory()
    {
        var options = BuildOptions();
        return new TestDbContextFactory(options);
    }

    private static DbContextOptions<PersonManagerDbContext> BuildOptions() =>
        new DbContextOptionsBuilder<PersonManagerDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // unique DB per test
            .Options;
}
