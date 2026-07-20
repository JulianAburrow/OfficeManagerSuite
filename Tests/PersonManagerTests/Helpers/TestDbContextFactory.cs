namespace Tests.PersonManagerTests.Helpers;

public class TestDbContextFactory : IDbContextFactory<PersonManagerDbContext>
{
    private readonly DbContextOptions<PersonManagerDbContext> _options;

    public TestDbContextFactory(DbContextOptions<PersonManagerDbContext> options)
    {
        _options = options;
    }

    public PersonManagerDbContext CreateDbContext()
    {
        return new PersonManagerDbContext(_options);
    }
}
