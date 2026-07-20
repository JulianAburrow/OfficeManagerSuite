namespace Tests.PersonManagerTests;

public class EmergencyContactHandlerTests
{
    private static EmergencyContactModel CreateContact(int personId, string first, string last) =>
        new()
        {
            PersonId = personId,
            FirstName = first,
            LastName = last,
            PhoneNumber = "12345",
            Relationship = new RelationshipModel {  RelationshipName = "Friend"}
        };

    private static async Task SeedPeopleAsync(PersonManagerDbContext context)
    {
        context.EmploymentStatuses.Add(new EmploymentStatusModel
        {
            EmploymentStatusId = 1,
            StatusName = "Test Employment"
        });

        context.People.AddRange(
            new PersonModel { PersonId = 1, FirstName = "Person1", LastName = "Test", EmploymentStatusId = 1 },
            new PersonModel { PersonId = 2, FirstName = "Person2", LastName = "Test", EmploymentStatusId = 1 }
        );

        await context.SaveChangesAsync();
    }

    // ------------------------------------------------------------
    // CREATE
    // ------------------------------------------------------------

    [Fact]
    public async Task CreateEmergencyContactAsync_AddsContact()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var handler = new EmergencyContactHandler(factory);

        var contact = CreateContact(1, "A", "B");
        await handler.CreateEmergencyContactAsync(contact);

        var result = await context.EmergencyContacts.FirstOrDefaultAsync();
        result.Should().NotBeNull();
        result!.FirstName.Should().Be("A");
    }

    // ------------------------------------------------------------
    // GET BY ID
    // ------------------------------------------------------------

    [Fact]
    public async Task GetEmergencyContactByIdAsync_ReturnsContact()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var contact = CreateContact(1, "John", "Doe");
        context.EmergencyContacts.Add(contact);
        await context.SaveChangesAsync();

        var handler = new EmergencyContactHandler(factory);
        var result = await handler.GetEmergencyContactByIdAsync(contact.EmergencyContactId);

        result.Should().NotBeNull();
        result.FirstName.Should().Be("John");
        result.LastName.Should().Be("Doe");
    }

    [Fact]
    public async Task GetEmergencyContactByIdAsync_ReturnsEmptyModel_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var handler = new EmergencyContactHandler(factory);
        var result = await handler.GetEmergencyContactByIdAsync(999);

        result.EmergencyContactId.Should().Be(0);
        result.FirstName.Should().BeNull();
        result.LastName.Should().BeNull();
    }

    // ------------------------------------------------------------
    // GET ALL
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllEmergencyContactsAsync_ReturnsAllContacts()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        context.EmergencyContacts.Add(CreateContact(1, "A", "A"));
        context.EmergencyContacts.Add(CreateContact(2, "B", "B"));
        await context.SaveChangesAsync();

        var handler = new EmergencyContactHandler(factory);
        var result = await handler.GetAllEmergencyContactsAsync();

        result.Should().HaveCount(2);
        result.Select(c => c.LastName).Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task GetAllEmergencyContactsAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();

        var handler = new EmergencyContactHandler(factory);
        var result = await handler.GetAllEmergencyContactsAsync();

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // GET ALL BY PERSON
    // ------------------------------------------------------------

    [Fact]
    public async Task GetAllEmergencyContactsByPersonIdAsync_ReturnsContactsForPerson()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        context.EmergencyContacts.Add(CreateContact(1, "A", "A"));
        context.EmergencyContacts.Add(CreateContact(1, "B", "B"));
        context.EmergencyContacts.Add(CreateContact(2, "C", "C"));
        await context.SaveChangesAsync();

        var handler = new EmergencyContactHandler(factory);
        var result = await handler.GetAllEmergencyContactsByPersonIdAsync(1);

        result.Should().HaveCount(2);
        result.All(c => c.PersonId == 1).Should().BeTrue();
    }

    [Fact]
    public async Task GetAllEmergencyContactsByPersonIdAsync_ReturnsEmptyList_WhenNoneExist()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var handler = new EmergencyContactHandler(factory);
        var result = await handler.GetAllEmergencyContactsByPersonIdAsync(1);

        result.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // UPDATE
    // ------------------------------------------------------------

    [Fact]
    public async Task UpdateEmergencyContactAsync_UpdatesFields()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var contact = CreateContact(1, "Old", "Name");
        context.EmergencyContacts.Add(contact);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var handler = new EmergencyContactHandler(factory);

        var updated = new EmergencyContactModel
        {
            EmergencyContactId = contact.EmergencyContactId,
            PersonId = 1,
            FirstName = "New",
            LastName = "Updated",
            PhoneNumber = "99999",
        };

        await handler.UpdateEmergencyContactAsync(updated);

        var result = await context.EmergencyContacts.FindAsync(contact.EmergencyContactId);
        result!.FirstName.Should().Be("New");
        result.LastName.Should().Be("Updated");
        result.PhoneNumber.Should().Be("99999");
    }

    [Fact]
    public async Task UpdateEmergencyContactAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var handler = new EmergencyContactHandler(factory);

        var updated = new EmergencyContactModel
        {
            EmergencyContactId = 999,
            FirstName = "Ghost"
        };

        await handler.UpdateEmergencyContactAsync(updated);

        context.EmergencyContacts.Should().BeEmpty();
    }

    // ------------------------------------------------------------
    // DELETE
    // ------------------------------------------------------------

    [Fact]
    public async Task DeleteEmergencyContactAsync_RemovesContact()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var contact = CreateContact(1, "Temp", "Contact");
        context.EmergencyContacts.Add(contact);
        await context.SaveChangesAsync();

        var handler = new EmergencyContactHandler(factory);
        await handler.DeleteEmergencyContactAsync(contact.EmergencyContactId);

        context.EmergencyContacts.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteEmergencyContactAsync_DoesNothing_WhenNotFound()
    {
        var factory = DbContextHelper.GetInMemoryFactory();
        await using var context = await factory.CreateDbContextAsync();
        await SeedPeopleAsync(context);

        var handler = new EmergencyContactHandler(factory);
        await handler.DeleteEmergencyContactAsync(999);

        context.EmergencyContacts.Should().BeEmpty();
    }
}
