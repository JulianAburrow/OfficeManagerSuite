
namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class EmploymentStatusConfiguration : IEntityTypeConfiguration<EmploymentStatusModel>
{
    public void Configure(EntityTypeBuilder<EmploymentStatusModel> builder)
    {
        builder.ToTable("EmploymentStatus");
        builder.HasKey(e => e.EmploymentStatusId);
        builder.Property(e => e.EmploymentStatusId)
            .ValueGeneratedOnAdd();
        builder.Property(e => e.StatusName)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasMany(e => e.Persons)
            .WithOne(p => p.EmploymentStatus)
            .HasForeignKey(p => p.EmploymentStatusId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
