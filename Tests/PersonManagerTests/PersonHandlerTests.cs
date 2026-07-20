namespace Tests.PersonManagerTests;

public class PersonHandlerTests
{
    private static PersonModel CreatePerson(string first, string last) =>
        new()
        {
            FirstName = first,
            LastName = last,
            EmploymentStatusId = 1,
            PersonalPronounsId = 1,
            GenderId = 1
        };

    private static async Task SeedLookupsAsync(PersonManagerDbContext context)
    {
        context.EmploymentStatuses.Add(new EmploymentStatusModel { EmploymentStatusId = 1, StatusName = "Employed" });
        context.PersonalPronouns.Add(new PersonalPronounsModel { PersonalPronounsId = 1, PronounNames = "He/Him" });
        context.Genders.Add(new GenderModel { GenderId = 1, GenderName = "Male" });
        context.AddressTypes.Add(new AddressTypeModel { AddressTypeId = 1, TypeName = "Home" });
        context.Relationships.Add(new RelationshipModel { RelationshipId = 1, RelationshipName = "Friend" });

        await context.SaveChangesAsync();
    }

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreatePersonAsync_AddsPerson()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        var handler = new PersonHandler(factory);

        var person = CreatePerson("John", "Doe");
        await handler.CreatePersonAsync(person);

        var result = await context.People.ToListAsync();
        result.Should().HaveCount(1);
        result[0].FirstName.Should().Be("John");
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetPersonByIdAsync_ReturnsPersonWithNavigationProperties()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        var person = CreatePerson("Alice", "Smith");
        context.People.Add(person);
        await context.SaveChangesAsync();

        context.Addresses.Add(new AddressModel
        {
            PersonId = person.PersonId,
            AddressTypeId = 1,
            AddressLine1 = "Line1",
            City = "City",
            Postcode = "Postcode"
        });

        context.EmergencyContacts.Add(new EmergencyContactModel
        {
            PersonId = person.PersonId,
            FirstName = "Bob",
            LastName = "Jones",
            RelationshipId = 1,
            PhoneNumber = "123456",
        });

        await context.SaveChangesAsync();

        var handler = new PersonHandler(factory);
        var result = await handler.GetPersonByIdAsync(person.PersonId);

        result.Should().NotBeNull();
        result.FirstName.Should().Be("Alice");
        result.Addresses.Should().HaveCount(1);
        result.EmergencyContacts.Should().HaveCount(1);
        result.EmploymentStatus.Should().NotBeNull();
        result.PersonalPronouns.Should().NotBeNull();
        result.Gender.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPersonByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        var handler = new PersonHandler(factory);

        var result = await handler.GetPersonByIdAsync(999);

        result.PersonId.Should().Be(0);
        result.FirstName.Should().BeNull();
    }

    // ------------------------------------------------------------
    // GET ALL
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllPeopleAsync_ReturnsAllPeopleWithIncludes()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        context.People.Add(CreatePerson("A", "A"));
        context.People.Add(CreatePerson("B", "B"));
        await context.SaveChangesAsync();

        var handler = new PersonHandler(factory);
        var result = await handler.GetAllPeopleAsync();

        result.Should().HaveCount(2);
        result.Select(p => p.LastName).Should().BeInAscendingOrder();
        result.All(p => p.EmploymentStatus != null).Should().BeTrue();
        result.All(p => p.PersonalPronouns != null).Should().BeTrue();
        result.All(p => p.Gender != null).Should().BeTrue();
    }

    [Fact]
    public async Task GetAllPeopleForEmergencyContactAsync_ReturnsAllPeopleOrdered()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        context.People.Add(CreatePerson("Z", "Z"));
        context.People.Add(CreatePerson("A", "A"));
        await context.SaveChangesAsync();

        var handler = new PersonHandler(factory);
        var result = await handler.GetAllPeopleForEmergencyContactAsync();

        result.Should().HaveCount(2);
        result.First().LastName.Should().Be("A");
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdatePersonAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        var person = CreatePerson("Old", "Name");
        context.People.Add(person);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new PersonHandler(factory);

        var updated = new PersonModel
        {
            PersonId = person.PersonId,
            FirstName = "New",
            LastName = "Updated",
            EmailAddress = "test@example.com",
            PhoneNumber = "12345",
            EmploymentStatusId = 1,
            PersonalPronounsId = 1,
            GenderId = 1,
            Photo = new byte[] { 1, 2, 3 },
            Pronunciation = new byte[] { 1, 2, 3 },
        };

        await handler.UpdatePersonAsync(updated);

        var result = await context.People.FindAsync(person.PersonId);
        result!.FirstName.Should().Be("New");
        result.LastName.Should().Be("Updated");
        result.EmailAddress.Should().Be("test@example.com");
        result.PhoneNumber.Should().Be("12345");
        result.Photo.Should().Equal(new byte[] { 1, 2, 3 });
        result.Pronunciation.Should().Equal(new byte[] { 1, 2, 3 });
    }

    [Fact]
    public async Task UpdatePersonAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        var handler = new PersonHandler(factory);

        var ghost = new PersonModel
        {
            PersonId = 999,
            FirstName = "Ghost"
        };

        await handler.UpdatePersonAsync(ghost);

        context.People.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeletePersonAsync_RemovesPerson()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        var person = CreatePerson("Temp", "Person");
        context.People.Add(person);
        await context.SaveChangesAsync();

        var handler = new PersonHandler(factory);
        await handler.DeletePersonAsync(person.PersonId);

        context.People.Should().BeEmpty();
    }

    [Fact]
    public async Task DeletePersonAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedLookupsAsync(context);

        var handler = new PersonHandler(factory);
        await handler.DeletePersonAsync(999);

        context.People.Should().BeEmpty();
    }
}
