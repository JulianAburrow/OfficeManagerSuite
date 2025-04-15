namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressTypeModel>
{
    public void Configure(EntityTypeBuilder<AddressTypeModel> builder)
    {
        builder.ToTable("AddressType");
        builder.HasKey(a => a.AddressTypeId);
        builder.Property(a => a.AddressTypeId)
            .ValueGeneratedOnAdd();
        builder.Property(a => a.TypeName)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasMany(a => a.Addresses)
            .WithOne(a => a.AddressType)
            .HasForeignKey(a => a.AddressTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}