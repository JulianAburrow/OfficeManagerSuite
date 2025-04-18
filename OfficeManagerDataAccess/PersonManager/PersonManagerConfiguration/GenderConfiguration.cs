
namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class GenderConfiguration : IEntityTypeConfiguration<GenderModel>
{
    public void Configure(EntityTypeBuilder<GenderModel> builder)
    {
        builder.ToTable("Gender");
        builder.HasKey(g => g.GenderId);
        builder.Property(g => g.GenderId)
            .ValueGeneratedOnAdd();
        builder.Property(g => g.GenderName)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasMany(g => g.Persons)
            .WithOne(g => g.Gender)
            .HasForeignKey(g => g.GenderId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
