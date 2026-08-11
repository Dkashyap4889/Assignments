using Microsoft.AspNetCore.SignalR;
using MembershipManagement.Application.Notifications.Services;
using MembershipManagement.API.Hubs;

namespace MembershipManagement.Infrastructure.Notifications;

public class SignalRNotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public SignalRNotificationService(
        IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMembershipCreatedAsync(
        Guid membershipId,
        CancellationToken cancellationToken)
    {
        await _hubContext.Clients.All.SendAsync(
            "MembershipCreated",
            new
            {
                MembershipId = membershipId,
                Message = "A new membership was created."
            },
            cancellationToken);
    }
}