using MembershipManagement.Domain.Common;

public record MembershipCreatedEvent(
    Guid MembershipId,
    Guid MemberId) : DomainEvent;