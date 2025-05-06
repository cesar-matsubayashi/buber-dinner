using FluentValidation;

namespace BuberDinner.Application.Hosts.Commands.DeleteHost
{
    public class DeleteHostCommandValidator : AbstractValidator<DeleteHostCommand>
    {
        public DeleteHostCommandValidator()
        {
            RuleFor(h => h.Id).NotEmpty();
        }
    }
}
