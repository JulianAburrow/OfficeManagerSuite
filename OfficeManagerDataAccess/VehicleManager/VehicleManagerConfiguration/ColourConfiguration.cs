namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerConfiguration;

public class ColourConfiguration : IEntityTypeConfiguration<ColourModel>
{
    public void Configure(EntityTypeBuilder<ColourModel> builder)
    {
        builder.ToTable("Colour");
        builder.HasKey(c => c.ColourId);
        builder.Property(c => c.ColourName)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasMany(c => c.Vehicles)
            .WithOne(v => v.Colour)
            .HasForeignKey(v => v.ColourId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}