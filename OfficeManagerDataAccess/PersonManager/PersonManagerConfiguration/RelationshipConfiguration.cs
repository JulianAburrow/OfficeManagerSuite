namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class RelationshipConfiguration : IEntityTypeConfiguration<RelationshipModel>
{
    public void Configure(EntityTypeBuilder<RelationshipModel> builder)
    {
        builder.ToTable("Relationship");
        builder.HasKey(e => e.RelationshipId);
        builder.Property(r => r.RelationshipId)
            .ValueGeneratedOnAdd();
        builder.Property(r => r.RelationshipName)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasMany(r => r.EmergencyContacts)
            .WithOne(e => e.Relationship)
            .HasForeignKey(e => e.RelationshipId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
