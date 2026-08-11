using MediatR;
using MembershipManagement.Application.Common.Interfaces;
using MembershipManagement.Domain.Memberships.Entities;
using MembershipManagement.Domain.Memberships.ValueObjects;

namespace MembershipManagement.Application.Memberships.Commands.CreateMembership;

public class CreateMembershipCommandHandler
    : IRequestHandler<CreateMembershipCommand, Guid>
{
    private readonly IMembershipRepository _repository;
    private readonly IDomainEventDispatcher _eventDispatcher;

    public CreateMembershipCommandHandler(
        IMembershipRepository repository,
        IDomainEventDispatcher eventDispatcher)
    {
        _repository = repository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<Guid> Handle(
        CreateMembershipCommand request,
        CancellationToken cancellationToken)
    {
        var membershipNumber =
            MembershipNumber.Create(
                request.MembershipNumber);

        var membership = Membership.Create(
            request.MemberId,
            membershipNumber,
            request.StartDate,
            request.ExpiryDate);

        await _repository.AddAsync(
            membership,
            cancellationToken);

        await _eventDispatcher.DispatchAsync(
            membership.DomainEvents,
            cancellationToken);

        membership.ClearDomainEvents();

        return membership.Id;
    }
}