using MediatR;
using Microsoft.AspNetCore.Mvc;
using MembershipManagement.Application.Memberships.Commands.CreateMembership;

namespace MembershipManagement.API.Controllers;

[ApiController]
[Route("api/memberships")]
public class MembershipController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembershipController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMembershipCommand command,
        CancellationToken cancellationToken)
    {
        var membershipId = await _mediator.Send(
            command,
            cancellationToken);

        return Ok(new
        {
            Id = membershipId
        });
    }
}