using MembershipManagement.Domain.Common;

namespace MembershipManagement.Domain.Memberships.Entities;

public class Member : Entity
{
    private Member()
    {
    }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public static Member Create(
        string firstName,
        string lastName,
        string email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        return new Member
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
    }
}