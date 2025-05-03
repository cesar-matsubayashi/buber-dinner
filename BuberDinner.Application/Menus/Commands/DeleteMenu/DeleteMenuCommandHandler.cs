using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommandHandler
        : IRequestHandler<DeleteMenuCommand, ErrorOr<Deleted>>
    {
        private readonly IMenuRepository _menuRepository;

        public DeleteMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteMenuCommand request, 
            CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetAsync(request.Id);

            if (menu is null)
            {
                return Errors.Menu.NotFound;
            }

            await _menuRepository.DeleteAsync(request.Id);

            return new Deleted();
        }
    }
}
