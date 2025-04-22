namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;
public class PersonalPronounsConfiguration : IEntityTypeConfiguration<PersonalPronounsModel>
{
    public void Configure(EntityTypeBuilder<PersonalPronounsModel> builder)
    {
        builder.ToTable("PersonalPronouns");
        builder.HasKey(p => p.PersonalPronounsId);
        builder.Property(p => p.PersonalPronounsId)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.PronounNames)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasMany(p => p.Persons)
            .WithOne(p => p.PersonalPronouns)
            .HasForeignKey(p => p.PersonalPronounsId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
