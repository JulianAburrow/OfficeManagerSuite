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
        builder.HasOne(e => e.Person)
            .WithMany(p => p.EmergencyContacts)
            .HasForeignKey(e => e.PersonId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Relationship)
            .WithMany(e => e.EmergencyContacts)
            .HasForeignKey(e => e.RelationshipId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
