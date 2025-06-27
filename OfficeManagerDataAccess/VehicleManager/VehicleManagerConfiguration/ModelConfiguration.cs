
namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerConfiguration;

public class ModelConfiguration : IEntityTypeConfiguration<ModelModel>
{
    public void Configure(EntityTypeBuilder<ModelModel> builder)
    {
        builder.ToTable("Model");
        builder.HasKey(m => m.ModelId);
        builder.Property(m => m.ModelName)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasOne(m => m.Manufacturer)
            .WithMany(m => m.Models)
            .HasForeignKey(m => m.ManufacturerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.Vehicles)
            .WithOne(m => m.Model)
            .HasForeignKey(m => m.ModelId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
