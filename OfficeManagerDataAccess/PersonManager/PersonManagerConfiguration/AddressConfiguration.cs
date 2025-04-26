namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<AddressModel>
{
    public void Configure(EntityTypeBuilder<AddressModel> builder)
    {
        builder.ToTable("Address");
        builder.HasKey(a => a.AddressId);
        builder.Property(a => a.AddressId)
            .ValueGeneratedOnAdd();
        builder.Property(a => a.AddressLine1)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.AddressLine2)
            .IsRequired(false)
            .HasMaxLength(100);
        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.Postcode)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasOne<PersonModel>()
            .WithMany(p => p.Addresses)
            .HasForeignKey(a => a.PersonId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne<AddressTypeModel>()
            .WithMany(a => a.Addresses)
            .HasForeignKey(a => a.AddressTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}