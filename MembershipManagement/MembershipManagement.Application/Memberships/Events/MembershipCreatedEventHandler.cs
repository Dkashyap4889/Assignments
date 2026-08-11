using MediatR;
using MembershipManagement.Application.Notifications.Services;

namespace MembershipManagement.Application.Memberships.Events;

public class MembershipCreatedEventHandler
    : INotificationHandler<MembershipCreatedEvent>
{
    private readonly INotificationService _notificationService;

    public MembershipCreatedEventHandler(
        INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task Handle(
        MembershipCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        await _notificationService.SendMembershipCreatedAsync(
            notification.MembershipId,
            cancellationToken);
    }
}