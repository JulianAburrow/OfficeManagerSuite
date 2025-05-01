
namespace Tests.PersonManagerTests;

public class AddressTests
{
    private readonly PersonManagerDbContext _personManagerDbContext;
    private readonly IAddressHandler _addressHandler;
    private readonly IAddressTypeHandler _addressTypeHandler;
    private readonly IPersonHandler _personHandler;
    private readonly IEmploymentStatusHandler _employmentStatusHandler;

    public AddressTests()
    {
        var options = new DbContextOptionsBuilder<PersonManagerDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _personManagerDbContext = new PersonManagerDbContext(options);
        _addressHandler = new AddressHandler(_personManagerDbContext);
        _addressTypeHandler = new AddressTypeHandler(_personManagerDbContext);
        _personHandler = new PersonHandler(_personManagerDbContext);
        _employmentStatusHandler = new EmploymentStatusHandler(_personManagerDbContext);
        AddRequiredObjects();
    }

    private async void AddRequiredObjects()
    {
        await _addressTypeHandler.CreateAddressTypeAsync(AddressType);
        await _employmentStatusHandler.CreateEmploymentStatusAsync(EmploymentStatus);
        await _personHandler.CreatePersonAsync(Person1);
        await _personHandler.CreatePersonAsync(Person2);
        await _personManagerDbContext.SaveChangesAsync();
    }

    private readonly static string TestAddressLine1 = "Address Line 1";

    private readonly static string TestAddressLine2 = "Address Line 2";

    private static readonly string TestCity = "Test City";

    private static readonly string TestPostcode = "Test Postcode";

    private static readonly PersonModel Person1 = new()
    {
        FirstName = "Test1",
        LastName = "Person1",
        EmploymentStatusId = 1,
    };

    private static readonly PersonModel Person2 = new()
    {
        FirstName = "Test2",
        LastName = "Person2",
        EmploymentStatusId = 1,
    };

    private static readonly EmploymentStatusModel EmploymentStatus = new()
    {
        StatusName = "Test Employment Status",
    };

    private static readonly AddressTypeModel AddressType = new()
    {
        TypeName = "Test Address Type",
    };

    private static readonly AddressModel Address1 = new()
    {
        AddressTypeId = 1,
        AddressLine1 = TestAddressLine1,
        AddressLine2 = TestAddressLine2,
        City = TestCity,
        Postcode = TestPostcode,
        PersonId = 1,
    };

    private static readonly AddressModel Address2 = new()
    {
        AddressTypeId = 1,
        AddressLine1 = TestAddressLine1,
        AddressLine2 = TestAddressLine2,
        City = TestCity,
        Postcode = TestPostcode,
        PersonId = 1,
    };

    //[Fact]
    //public async Task CreateAddressAsync_CreatesAddress()
    //{
    //    await ClearAddressesAsync();
    //    var initialCount = _personManagerDbContext.Addresses.Count();
    //    await _addressHandler.CreateAddressAsync(Address1);
    //    await _addressHandler.CreateAddressAsync(Address2);
    //    await _personManagerDbContext.SaveChangesAsync();
    //    _personManagerDbContext.Addresses.Count().Should().Be(initialCount + 2);
    //}

    [Fact]
    public async Task GetAddressesAsync_ReturnsAddresses()
    {
        await ClearAddressesAsync();
        _personManagerDbContext.Addresses.Add(Address1);
        _personManagerDbContext.Addresses.Add(Address2);
        await _personManagerDbContext.SaveChangesAsync();
        var addresses = await _addressHandler.GetAddressesAsync(1);
        addresses.Should().HaveCount(2);
        addresses.Should().Contain(a => a.AddressLine1 == TestAddressLine1);
        addresses.Should().Contain(a => a.AddressLine2 == TestAddressLine2);
    }

    private async Task ClearAddressesAsync()
    {
        _personManagerDbContext.Addresses.RemoveRange(_personManagerDbContext.Addresses);
        await _personManagerDbContext.SaveChangesAsync();
    }
}
