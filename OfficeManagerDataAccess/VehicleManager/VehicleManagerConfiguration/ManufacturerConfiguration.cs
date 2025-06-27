
namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerConfiguration;

public class ManufacturerConfiguration : IEntityTypeConfiguration<ManufacturerModel>
{
    public void Configure(EntityTypeBuilder<ManufacturerModel> builder)
    {
        builder.ToTable("Manufacturer");
        builder.HasKey(m => m.ManufacturerId);
        builder.Property(m => m.ManufacturerName)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasMany(m => m.Vehicles)
            .WithOne(v => v.Manufacturer)
            .HasForeignKey(v => v.ManufacturerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(m => m.Models)
            .WithOne(m => m.Manufacturer)
            .HasForeignKey(m => m.ManufacturerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
