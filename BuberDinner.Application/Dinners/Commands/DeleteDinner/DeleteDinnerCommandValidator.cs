using FluentValidation;

namespace BuberDinner.Application.Dinners.Commands.DeleteDinner
{
    public class DeleteDinnerCommandValidator : AbstractValidator<DeleteDinnerCommand>
    {
        public DeleteDinnerCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
