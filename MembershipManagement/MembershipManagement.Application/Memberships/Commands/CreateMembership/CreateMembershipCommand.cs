using MediatR;

namespace MembershipManagement.Application.Memberships.Commands.CreateMembership;

public record CreateMembershipCommand(
    Guid MemberId,
    string MembershipNumber,
    DateTime StartDate,
    DateTime ExpiryDate
) : IRequest<Guid>;