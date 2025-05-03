using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.DeleteMenu
{
    public class DeleteMenuComandValidator : AbstractValidator<DeleteMenuCommand>
    {
        public DeleteMenuComandValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}
