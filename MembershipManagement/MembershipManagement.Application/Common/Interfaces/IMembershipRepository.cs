using MembershipManagement.Domain.Memberships.Entities;

namespace MembershipManagement.Application.Common.Interfaces;

public interface IMembershipRepository
{
    Task AddAsync(
        Membership membership,
        CancellationToken cancellationToken);

    Task<Membership?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
}