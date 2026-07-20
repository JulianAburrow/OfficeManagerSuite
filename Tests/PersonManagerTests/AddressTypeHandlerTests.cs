namespace Tests.PersonManagerTests;

public class AddressTypeHandlerTests
{
    private static AddressTypeModel CreateType(string name) =>
        new() { TypeName = name };

    [Fact]
    public async Task CreateAddressTypeAsync_AddsType()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        var type = CreateType("Home");

        await handler.CreateAddressTypeAsync(type);

        var result = await context.AddressTypes.FirstOrDefaultAsync();
        result.Should().NotBeNull();
        result!.TypeName.Should().Be("Home");
    }

    [Fact]
    public async Task DeleteAddressTypeAsync_RemovesType_WhenExists()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var type = CreateType("Work");
        context.AddressTypes.Add(type);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new AddressTypeHandler(factory);
        await handler.DeleteAddressTypeAsync(type.AddressTypeId);

        var result = await context.AddressTypes.FindAsync(type.AddressTypeId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAddressTypeAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        await handler.DeleteAddressTypeAsync(999);

        context.AddressTypes.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAddressTypeByIdAsync_ReturnsType()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        var type = CreateType("Billing");
        context.AddressTypes.Add(type);
        await context.SaveChangesAsync();

        var result = await handler.GetAddressTypeByIdAsync(type.AddressTypeId);

        result.Should().NotBeNull();
        result.TypeName.Should().Be("Billing");
    }

    [Fact]
    public async Task GetAddressTypeByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        var result = await handler.GetAddressTypeByIdAsync(999);

        result.AddressTypeId.Should().Be(0);
        result.TypeName.Should().BeNull();
    }

    [Fact]
    public async Task GetAllAddressTypesAsync_ReturnsOrderedTypes()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        context.AddressTypes.AddRange(
            CreateType("Zeta"),
            CreateType("Alpha")
        );
        await context.SaveChangesAsync();

        var result = await handler.GetAllAddressTypesAsync();

        result.Should().HaveCount(2);
        result[0].TypeName.Should().Be("Alpha");
        result[1].TypeName.Should().Be("Zeta");
    }

    [Fact]
    public async Task GetAllAddressTypesAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        var result = await handler.GetAllAddressTypesAsync();

        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task UpdateAddressTypeAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var type = CreateType("Old");
        context.AddressTypes.Add(type);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new AddressTypeHandler(factory);
        var updated = new AddressTypeModel
        {
            AddressTypeId = type.AddressTypeId,
            TypeName = "New"
        };

        await handler.UpdateAddressTypeAsync(updated);

        var result = await context.AddressTypes.FindAsync(type.AddressTypeId);
        result!.TypeName.Should().Be("New");
    }

    [Fact]
    public async Task UpdateAddressTypeAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new AddressTypeHandler(factory);

        var updated = new AddressTypeModel
        {
            AddressTypeId = 999,
            TypeName = "Ghost"
        };

        await handler.UpdateAddressTypeAsync(updated);

        context.AddressTypes.Should().BeEmpty();
    }
}
