namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerConfiguration;

public class VehicleConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("Vehicle");
        builder.HasKey(v => v.VehicleId);
        builder.Property(v => v.RegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasOne(v => v.Manufacturer)
            .WithMany(v => v.Vehicles)
            .HasForeignKey(v => v.ManufacturerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(m => m.Model)
            .WithMany(v => v.Vehicles)
            .HasForeignKey(v => v.ModelId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(v => v.Colour)
            .WithMany(v => v.Vehicles)
            .HasForeignKey(c => c.ColourId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
