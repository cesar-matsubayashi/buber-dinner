using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.List
{
    public class ListMenuQueryHandler
        : IRequestHandler<ListMenuQuery, ErrorOr<List<Menu>>>
    {
        private readonly IMenuRepository _menuRepository;

        public ListMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<List<Menu>>> Handle(
            ListMenuQuery request, 
            CancellationToken cancellationToken)
        {
            var listMenu = await _menuRepository.GetAllAsync(request.HostId);

            return listMenu;
        }
    }
}
