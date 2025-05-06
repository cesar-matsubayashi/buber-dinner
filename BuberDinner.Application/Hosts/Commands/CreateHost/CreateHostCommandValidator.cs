using FluentValidation;

namespace BuberDinner.Application.Hosts.Commands.CreateHost
{
    public class CreateHostCommandValidator : AbstractValidator<CreateHostCommand>
    {
        public CreateHostCommandValidator()
        {
            RuleFor(h => h.FirstName).NotEmpty();
            RuleFor(h => h.LastName).NotEmpty();
            RuleFor(h => h.ProfileImage).NotEmpty();
            RuleFor(h => h.UserId).NotEmpty();
        }
    }
}
