using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace OfficeManagerDataAccess.PersonManager.PersonManagerConfiguration;

public class PersonConfiguration : IEntityTypeConfiguration<PersonModel>
{
    public void Configure(EntityTypeBuilder<PersonModel> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(p => p.PersonId);
        builder.Property(p => p.PersonId)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.FirstName)
            .HasMaxLength(100);
        builder.Property(p => p.MiddleNames)
            .HasMaxLength(100);
        builder.Property(p => p.LastName)
            .HasMaxLength(100);
        builder.Property(p => p.EmploymentStatusId)
            .IsRequired();
        builder.Property(p => p.EmailAddress)
            .HasMaxLength(100);
        builder.HasMany(p => p.Addresses)
            .WithOne(p => p.Person)
            .IsRequired(false)
            .HasForeignKey(p => p.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p =>p.EmploymentStatus)
            .WithMany(p => p.Persons)
            .IsRequired()
            .HasForeignKey(p => p.EmploymentStatusId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.PersonalPronouns)
            .WithMany(p => p.Persons)
            .IsRequired(false)
            .HasForeignKey(p => p.PersonalPronounsId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.Gender)
            .WithMany(p => p.Persons)
            .IsRequired(false)
            .HasForeignKey(p => p.GenderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}