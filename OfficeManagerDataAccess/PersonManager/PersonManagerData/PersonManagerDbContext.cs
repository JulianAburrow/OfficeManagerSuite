namespace OfficeManagerDataAccess.PersonManager.PersonManagerData;

public class PersonManagerDbContext(DbContextOptions<PersonManagerDbContext> options) : DbContext(options)
{
    public DbSet<AddressModel> Addresses { get; set; } = null!;

    public DbSet<AddressTypeModel> AddressTypes { get; set; } = null!;

    public DbSet<EmergencyContactModel> EmergencyContacts { get; set; } = null!;

    public DbSet<EmploymentStatusModel> EmploymentStatuses { get; set; } = null!;

    public DbSet<PersonalPronounsModel> PersonalPronouns { get; set; } = null!;

    public DbSet<PersonModel> People { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
            .Where(p => p.ClrType == typeof(string))))
        {
            property.SetIsUnicode(false);
        }

        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EmergencyContactConfiguration());
        modelBuilder.ApplyConfiguration(new EmploymentStatusConfiguration());
        modelBuilder.ApplyConfiguration(new PersonalPronounsConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }
}