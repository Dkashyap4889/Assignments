namespace MembershipManagement.Application.Notifications.Services;

public interface INotificationService
{
    Task SendMembershipCreatedAsync(
        Guid membershipId,
        CancellationToken cancellationToken);
}