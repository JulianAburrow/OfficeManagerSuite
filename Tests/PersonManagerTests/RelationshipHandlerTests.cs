namespace Tests.PersonManagerTests;

public class RelationshipHandlerTests
{
    private static RelationshipModel CreateRelationship(string name) =>
        new() { RelationshipName = name };

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreateRelationshipAsync_AddsRelationship()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new RelationshipHandler(factory);

        var relationship = CreateRelationship("Friend");
        await handler.CreateRelationshipAsync(relationship);

        var result = await context.Relationships.ToListAsync();
        result.Should().HaveCount(1);
        result[0].RelationshipName.Should().Be("Friend");
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetRelationshipByIdAsync_ReturnsRelationship()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var relationship = CreateRelationship("Sibling");
        context.Relationships.Add(relationship);
        await context.SaveChangesAsync();

        var handler = new RelationshipHandler(factory);
        var result = await handler.GetRelationshipByIdAsync(relationship.RelationshipId);

        result.Should().NotBeNull();
        result.RelationshipName.Should().Be("Sibling");
    }

    [Fact]
    public async Task GetRelationshipByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new RelationshipHandler(factory);

        var result = await handler.GetRelationshipByIdAsync(999);

        result.RelationshipId.Should().Be(0);
        result.RelationshipName.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // GET ALL
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllRelationshipsAsync_ReturnsAllRelationshipsOrdered()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.Relationships.AddRange(
            CreateRelationship("Zeta"),
            CreateRelationship("Alpha")
        );
        await context.SaveChangesAsync();

        var handler = new RelationshipHandler(factory);
        var result = await handler.GetAllRelationshipsAsync();

        result.Should().HaveCount(2);
        result[0].RelationshipName.Should().Be("Alpha");
        result[1].RelationshipName.Should().Be("Zeta");
    }

    [Fact]
    public async Task GetAllRelationshipsAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new RelationshipHandler(factory);

        var result = await handler.GetAllRelationshipsAsync();

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdateRelationshipAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var relationship = CreateRelationship("Old");
        context.Relationships.Add(relationship);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new RelationshipHandler(factory);

        var updated = new RelationshipModel
        {
            RelationshipId = relationship.RelationshipId,
            RelationshipName = "New"
        };

        await handler.UpdateRelationshipAsync(updated);

        var result = await context.Relationships.FindAsync(relationship.RelationshipId);
        result!.RelationshipName.Should().Be("New");
    }

    [Fact]
    public async Task UpdateRelationshipAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new RelationshipHandler(factory);

        var updated = new RelationshipModel
        {
            RelationshipId = 999,
            RelationshipName = "Ghost"
        };

        await handler.UpdateRelationshipAsync(updated);

        context.Relationships.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeleteRelationshipAsync_RemovesRelationship()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var relationship = CreateRelationship("Temp");
        context.Relationships.Add(relationship);
        await context.SaveChangesAsync();

        var handler = new RelationshipHandler(factory);
        await handler.DeleteRelationshipAsync(relationship.RelationshipId);

        context.Relationships.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteRelationshipAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new RelationshipHandler(factory);

        await handler.DeleteRelationshipAsync(999);

        context.Relationships.Should().BeEmpty();
    }
}
