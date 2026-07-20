namespace Tests.PersonManagerTests;

public class AddressHandlerTests
{
    private static AddressModel CreateAddress(int personId) =>
        new()
        {
            AddressTypeId = 1,
            AddressLine1 = "Line1",
            AddressLine2 = "Line2",
            City = "City",
            Postcode = "Postcode",
            PersonId = personId
        };

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreateAddressAsync_AddsAddress()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        // Required setup
        context.AddressTypes.Add(new AddressTypeModel { AddressTypeId = 1, TypeName = "Test" });
        context.EmploymentStatuses.Add(new EmploymentStatusModel { EmploymentStatusId = 1, StatusName = "Employed" });
        context.People.Add(new PersonModel { PersonId = 1, FirstName = "A", LastName = "B", EmploymentStatusId = 1 });
        await context.SaveChangesAsync();

        var handler = new AddressHandler(factory);

        var address = CreateAddress(1);
        await handler.CreateAddressAsync(address);

        var result = await context.Addresses.FirstOrDefaultAsync();
        result.Should().NotBeNull();
        result!.PersonId.Should().Be(1);
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAddressByIdAsync_ReturnsAddress()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.AddressTypes.Add(new AddressTypeModel { AddressTypeId = 1, TypeName = "Test" });
        context.EmploymentStatuses.Add(new EmploymentStatusModel { EmploymentStatusId = 1, StatusName = "Employed" });
        context.People.Add(new PersonModel { PersonId = 1, FirstName = "A", LastName = "B", EmploymentStatusId = 1 });

        var address = CreateAddress(1);
        context.Addresses.Add(address);
        await context.SaveChangesAsync();

        var handler = new AddressHandler(factory);
        var result = await handler.GetAddressByIdAsync(address.AddressId);

        result.Should().NotBeNull();
        result.AddressLine1.Should().Be("Line1");
        result.PersonId.Should().Be(1);
    }

    [Fact]
    public async Task GetAddressByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressHandler(factory);

        var result = await handler.GetAddressByIdAsync(999);

        result.AddressId.Should().Be(0);
    }

    // ------------------------------------------------------------
    // GET ALL BY PERSON
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllAddressesAsync_ReturnsAddressesForPerson()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.AddressTypes.Add(new AddressTypeModel { AddressTypeId = 1, TypeName = "Test" });
        context.EmploymentStatuses.Add(new EmploymentStatusModel { EmploymentStatusId = 1, StatusName = "Employed" });
        context.People.Add(new PersonModel { PersonId = 1, FirstName = "A", LastName = "B", EmploymentStatusId = 1 });
        context.People.Add(new PersonModel { PersonId = 2, FirstName = "C", LastName = "D", EmploymentStatusId = 1 });

        context.Addresses.Add(CreateAddress(1));
        context.Addresses.Add(CreateAddress(1));
        context.Addresses.Add(CreateAddress(2));
        await context.SaveChangesAsync();

        var handler = new AddressHandler(factory);
        var result = await handler.GetAllAddressesAsync(1);

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetAllAddressesAsync_ReturnsEmptyList_WhenPersonHasNone()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var handler = new AddressHandler(factory);
        var result = await handler.GetAllAddressesAsync(1);

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdateAddressAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.AddressTypes.Add(new AddressTypeModel { AddressTypeId = 1, TypeName = "Test" });
        context.EmploymentStatuses.Add(new EmploymentStatusModel { EmploymentStatusId = 1, StatusName = "Employed" });
        context.People.Add(new PersonModel { PersonId = 1, FirstName = "A", LastName = "B", EmploymentStatusId = 1 });

        var address = CreateAddress(1);
        context.Addresses.Add(address);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new AddressHandler(factory);

        var updated = new AddressModel
        {
            AddressId = address.AddressId,
            AddressLine1 = "Updated",
            City = "NewCity",
            AddressTypeId = 1,
            PersonId = 1
        };

        await handler.UpdateAddressAsync(updated);

        var result = await context.Addresses.FindAsync(address.AddressId);
        result!.AddressLine1.Should().Be("Updated");
        result.City.Should().Be("NewCity");
    }

    [Fact]
    public async Task UpdateAddressAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var handler = new AddressHandler(factory);

        var updated = new AddressModel
        {
            AddressId = 999,
            AddressLine1 = "Ghost"
        };

        await handler.UpdateAddressAsync(updated);

        context.Addresses.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeleteAddressAsync_RemovesAddress()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        context.AddressTypes.Add(new AddressTypeModel { AddressTypeId = 1, TypeName = "Test" });
        context.EmploymentStatuses.Add(new EmploymentStatusModel { EmploymentStatusId = 1, StatusName = "Employed" });
        context.People.Add(new PersonModel { PersonId = 1, FirstName = "A", LastName = "B", EmploymentStatusId = 1 });

        var address = CreateAddress(1);
        context.Addresses.Add(address);
        await context.SaveChangesAsync();

        var handler = new AddressHandler(factory);
        await handler.DeleteAddressAsync(address.AddressId);

        context.Addresses.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteAddressAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var handler = new AddressHandler(factory);
        await handler.DeleteAddressAsync(999);

        context.Addresses.Should().BeEmpty();
    }
}
