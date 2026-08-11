using MembershipManagement.Domain.Common;

namespace MembershipManagement.Domain.Memberships.ValueObjects;

public record MembershipNumber
{
    public string Value { get; }

    private MembershipNumber(string value)
    {
        Value = value;
    }

    public static MembershipNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(
                "Membership number cannot be empty.");
        }

        return new MembershipNumber(value);
    }

    public override string ToString()
    {
        return Value;
    }
}