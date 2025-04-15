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
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.PostCode)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasOne<PersonModel>()
            .WithMany(p => p.Addresses)
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<AddressTypeModel>()
            .WithMany(a => a.Addresses)
            .HasForeignKey(a => a.AddressTypeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}