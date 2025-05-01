namespace Tests.PersonManagerTests;

public class EmploymentStatusTests
{
    private readonly PersonManagerDbContext _personManagerDbContext;
    private readonly IEmploymentStatusHandler _employmentStatusHandler;

    public EmploymentStatusTests()
    {
        var options = new DbContextOptionsBuilder<PersonManagerDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _personManagerDbContext = new PersonManagerDbContext(options);
        _employmentStatusHandler = new EmploymentStatusHandler(_personManagerDbContext);
    }

    private readonly static string TestStatusName1 = "Test Status 1";

    private readonly static string TestStatusName2 = "Test Status 2";

    private readonly EmploymentStatusModel EmploymentStatus1 = new()
    {
        StatusName = TestStatusName1,
    };

    private readonly EmploymentStatusModel EmploymentStatus2 = new()
    {
        StatusName = TestStatusName2,
    };

    [Fact]
    public async Task CreateEmploymentStatusAsync_CreatesEmploymentStatus()
    {
        ClearEmploymentStatuses();

        var initialCount = _personManagerDbContext.EmploymentStatuses.Count();

        await _employmentStatusHandler.CreateEmploymentStatusAsync(EmploymentStatus1);
        await _employmentStatusHandler.CreateEmploymentStatusAsync(EmploymentStatus2);
        _personManagerDbContext.SaveChanges();

        _personManagerDbContext.EmploymentStatuses.Count().Should().Be(initialCount + 2);
    }

    [Fact]
    public async Task GetEmploymentStatusesAsync_ReturnsEmploymentStatuses()
    {
        ClearEmploymentStatuses();
        _personManagerDbContext.EmploymentStatuses.Add(EmploymentStatus1);
        _personManagerDbContext.EmploymentStatuses.Add(EmploymentStatus2);
        await _personManagerDbContext.SaveChangesAsync();
        var employmentStatuses = await _employmentStatusHandler.GetEmploymentStatusesAsync();
        employmentStatuses.Should().HaveCount(2);
        employmentStatuses.Should().Contain(e => e.StatusName == TestStatusName1);
        employmentStatuses.Should().Contain(e => e.StatusName == TestStatusName2);
    }

    [Fact]
    public async Task GetEmploymentStatusAsync_ReturnsEmploymentStatus()
    {
        ClearEmploymentStatuses();
        _personManagerDbContext.EmploymentStatuses.Add(EmploymentStatus1);
        await _personManagerDbContext.SaveChangesAsync();

        var result = await _employmentStatusHandler.GetEmploymentStatusAsync(EmploymentStatus1.EmploymentStatusId);
        result.Should().NotBeNull();
        result.Should().BeOfType<EmploymentStatusModel>();
        result.StatusName.Should().Be(TestStatusName1);
    }

    [Fact]
    public async Task UpdateEmploymentStatus_UpdatesEmploymentStatus()
    {
        ClearEmploymentStatuses();

        _personManagerDbContext.EmploymentStatuses.Add(EmploymentStatus1);
        await _personManagerDbContext.SaveChangesAsync();

        var employmentStatusToUpdate = await _personManagerDbContext.EmploymentStatuses.FindAsync(EmploymentStatus1.EmploymentStatusId);
        employmentStatusToUpdate.StatusName = TestStatusName2;
        await _employmentStatusHandler.UpdateEmploymentStatusAsync(employmentStatusToUpdate);

        var updatedEmploymentStatus = await _personManagerDbContext.EmploymentStatuses.FindAsync(EmploymentStatus1.EmploymentStatusId);
        updatedEmploymentStatus.Should().NotBeNull();
        updatedEmploymentStatus.StatusName.Should().Be(TestStatusName2);
    }

    [Fact]
    public async Task DeleteEmploymentStatus_DeletesEmploymentStatus()
    {
        ClearEmploymentStatuses();
        var initialCount = _personManagerDbContext.EmploymentStatuses.Count();
        _personManagerDbContext.EmploymentStatuses.Add(EmploymentStatus1);
        await _personManagerDbContext.SaveChangesAsync();

        _personManagerDbContext.EmploymentStatuses.Count().Should().Be(initialCount + 1);

        await _employmentStatusHandler.DeleteEmploymentStatusAsync(EmploymentStatus1.EmploymentStatusId);

        _personManagerDbContext.EmploymentStatuses.Count().Should().Be(initialCount);
    }
        

    private void ClearEmploymentStatuses()
    {
        _personManagerDbContext.EmploymentStatuses.RemoveRange(_personManagerDbContext.EmploymentStatuses);
        _personManagerDbContext.SaveChanges();
    }
}
