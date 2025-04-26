namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class EmergencyContactConfiguration : IEntityTypeConfiguration<EmergencyContactModel>
{
    public void Configure(EntityTypeBuilder<EmergencyContactModel> builder)
    {
        builder.ToTable("EmergencyContact");
        builder.HasKey(e => e.EmergencyContactId);
        builder.Property(e => e.EmergencyContactId)
            .ValueGeneratedOnAdd();
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(e => e.Relationship)
            .IsRequired(false)
            .HasMaxLength(50);
        builder.HasOne(e => e.Person)
            .WithMany(p => p.EmergencyContacts)
            .HasForeignKey(e => e.PersonId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
