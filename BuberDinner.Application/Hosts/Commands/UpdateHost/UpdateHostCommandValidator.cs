using FluentValidation;

namespace BuberDinner.Application.Hosts.Commands.UpdateHost
{
    public class UpdateHostCommandValidator : AbstractValidator<UpdateHostCommand>
    {
        public UpdateHostCommandValidator()
        {
            RuleFor(h => h.Id).NotEmpty();
            RuleFor(h => h.FirstName).NotEmpty();
            RuleFor(h => h.LastName).NotEmpty();
            RuleFor(h => h.ProfileImage).NotEmpty();
        }
    }
}
