using FluentValidation;

namespace BuberDinner.Application.Menus.Queries.GetMenuById
{
    public class GetMenuQueryValidator : AbstractValidator<GetMenuQuery>
    {
        public GetMenuQueryValidator()
        {
            RuleFor(m => m.MenuId).NotEmpty();
        }
    }
}
