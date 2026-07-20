namespace Tests.PersonManagerTests;

public class EmploymentStatusHandlerTests
{
    private static EmploymentStatusModel CreateStatus(string name) =>
        new() { StatusName = name };

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreateEmploymentStatusAsync_AddsStatus()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new EmploymentStatusHandler(factory);

        var status = CreateStatus("Full Time");
        await handler.CreateEmploymentStatusAsync(status);

        var result = await context.EmploymentStatuses.FirstOrDefaultAsync();
        result.Should().NotBeNull();
        result!.StatusName.Should().Be("Full Time");
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetEmploymentStatusByIdAsync_ReturnsStatus()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var status = CreateStatus("Part Time");
        context.EmploymentStatuses.Add(status);
        await context.SaveChangesAsync();

        var handler = new EmploymentStatusHandler(factory);
        var result = await handler.GetEmploymentStatusByIdAsync(status.EmploymentStatusId);

        result.Should().NotBeNull();
        result.StatusName.Should().Be("Part Time");
    }

    [Fact]
    public async Task GetEmploymentStatusByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new EmploymentStatusHandler(factory);

        var result = await handler.GetEmploymentStatusByIdAsync(999);

        result.EmploymentStatusId.Should().Be(0);
        result.StatusName.Should().BeNull();
    }

    // ------------------------------------------------------------
    // GET ALL
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllEmploymentStatusesAsync_ReturnsAllStatuses()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.EmploymentStatuses.AddRange(
            CreateStatus("A"),
            CreateStatus("B")
        );
        await context.SaveChangesAsync();

        var handler = new EmploymentStatusHandler(factory);
        var result = await handler.GetAllEmploymentStatusesAsync();

        result.Should().HaveCount(2);
        result.Select(s => s.StatusName).Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task GetAllEmploymentStatusesAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new EmploymentStatusHandler(factory);

        var result = await handler.GetAllEmploymentStatusesAsync();

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdateEmploymentStatusAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var status = CreateStatus("Old Name");
        context.EmploymentStatuses.Add(status);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new EmploymentStatusHandler(factory);

        var updated = new EmploymentStatusModel
        {
            EmploymentStatusId = status.EmploymentStatusId,
            StatusName = "New Name"
        };

        await handler.UpdateEmploymentStatusAsync(updated);

        var result = await context.EmploymentStatuses.FindAsync(status.EmploymentStatusId);
        result!.StatusName.Should().Be("New Name");
    }

    [Fact]
    public async Task UpdateEmploymentStatusAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new EmploymentStatusHandler(factory);

        var updated = new EmploymentStatusModel
        {
            EmploymentStatusId = 999,
            StatusName = "Ghost"
        };

        await handler.UpdateEmploymentStatusAsync(updated);

        context.EmploymentStatuses.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeleteEmploymentStatusAsync_RemovesStatus()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var status = CreateStatus("Temp");
        context.EmploymentStatuses.Add(status);
        await context.SaveChangesAsync();

        var handler = new EmploymentStatusHandler(factory);
        await handler.DeleteEmploymentStatusAsync(status.EmploymentStatusId);

        context.EmploymentStatuses.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteEmploymentStatusAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new EmploymentStatusHandler(factory);

        await handler.DeleteEmploymentStatusAsync(999);

        context.EmploymentStatuses.Should().BeEmpty();
    }
}
