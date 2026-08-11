using MembershipManagement.Domain.Common;
using MembershipManagement.Domain.Memberships.Enums;
using MembershipManagement.Domain.Memberships.ValueObjects;

namespace MembershipManagement.Domain.Memberships.Entities;

public class Membership : Entity
{
    private Membership()
    {
    }

    public Guid MemberId { get; private set; }

    public MembershipNumber Number { get; private set; } = null!;

    public MembershipStatus Status { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime ExpiryDate { get; private set; }

    public static Membership Create(
        Guid memberId,
        MembershipNumber number,
        DateTime startDate,
        DateTime expiryDate)
    {
        if (memberId == Guid.Empty)
            throw new DomainException("Invalid member.");

        if (expiryDate <= startDate)
            throw new DomainException(
                "Expiry date must be after start date.");

        var membership = new Membership
        {
            MemberId = memberId,
            Number = number,
            Status = MembershipStatus.Active,
            StartDate = startDate,
            ExpiryDate = expiryDate
        };

        membership.AddDomainEvent(
            new MembershipCreatedEvent(
                membership.Id,
                membership.MemberId));

        return membership;
    }

    public void Renew(DateTime newExpiryDate)
    {
        if (Status == MembershipStatus.Cancelled)
            throw new DomainException(
                "Cancelled membership cannot be renewed.");

        if (newExpiryDate <= ExpiryDate)
            throw new DomainException(
                "New expiry date must be after current expiry date.");

        ExpiryDate = newExpiryDate;
        Status = MembershipStatus.Active;
    }

    public void Cancel()
    {
        if (Status == MembershipStatus.Cancelled)
            throw new DomainException(
                "Membership is already cancelled.");

        Status = MembershipStatus.Cancelled;
    }
}