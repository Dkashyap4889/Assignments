using MembershipManagement.Domain.Common;

namespace MembershipManagement.Application.Common.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(
        IReadOnlyCollection<DomainEvent> domainEvents,
        CancellationToken cancellationToken);
}