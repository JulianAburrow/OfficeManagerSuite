namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerData;

public class VehicleManagerDbContext(DbContextOptions<VehicleManagerDbContext> options) : DbContext(options)
{
    public DbSet<ColourModel> Colours { get; set; } = null!;

    public DbSet<ManufacturerModel> Manufacturers { get; set; } = null!;

    public DbSet<ModelModel> Models { get; set; } = null!;

    public DbSet<VehicleModel> Vehicles { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
            .Where(p => p.ClrType == typeof(string))))
        {
            property.SetIsUnicode(false);
        }

        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new ColourConfiguration());
        modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        modelBuilder.ApplyConfiguration(new ModelConfiguration());
    }
}
