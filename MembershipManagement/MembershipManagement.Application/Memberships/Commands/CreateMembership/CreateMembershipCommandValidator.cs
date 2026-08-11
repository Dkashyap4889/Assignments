using FluentValidation;

namespace MembershipManagement.Application.Memberships.Commands.CreateMembership;

public class CreateMembershipCommandValidator
    : AbstractValidator<CreateMembershipCommand>
{
    public CreateMembershipCommandValidator()
    {
        RuleFor(x => x.MemberId)
            .NotEmpty();

        RuleFor(x => x.MembershipNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.ExpiryDate)
            .GreaterThan(x => x.StartDate);
    }
}