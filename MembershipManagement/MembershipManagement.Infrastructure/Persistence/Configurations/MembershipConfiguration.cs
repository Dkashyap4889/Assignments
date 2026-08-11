using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MembershipManagement.Domain.Memberships.Entities;
using MembershipManagement.Domain.Memberships.ValueObjects;

namespace MembershipManagement.Infrastructure.Persistence.Configurations;

public class MembershipConfiguration
    : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.ToTable("Memberships");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MemberId)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.ExpiryDate)
            .IsRequired();

        builder.Property(x => x.Number)
            .HasConversion(
                number => number.Value,
                value => MembershipNumber.Create(value))
            .HasMaxLength(50)
            .IsRequired();

        // Domain events are not persisted by EF Core
        builder.Ignore(x => x.DomainEvents);
    }
}