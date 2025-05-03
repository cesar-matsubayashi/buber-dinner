using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommandHandler
        : IRequestHandler<UpdateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public UpdateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(
            UpdateMenuCommand request, 
            CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetAsync(MenuId.Create(request.id));

            if (menu is null)
            {
                return Errors.Menu.NotFound;
            }

            menu.Update(
                request.Name,
                request.Description,
                request.Sections.ConvertAll(
                    section => MenuSection.Create(
                        section.Name,
                        section.Description,
                        section.Items.ConvertAll(item => MenuItem.Create(
                            item.Name,
                            item.Description)))));

            await _menuRepository.UpdateAsync(menu);

            return menu;
        }
    }
}
