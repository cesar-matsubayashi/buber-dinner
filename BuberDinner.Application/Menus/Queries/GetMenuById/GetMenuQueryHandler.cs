using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetMenuById
{
    public class GetMenuQueryHandler
        : IRequestHandler<GetMenuQuery, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public GetMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(
            GetMenuQuery request, 
            CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetAsync(request.MenuId);

            if (menu is null)
            {
                return Errors.Menu.NotFound;
            }

            return menu;
        }
    }
}
