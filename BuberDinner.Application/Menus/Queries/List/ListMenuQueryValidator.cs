using FluentValidation;

namespace BuberDinner.Application.Menus.Queries.List
{
    public class GetMenuQueryValidator : AbstractValidator<ListMenuQuery>
    {
        public GetMenuQueryValidator()
        {
            RuleFor(m => m.HostId).NotEmpty();
        }
    }
}
