using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MiddlewareDemo.Hubs;
using MiddlewareDemo.Models;

[ApiController]
[Route("api/notifications")]
public class NotificationController : ControllerBase
{
    private readonly IHubContext<NotificationHub> _hub;

    public NotificationController(
        IHubContext<NotificationHub> hub)
    {
        _hub = hub;
    }

    [HttpPost]
    public async Task<IActionResult> Send(NotificationDto dto)
    {
        await _hub.Clients
            .Group(dto.Group)
            .SendAsync(
                "NotificationCreated",
                dto);

        return Ok();
    }
}